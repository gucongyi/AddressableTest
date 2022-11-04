using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using System.Text;
using UnityEngine.ResourceManagement.ResourceProviders;
using static FileHelper;

public class AddressableDownLoadManager : MonoBehaviour
{
    public Text textTips;
    StringBuilder sb = new StringBuilder();
    public static AddressableDownLoadManager _instance;
    private List<object> m_keys=new List<object>();    //需要更新的资源列表
    private long m_totalSize = 0;
    private void Awake()
    {
        _instance = this;
        
    }

    private void Update()
    {
        textTips.text = sb.ToString();
    }
    //这个不清除的话，更新了会显示没有可下载的资源
    public void CleanLocalCatelogInfo()
    {
        string _catalogPath = Application.persistentDataPath + "/com.unity.addressables";
        if (Directory.Exists(_catalogPath))
        {
            try
            {
                Directory.Delete(_catalogPath, true);
                sb.Append("delete catalog cache done!\n");
            }
            catch (Exception e)
            {
                sb.Append($"<color=red>{e.ToString()}</color>\n");
            }
        }
        sb.Append("AssetManager init done\n");
    }
    // 检查是否有资源更新
    public IEnumerator CheckUpdate()
    {
        CleanLocalCatelogInfo();
        var initHandle = Addressables.InitializeAsync();
        yield return initHandle;

        // 检测更新
        var checkHandle = Addressables.CheckForCatalogUpdates(false);//这种方式只有一个文件AddressablesMainContentCatalog并且没有进度
        yield return checkHandle;
        //yield break;
        sb.Append($"Runtime:{UnityEngine.AddressableAssets.Addressables.RuntimePath}\n");
        
        sb.Append($"persistent:{Application.persistentDataPath}\n");
        sb.Append("=====正在校验资源文件=========\n");

        if (checkHandle.Status != AsyncOperationStatus.Succeeded)
        {
            sb.Append($"<color=red>检查更新失败：{checkHandle.OperationException.ToString()}</color>\n");
            Addressables.Release(checkHandle);
            yield break;
        }

        if (checkHandle.Result.Count <= 0)
        {
            // 没有需要更新的资源
            sb.Append("=======没有可更新资源=========\n");
            Addressables.Release(checkHandle);
            yield break;
        }
        for (int i = 0; i < checkHandle.Result.Count; i++)
        {
            sb.Append($"=======需要下载的资源：{checkHandle.Result[i]}=========\n");
        }
        var updateHandle = Addressables.UpdateCatalogs(checkHandle.Result, false);
        
        while (!updateHandle.IsDone)
        {
            sb.Append($"=======updateHandle下载进度=========percentage：{updateHandle.PercentComplete}\n");
            yield return null;
        }
        yield return updateHandle;//这里返回了就已经下载完成
        yield break;

        if (updateHandle.Status != AsyncOperationStatus.Succeeded)
        {
            sb.Append($"<color=red>获取更新列表失败：{updateHandle.OperationException.ToString()}</color>\n");
            Addressables.Release(checkHandle);
            Addressables.Release(updateHandle);
            yield break;
        }

        // 更新列表迭代器
        sb.Append("=======正在获取资源文件=========\n");
        List<IResourceLocator> locators = updateHandle.Result;
        foreach (var locator in locators)
        {
            m_keys.AddRange(locator.Keys);
        }

        // 获取待下载的文件总大小
        IEnumerable<object> enumerable = m_keys as IEnumerable<object>;
        var sizeHandle = Addressables.GetDownloadSizeAsync(enumerable);
        while (!sizeHandle.IsDone)
        {
            sb.Append($"=======下载进度=========percentage：{sizeHandle.PercentComplete}\n");
            yield return null;
        }
        yield return sizeHandle;

        if (sizeHandle.Status != AsyncOperationStatus.Succeeded)
        {
            sb.Append($"<color=red>GetDownloadSizeAsync Error\n{sizeHandle.OperationException.ToString()}</color>\n");
            yield break;
        }

        m_totalSize = sizeHandle.Result;

        if (m_totalSize <= 0)
        {
            // 没有需要更新的资源
            sb.Append("=======可更新资源没有大小=========\n");
            yield break;
        }

        //StartCoroutine(DownloadAsset());

        Addressables.Release(updateHandle);
        Addressables.Release(checkHandle);
    }

