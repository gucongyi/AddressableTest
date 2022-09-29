using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

public class TestAddressableEditorTool
{
    private static AddressableAssetSettings AssetSettings
    {
        get
        {
            if (AddressableAssetSettingsDefaultObject.Settings == null)
            {
                AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder, AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);
            }
            return AddressableAssetSettingsDefaultObject.Settings;
        }
    }
    [MenuItem("AddressTool/�����޸ı��ط�����·��")]
    public static void SetGroupBuildPath()
    {
        AddressableAssetGroup group = AssetSettings.FindGroup("LocalGroup");
        BundledAssetGroupSchema assetSchema =group.GetSchema<BundledAssetGroupSchema>();
        ProfileValueReference pvrBuild=assetSchema.BuildPath;
        pvrBuild.SetVariableByName(AssetSettings, UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.kRemoteBuildPath);
        ProfileValueReference pvrLoad = assetSchema.LoadPath;
        pvrLoad.SetVariableByName(AssetSettings, UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.kRemoteLoadPath);

        AssetSettings.BuildRemoteCatalog = false;//�±ߵ�·��������
        //����catelog buildpath �� loadpath����
        AssetSettings.BuildRemoteCatalog = true;
        AssetSettings.RemoteCatalogBuildPath.SetVariableByName(AssetSettings, UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.kLocalBuildPath);
        AssetSettings.RemoteCatalogLoadPath.SetVariableByName(AssetSettings, UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.kLocalLoadPath);
    }
}
