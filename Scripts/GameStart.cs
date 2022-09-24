using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.LogError(Application.persistentDataPath);
        //yield return AddressableDownLoadManager._instance.CheckUpdate();
        //yield return AddressableDownLoadManager._instance.CheckUpdateByResourceLocators();
        yield return AddressableDownLoadManager._instance.CheckUpdateByLabel();

        Addressables.LoadAssetAsync<GameObject>("CubeRed.prefab").Completed+=(handle)=>{
            GameObject.Instantiate(handle.Result, new Vector3(0, 0, 0), Quaternion.identity);
        };


        Addressables.LoadAssetAsync<GameObject>("CubeGreen.prefab").Completed += (handle) =>
        {
            GameObject.Instantiate(handle.Result, new Vector3(3.25f, 0, 0), Quaternion.identity);
        };


        Addressables.LoadAssetAsync<GameObject>("SphereRed.prefab").Completed += (handle) => {
        GameObject.Instantiate(handle.Result, new Vector3(1.590202f, 0.6746087f, 2.41f), Quaternion.identity);
        };

        Addressables.LoadAssetAsync<GameObject>("SphereGreen.prefab").Completed += (handle) => {
        GameObject.Instantiate(handle.Result, new Vector3(1.590202f, 0.6746087f, -2.29f), Quaternion.identity);
        };

        Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefabs/CubeGreen 1.prefab").Completed += (handle) => {
         GameObject.Instantiate(handle.Result, new Vector3(-2f, 1f, -2.29f), Quaternion.identity);
        };


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