    //下载资源
    public IEnumerator DownloadAsset()
    {
        IEnumerable<object> enumerable = m_keys as IEnumerable<object>;
        var downloadHandle = Addressables.DownloadDependenciesAsync(enumerable, Addressables.MergeMode.Union, false);
        while (!downloadHandle.IsDone)
        {
            if (downloadHandle.Status == AsyncOperationStatus.Failed)
            {
                sb.Append($"<color=red>下载失败=====>{downloadHandle.OperationException.ToString()}</color>\n");
                yield break;
            }
            // 下载进度
            float percentage = downloadHandle.GetDownloadStatus().Percent;
            sb.Append($"=======下载进度=========percentage：{percentage}\n");
            yield return null;
        }

        if (downloadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            sb.Append($"=======下载进度=========percentage：100\n");
        }

        Addressables.Release(downloadHandle);
    }
    //行不通Addressables.ResourceLocators没有值
    public IEnumerator CheckUpdateByResourceLocators()
    {
        CleanLocalCatelogInfo();
        var initHandle = Addressables.InitializeAsync();
        yield return initHandle;

        // 检测更新
        var checkHandle = Addressables.CheckForCatalogUpdates(false);
        yield return checkHandle;
        IEnumerable<IResourceLocator> locators = Addressables.ResourceLocators;
        foreach (var item in locators)
        {
            var sizeHandle = Addressables.GetDownloadSizeAsync(item.Keys);
            yield return sizeHandle;
            if (sizeHandle.Result > 0)
            {
                var downloadHandle = Addressables.DownloadDependenciesAsync(item.Keys, Addressables.MergeMode.Union);
                yield return downloadHandle;
            }
        }
    }

    //通过Label（标签方式）下载
    public IEnumerator CheckUpdateByLabel()
    {
        CleanLocalCatelogInfo();
        //重定向下载,加载的url之前先刷新缓存，防止150天过期重新下载问题
        //RefreshCache();
        //重定向下载,加载的url
        Addressables.InternalIdTransformFunc = InternalIdTransformFunc;
        List<string> cachePaths = new List<string>();
        Caching.GetAllCachePaths(cachePaths);
        Debug.LogError($"===========Caching.cacheCount:{Caching.cacheCount} Caching:{cachePaths.Count}");
        

        string key = "FirstDownload";

        // Check the download size
        AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(key);
        yield return getDownloadSize;
        sb.Append($"=======下载总大小=========getDownloadSize：{getDownloadSize.Result}\n");
        //If the download size is greater than 0, download all the dependencies.
        if (getDownloadSize.Result > 0)
        {
            float currPercent = 0;//显示进度，作假
            AsyncOperationHandle downloadDependencies = Addressables.DownloadDependenciesAsync(key);
            while (!downloadDependencies.IsDone)
            {
                if (downloadDependencies.GetDownloadStatus().Percent == 0)
                {
                    if (currPercent < 0.5f)
                    {
                        currPercent += 0.01f;
                    }
                } else if (downloadDependencies.GetDownloadStatus().Percent > 0.5 && downloadDependencies.GetDownloadStatus().Percent < 1)
                {
                    currPercent = downloadDependencies.GetDownloadStatus().Percent * 0.8f;//最大到0.8
                }
                else if (downloadDependencies.GetDownloadStatus().Percent==1)
                {
                    if (currPercent<1f)
                    {
                        currPercent += 0.01f;
                    }
                }
                sb.Append($"=======下载进度=========Percent：{downloadDependencies.GetDownloadStatus().Percent}\n");
                sb.Append($"=======显示进度=========currPercent：{currPercent}\n");
                yield return null;
            }
            currPercent = 1.0f;
            sb.Append($"=======显示进度=========currPercent：{currPercent}\n");
            yield return downloadDependencies;
        }
    }
    ListInfoAddressableCache listInfoAddressableCache = new ListInfoAddressableCache();
    private void RefreshCache()
    {//=========在InternalIdTransformFunc之外调用Caching.MarkAsUsed无效
        string fileContent=FileHelper.ReadFile(FileHelper.InfoAddressableFile);
        if (string.IsNullOrEmpty(fileContent))
        {
            listInfoAddressableCache.infoAddressableCaches.Clear();
            string content = LitJson.JsonMapper.ToJson(listInfoAddressableCache);
            FileHelper.SaveFile(FileHelper.InfoAddressableFile, content);
            return;
        }
        else
        {
            listInfoAddressableCache = LitJson.JsonMapper.ToObject<ListInfoAddressableCache>(fileContent);
            if (listInfoAddressableCache.infoAddressableCaches.Count>0)
            {
                for (int i = 0; i < listInfoAddressableCache.infoAddressableCaches.Count; i++)
                {
                    string bundleName = listInfoAddressableCache.infoAddressableCaches[i].cacheBundleName;
                    Hash128 hash128 = Hash128.Parse(listInfoAddressableCache.infoAddressableCaches[i].cacheHash128String);
                    bool isVersionCached=Caching.IsVersionCached(new CachedAssetBundle(bundleName, hash128));
                    bool isMark = Caching.MarkAsUsed(new CachedAssetBundle(bundleName, hash128));
                    Debug.LogError($"BundleName:{bundleName}  hash:{hash128.ToString()} isVersionCached:{isVersionCached} isMark:{isMark}");
                }
            }
        }
    }

