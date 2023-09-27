/********************************************************************
	author: elftang
	desc:   Addressable 资源打包
*********************************************************************/
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using System;
using UnityEngine;
using System.IO;
using UnityEditor.Build.Pipeline.Utilities;

public class AddressableBuildTool
{
    private static AddressableAssetSettings AssetSettings
    {
        get
        {
            return AddressableAssetSettingsDefaultObject.Settings;
        }
    }

    //[MenuItem("BuildTools/AddressablesTools/打包资源")]
    public static void BuildGroupAssets()
    {
        ////Clean Build/All
        AddressableAssetSettings.CleanPlayerContent();
        //BuildCache.PurgeCache(false);
        //New Build/Defalut Build Script
        AddressableAssetSettings.BuildPlayerContent();
    }

    public static void OnUpdateBasePreviousBuild()
    {
        //////Clean Build/All
        //AddressableAssetSettings.CleanPlayerContent();
        ////BuildCache.PurgeCache(false);
        ////Update a Previous Build
        var path = ContentUpdateScript.GetContentStateDataPath(false);
        if (!string.IsNullOrEmpty(path))
            ContentUpdateScript.BuildContentUpdate(AddressableAssetSettingsDefaultObject.Settings, path);
        //var target = EditorUserBuildSettings.activeBuildTarget;
        //var path = $"{Directory.GetParent(Application.dataPath).ToString()}/Assets/AddressableAssetsData/{target}/addressables_content_state.bin";
        //Debug.Log($"===>>>  OnUpdateBasePreviousBuild addressables_content_state.bin path:{path}");
        //if (!string.IsNullOrEmpty(path))
        //    ContentUpdateScript.BuildContentUpdate(AddressableAssetSettingsDefaultObject.Settings, path);
    }

    //[MenuItem("BuildTools/AddressablesTools/打包更新资源")]
    public static void BuildForUpdateAssets()
    {
        string buildPath = ContentUpdateScript.GetContentStateDataPath(false);
        AddressablesPlayerBuildResult result = ContentUpdateScript.BuildContentUpdate(AssetSettings, buildPath);
    }

    //[MenuItem("BuildTools/AddressablesTools/静态资源更新分组")]
    public static void CheckForUpdateAssets()
    {
        string buildPath = ContentUpdateScript.GetContentStateDataPath(false);
        List<AddressableAssetEntry> entryList = ContentUpdateScript.GatherModifiedEntries(AssetSettings, buildPath);
        if (entryList.Count < 1)
        {
            return;
        }

        /*foreach(var entry in entryList)
        {
            Debug.LogError(entry.address);// 修改过的静态资源
        }*/

        ContentUpdateScript.CreateContentUpdateGroup(AssetSettings, entryList, "UpdateGroup_" + DateTime.Now.ToString("yyyyMMddhhmm"));
    }
}