    private string InternalIdTransformFunc(UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation location)
    {
        //判定是否是一个AB包的请求
        if (location.Data is AssetBundleRequestOptions)
        {
            #region 缓存刷新 150天之内启动可以无限往后退缓存
            AssetBundleRequestOptions abInfo = location.Data as AssetBundleRequestOptions;
            Hash128 hash128 = Hash128.Parse(abInfo.Hash);
            CachedAssetBundle cachedAssetBundle=new CachedAssetBundle(abInfo.BundleName, hash128);
            //验证是否有缓存
            bool IsVersionCached = Caching.IsVersionCached(cachedAssetBundle);
            if (IsVersionCached)
            {
                bool isMark = Caching.MarkAsUsed(new CachedAssetBundle(abInfo.BundleName, hash128));//标记缓存到当前时间戳
                Debug.LogError($"abInfo.BundleName:{abInfo.BundleName} abInfo.hash:{abInfo.Hash} isMark：{isMark}");
            }
            #endregion
            InfoAddressableCache infoAddressableCache = new InfoAddressableCache() {cacheBundleName= abInfo.BundleName ,cacheHash128String= abInfo.Hash };
            bool isFind = false;
            for (int i = 0; i < listInfoAddressableCache.infoAddressableCaches.Count; i++)
            {
                if (listInfoAddressableCache.infoAddressableCaches[i].cacheBundleName== abInfo.BundleName)
                {
                    isFind = true;
                    break;
                }
            }
            if (isFind == false)
            {
                listInfoAddressableCache.infoAddressableCaches.Add(infoAddressableCache);
                string content = LitJson.JsonMapper.ToJson(listInfoAddressableCache);
                FileHelper.SaveFile(FileHelper.InfoAddressableFile, content);
            }
            //PrimaryKey是AB包的名字
            //path就是StreamingAssets/Bundles/AB包名.bundle,其中Bundles是自定义文件夹名字,发布应用程序时,复制的目录
            var path = Path.Combine(Application.streamingAssetsPath, "Bundles", location.PrimaryKey);
            if (File.Exists(path))
            {
                sb.Append($"=======InternalIdTransformFunc=========path：{path}\n");
                return path;
            }
        }
        return location.InternalId;
    }


}