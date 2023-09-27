/********************************************************************
    author: elftang
    desc:   Addressable 资源分组工具类
*********************************************************************/
using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using System.Collections.Generic;
using System.IO;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine.ResourceManagement;

public class AddressableAssetTool
{
    private static AddressableAssetSettings AssetSettings
    {
        get
        {
            if(AddressableAssetSettingsDefaultObject.Settings == null)
            {
                AddressableAssetSettingsDefaultObject.Settings = AddressableAssetSettings.Create(AddressableAssetSettingsDefaultObject.kDefaultConfigFolder, AddressableAssetSettingsDefaultObject.kDefaultConfigAssetName, true, true);
            }
            return AddressableAssetSettingsDefaultObject.Settings;
        }
    }


    //private static List<AddressableAssetEntry> m_assetEntryList = new List<AddressableAssetEntry>();


    // 将dgame/Resource修改为dgame/Resource_Move
    public static void ChangeResourceFileName()
    {
        string oldFileName = "Resources";
        string newFileName = "AddressableRes";

        string oldPath = string.Format("{0}/dgame/{1}", Application.dataPath, oldFileName);
        string newPath = string.Format("{0}/dgame/{1}", Application.dataPath, newFileName);

        if (!Directory.Exists(oldPath))
        {
            UnityEngine.Debug.LogError("文件名不存在！");
            return;
        }

        if (Directory.Exists(newPath))
        {
            Directory.Delete(newPath, true);
        }

        File.Move(oldPath, newPath);
        File.Delete(oldPath + ".meta");

        AssetDatabase.Refresh();
    }
    static List<string> m_groupNameList = new List<string>() {
            "Default Remote Group",
            "ui_atlas",//公共的
            "lua",//公共的
            "table1",//tablexxx打在一起//公共的
            "table2",
            "table3",
            "table4",
            "table5",
            "table6",
            "table7",
            "table8",
            "table9",
            "table10",
            "MapFile",//MapFile打在一起//公共的
            "ColliderData",//公共的
            "json",//公共的
            "HotFix",//公共的
            "shaders",//公共的
            "sounds",//公共的
            "behavior_tree",//公共的
            "base_file",//公共的
            "ui_mask_prelogin",//一个包
            "ui_mask_postlogin",//一个包
            "ui_view_prelogin1" ,//分成10个包
            "ui_view_prelogin2" ,
            "ui_view_prelogin3" ,
            "ui_view_prelogin4" ,
            "ui_view_prelogin5" ,
            "ui_view_prelogin6" ,
            "ui_view_prelogin7" ,
            "ui_view_prelogin8" ,
            "ui_view_prelogin9" ,
            "ui_view_prelogin10" ,
            "uiroot_prelogin",//单独放在一个分组里边，不然第一次加载UIRoot引用bundle很多，加载需要8s
            "ui_view_postlogin1" ,//分成10个包
            "ui_view_postlogin2" ,
            "ui_view_postlogin3" ,
            "ui_view_postlogin4" ,
            "ui_view_postlogin5" ,
            "ui_view_postlogin6" ,
            "ui_view_postlogin7" ,
            "ui_view_postlogin8" ,
            "ui_view_postlogin9" ,
            "ui_view_postlogin10" ,
            "ui_font_prelogin",
            "ui_font_postlogin",
            "ui_texture_prelogin1",//ui_texturexxx打在一起
            "ui_texture_prelogin2",
            "ui_texture_prelogin3",
            "ui_texture_prelogin4",
            "ui_texture_prelogin5",
            "ui_texture_prelogin6",
            "ui_texture_prelogin7",
            "ui_texture_prelogin8",
            "ui_texture_prelogin9",
            "ui_texture_prelogin10",
            "ui_texture_prelogin11",
            "ui_texture_prelogin12",
            "ui_texture_prelogin13",
            "ui_texture_prelogin14",
            "ui_texture_prelogin15",
            "ui_texture_prelogin16",
            "ui_texture_prelogin17",
            "ui_texture_prelogin18",
            "ui_texture_postlogin1",//ui_texturexxx打在一起
            "ui_texture_postlogin2",
            "ui_texture_postlogin3",
            "ui_texture_postlogin4",
            "ui_texture_postlogin5",
            "ui_texture_postlogin6",
            "ui_texture_postlogin7",
            "ui_texture_postlogin8",
            "ui_texture_postlogin9",
            "ui_texture_postlogin10",
            "ui_texture_postlogin11",
            "ui_texture_postlogin12",
            "ui_texture_postlogin13",
            "ui_texture_postlogin14",
            "ui_texture_postlogin15",
            "ui_texture_postlogin16",
            "ui_texture_postlogin17",
            "ui_texture_postlogin18",
            "models_prelogin1",//models_preloginXX打在一起
            "models_prelogin2",
            "models_prelogin3",
            "models_prelogin4",
            "models_prelogin5",
            "models_prelogin6",
            "models_prelogin7",
            "models_prelogin8",
            "models_prelogin9",
            "models_prelogin10",
            "models_postlogin1",//models_postloginXX打在一起
            "models_postlogin2",
            "models_postlogin3",
            "models_postlogin4",
            "models_postlogin5",
            "models_postlogin6",
            "models_postlogin7",
            "models_postlogin8",
            "models_postlogin9",
            "models_postlogin10",
            "map_common_prelogin",
            "map_common_postlogin",
            "bake_bone_prelogin",
            "bake_bone_tex_prelogin",
            "bake_bone_postlogin",
            "bake_bone_tex_postlogin",
            "effect_prelogin1",
            "effect_prelogin2",
            "effect_prelogin3",
            "effect_prelogin4",
            "effect_prelogin5",
            "effect_prelogin6",
            "effect_prelogin7",
            "effect_prelogin8",
            "effect_prelogin9",
            "effect_prelogin10",
            "effect_postlogin1",
            "effect_postlogin2",
            "effect_postlogin3",
            "effect_postlogin4",
            "effect_postlogin5",
            "effect_postlogin6",
            "effect_postlogin7",
            "effect_postlogin8",
            "effect_postlogin9",
            "effect_postlogin10",
            "animator_prelogin",
            "animator_postlogin",
            "cg_prelogin",
            "cg_postlogin",
            //场景
            "scene_prelogin",
            "scene_postlogin",
            //下边是美术文件夹
            //PreLogin
            //animation/animation下的7个文件夹生成7个组
            "art_animation_actor_prelogin",
            "art_animation_camera_prelogin",
            "art_animation_CG_chouka_prelogin",//一个包
            "art_animation_monster_prelogin",
            "art_animation_npc_prelogin",
            "art_animation_scene_element_prelogin",
            "art_animation_weapon_prelogin",
            //animation/animator_controller
            "art_animator_controller_prelogin",
            //animation/time_line_playable
            "art_animator_time_line_playable_prelogin",//一个包
            //art effect下文件夹
            "art_effect_prelogin",//一个包
            "art_effect_animation_prelogin",//一个包
            "art_effect_materials_prelogin",
            "art_effect_meshs_prelogin",
            "art_effect_meshs_statice_prelogin",
            "art_effect_scences_prelogin",
            "art_effect_textures_prelogin1",//art_effect_textures_preloginXX一个包
            "art_effect_textures_prelogin2",
            "art_effect_textures_prelogin3",
            "art_effect_textures_prelogin4",
            "art_effect_textures_prelogin5",
            "art_effect_textures_prelogin6",
            "art_effect_textures_prelogin7",
            "art_effect_textures_prelogin8",
            "art_effect_textures_prelogin9",
            "art_effect_textures_prelogin10",
            "art_effect_textures_prelogin11",
            "art_effect_textures_prelogin12",
            "art_effect_textures_prelogin13",
            "art_effect_textures_prelogin14",
            "art_effect_textures_prelogin15",
            //lightData
            "art_lightData_prelogin",
            //models下文件夹
            "art_models_actor_prelogin",
            "art_models_CG_chouka_prelogin",//一个包
            "art_models_douqikaijia_prelogin",
            "art_models_FX_prelogin",
            "art_models_monster_prelogin",
            "art_models_npc_prelogin",
            "art_models_other_prelogin",
            "art_models_scene_element_prelogin",
            "art_models_weapon_prelogin",
            //scenes文件夹
            "art_scenes_ground_textures_prelogin",//一个包
            "art_scenes_models_prelogin",
            "art_scenes_prefab_prelogin",
            "art_scenes_scenes_prelogin",
            "art_scenes_shadow_prelogin",
            "art_scenes_skybox_prelogin",//一个包
            //scripts_asset文件夹
            "art_scripts_asset_prelogin",
            //temporary_folder文件夹
            "art_temporary_folder_prelogin",
            //ui_animation_asset文件夹
            "art_ui_animation_asset_prelogin",//一个包
            //PostLogin
            //animation/animation下的7个文件夹生成7个组
            "art_animation_actor_postlogin",
            "art_animation_camera_postlogin",
            "art_animation_CG_chouka_postlogin",//一个包
            "art_animation_monster_postlogin",
            "art_animation_npc_postlogin",
            "art_animation_scene_element_postlogin",
            "art_animation_weapon_postlogin",
            //animation/animator_controller
            "art_animator_controller_postlogin",
            //animation/time_line_playable
            "art_animator_time_line_playable_postlogin",//一个包
            //art effect下文件夹
            "art_effect_postlogin",//一个包
            "art_effect_animation_postlogin",//一个包
            "art_effect_materials_postlogin",
            "art_effect_meshs_postlogin",
            "art_effect_meshs_statice_postlogin",
            "art_effect_scences_postlogin",
            "art_effect_textures_postlogin1",//art_effect_textures_postloginXX一个包
            "art_effect_textures_postlogin2",
            "art_effect_textures_postlogin3",
            "art_effect_textures_postlogin4",
            "art_effect_textures_postlogin5",
            "art_effect_textures_postlogin6",
            "art_effect_textures_postlogin7",
            "art_effect_textures_postlogin8",
            "art_effect_textures_postlogin9",
            "art_effect_textures_postlogin10",
            "art_effect_textures_postlogin11",
            "art_effect_textures_postlogin12",
            "art_effect_textures_postlogin13",
            "art_effect_textures_postlogin14",
            "art_effect_textures_postlogin15",
            //lightData
            "art_lightData_postlogin",
            //models下文件夹
            "art_models_actor_postlogin",
            "art_models_CG_chouka_postlogin",//一个包
            "art_models_douqikaijia_postlogin",
            "art_models_FX_postlogin",
            "art_models_monster_postlogin",
            "art_models_npc_postlogin",
            "art_models_other_postlogin",
            "art_models_scene_element_postlogin",
            "art_models_weapon_postlogin",
            //scenes文件夹
            "art_scenes_ground_textures_postlogin",//一个包
            "art_scenes_models_postlogin",
            "art_scenes_prefab_postlogin",
            "art_scenes_scenes_postlogin",
            "art_scenes_shadow_postlogin",
            "art_scenes_skybox_postlogin",//一个包
            //scripts_asset文件夹
            "art_scripts_asset_postlogin",
            //temporary_folder文件夹
            "art_temporary_folder_postlogin",
            //ui_animation_asset文件夹
            "art_ui_animation_asset_postlogin",//一个包
            //PostProcessing
            "postprocessing_tex",//一个包
            "postprocessing_shader",//一个包
            "postprocessing_resources",//一个包
        };

    [MenuItem("BuildTools/AddressablesTools/设置资源分组")]
    public static void MakeGroupsAssets()
    {
        // 清除后重新设置比其它快很多
        ClearAllGroup(m_groupNameList);
        //版本分支实际引用到的资源
        SetAddressableResGroupAssets();
        // 场景
        SetSceneGroupAssets();
        //美术资源
        SetArtGroupAssets();
        //冗余的资源,这些都放在首包
        string resourcePostProcessPathRoot = "Assets/dgame/ScriptMain/Extern/Third/com.unity.postprocessing@3.1.1/PostProcessing/";
        //PostProcessing下的贴图png,tga
        SetGroupAssets("postprocessing_tex", resourcePostProcessPathRoot + "Textures/BlueNoise64px", "*.png", true, AddressableLabels.eLabel.HotFixResPreLogin20);
        SetGroupAssets("postprocessing_tex", resourcePostProcessPathRoot + "Textures/BlueNoise256px", "*.png", true, AddressableLabels.eLabel.HotFixResPreLogin20);
        //PostProcessing下的shader
        SetGroupAssets("postprocessing_shader", resourcePostProcessPathRoot + "Shaders/", "*.shader", true, AddressableLabels.eLabel.HotFixResPreLogin20);
        SetGroupAssets("postprocessing_shader", resourcePostProcessPathRoot + "Shaders/", "*.compute", true, AddressableLabels.eLabel.HotFixResPreLogin20);
        //PostProcessing下的PostProcessResources.asset
        SetGroupAssets("postprocessing_resources", resourcePostProcessPathRoot, "*.asset", false, AddressableLabels.eLabel.HotFixResPreLogin20);


        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();

        Debug.Log($"<color=red>==============设置资源分组完成，请提交对应配置文件===========</color>");

    }

    private static void SetAddressableResGroupAssets()
    {
        /*
        资源分组有两种：
        一种是将文件夹添加到分组中
        一种是将单个资源加到分组中
        根据不同的打ab策略使用不同的分组
        */

        string resourcePathRoot = "Assets/dgame/AddressableRes/";
        string resourcePreLoginPathRoot = "Assets/dgame/AddressableRes/PreLogin/";
        string resourcePostLoginPathRoot = "Assets/dgame/AddressableRes/PostLogin/";

        //公共的
        //图集
        // ui 图集
        SetGroupAssets("ui_atlas", resourcePathRoot + "ui/altas/", null, false, AddressableLabels.eLabel.HotFixResPreLogin2);
        // Lua代码
        SetGroupAssets("lua", resourcePathRoot + "lua/", null, false, AddressableLabels.eLabel.HotFixResPreLogin15);
        SetGroupAssets("lua", resourcePathRoot + "lua/", "*.bytes", false, AddressableLabels.eLabel.HotFixResPreLogin15);
        //table数据
        SetGroupAssets("table", resourcePathRoot + "table/", "*.bytes", false, AddressableLabels.eLabel.HotFixResPreLogin16);
        //MapFile数据
        SetGroupAssets("MapFile", resourcePathRoot + "MapFile/", "*.bytes", false, AddressableLabels.eLabel.HotFixResPreLogin17);
        //ColliderData数据，包括美术位移，飞行碰撞，怪物碰撞
        SetGroupAssets("ColliderData", resourcePathRoot + "ColliderData/", "*.bytes", false, AddressableLabels.eLabel.HotFixResPreLogin18);
        //json数据
        SetGroupAssets("json", resourcePathRoot + "json/", "*.bytes", false, AddressableLabels.eLabel.HotFixResPreLogin19);
        //HotFix
        SetGroupAssets("HotFix", resourcePathRoot + "HotFix/", "*.bytes", false, AddressableLabels.eLabel.HotFixDLL);
        // Shaders
        SetGroupAssets("shaders", resourcePathRoot + "shaders/", null, false, AddressableLabels.eLabel.HotFixResPreLogin12);
        SetGroupAssets("shaders", resourcePathRoot + "shaders/", "*.shadervariants", false, AddressableLabels.eLabel.HotFixResPreLogin12);
        // 音效
        SetGroupAssets("sounds", resourcePathRoot + "sounds/", null, false, AddressableLabels.eLabel.HotFixResPreLogin6);
        SetGroupAssets("sounds", resourcePathRoot + "sounds/", "*.mixer", false, AddressableLabels.eLabel.HotFixResPreLogin6);
        // AI行为树
        SetGroupAssets("behavior_tree", resourcePathRoot + "behavior_tree/", "*.asset", false, AddressableLabels.eLabel.HotFixResPreLogin7);
        // 首包文件
        SetGroupAssets("base_file", resourcePathRoot + "BasePackFiles/", "*.txt", false, AddressableLabels.eLabel.HotFixResPreLogin21);
        //有边玩边下的
        //ui mat
        SetGroupAssets("ui_mask_prelogin", resourcePreLoginPathRoot + "ui/uimask/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin1);

        SetGroupAssets("ui_mask_postlogin", resourcePostLoginPathRoot + "ui/uimask/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin1);
        // ui 预制
        SetGroupAssets("ui_view_prelogin", resourcePreLoginPathRoot + "ui/view/", "*.prefab", true, AddressableLabels.eLabel.HotFixResPreLogin1);
        SetGroupAssets("uiroot_prelogin", resourcePreLoginPathRoot + "ui/uiroot/", "*.prefab", true, AddressableLabels.eLabel.HotFixResPreLogin1);

        SetGroupAssets("ui_view_postlogin", resourcePostLoginPathRoot + "ui/view/", "*.prefab", true, AddressableLabels.eLabel.HotFixResPostLogin1);

        // ui 字体
        SetGroupAssets("ui_font_prelogin", resourcePreLoginPathRoot + "ui/font/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin2);
        SetGroupAssets("ui_font_prelogin", resourcePreLoginPathRoot + "ui/font/", "*.TTF", false, AddressableLabels.eLabel.HotFixResPreLogin2);

        SetGroupAssets("ui_font_postlogin", resourcePostLoginPathRoot + "ui/font/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin2);
        SetGroupAssets("ui_font_postlogin", resourcePostLoginPathRoot + "ui/font/", "*.TTF", false, AddressableLabels.eLabel.HotFixResPostLogin2);

        // ui 散图
        SetGroupAssets("ui_texture_prelogin", resourcePreLoginPathRoot + "ui/dgame_texture/", "*.png", true, AddressableLabels.eLabel.HotFixResPreLogin3);

        SetGroupAssets("ui_texture_postlogin", resourcePostLoginPathRoot + "ui/dgame_texture/", "*.png", true, AddressableLabels.eLabel.HotFixResPostLogin3);

        // 模型
        SetGroupAssets("models_prelogin", resourcePreLoginPathRoot + "models/", "*", true, AddressableLabels.eLabel.HotFixResPreLogin4);
        
        SetGroupAssets("models_postlogin", resourcePostLoginPathRoot + "models/", "*", true, AddressableLabels.eLabel.HotFixResPostLogin4);
        
        // 场景预制资源
        SetGroupAssets("map_common_prelogin", resourcePreLoginPathRoot + "map_common/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin5);

        SetGroupAssets("map_common_postlogin", resourcePostLoginPathRoot + "map_common/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin5);
        
        // 特效,把每一个资源弄成一个bundle，不然整体较大，第一次加载资源很慢
        SetGroupAssets("effect_prelogin", resourcePreLoginPathRoot + "effect/", "*.prefab", true, AddressableLabels.eLabel.HotFixResPreLogin10);

        SetGroupAssets("effect_postlogin", resourcePostLoginPathRoot + "effect/", "*.prefab", true, AddressableLabels.eLabel.HotFixResPostLogin10);

        // 动画
        SetGroupAssets("animator_prelogin", resourcePreLoginPathRoot + "animator/monster/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin11);
        SetGroupAssets("animator_prelogin", resourcePreLoginPathRoot + "animator/mount/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin11);
        SetGroupAssets("animator_prelogin", resourcePreLoginPathRoot + "animator/weapon/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin11);

        SetGroupAssets("animator_postlogin", resourcePostLoginPathRoot + "animator/monster/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin11);
        SetGroupAssets("animator_postlogin", resourcePostLoginPathRoot + "animator/mount/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin11);
        SetGroupAssets("animator_postlogin", resourcePostLoginPathRoot + "animator/weapon/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin11);

        // CG
        SetGroupAssets("cg_prelogin", resourcePreLoginPathRoot + "cg/cutscene/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPreLogin14);

        SetGroupAssets("cg_postlogin", resourcePostLoginPathRoot + "cg/cutscene/", "*.prefab", false, AddressableLabels.eLabel.HotFixResPostLogin14);

    }

    private static void SetSceneGroupAssets()
    {
        string resouceScenePreLoginPathRoot = "Assets/dgame/scene/ab_scene/PreLogin/";
        string resouceScenePostLoginPathRoot = "Assets/dgame/scene/ab_scene/PostLogin/";
        SetGroupAssets("scene_prelogin", resouceScenePreLoginPathRoot, null, false, AddressableLabels.eLabel.HotFixResPreLogin13);
        SetGroupAssets("scene_prelogin", resouceScenePreLoginPathRoot, "*.unity", true, AddressableLabels.eLabel.HotFixResPreLogin13);

        SetGroupAssets("scene_postlogin", resouceScenePostLoginPathRoot, null, false, AddressableLabels.eLabel.HotFixResPostLogin13);
        SetGroupAssets("scene_postlogin", resouceScenePostLoginPathRoot, "*.unity", true, AddressableLabels.eLabel.HotFixResPostLogin13);
    }

    private static void SetArtGroupAssets()
    {
        string resouceArtPreLoginPathRoot = "Assets/dgame/art_resource/PreLogin/";
        string resouceArtPostLoginPathRoot = "Assets/dgame/art_resource/PostLogin/";
        //PreLogin

        //bake_bone
        SetGroupAssets("bake_bone_prelogin", resouceArtPreLoginPathRoot + "bake_bone/monster/", null,false, AddressableLabels.eLabel.HotFixResPreLogin4);
        SetGroupAssets("bake_bone_tex_prelogin", resouceArtPreLoginPathRoot + "bake_bone/monster/texture/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin4);
        SetGroupAssets("art_animation_actor_prelogin", resouceArtPreLoginPathRoot + "animation/animation/actor/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_camera_prelogin", resouceArtPreLoginPathRoot + "animation/animation/camera/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_camera_prelogin", resouceArtPreLoginPathRoot + "animation/animation/camera/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_CG_chouka_prelogin", resouceArtPreLoginPathRoot + "animation/animation/CG_chouka/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_monster_prelogin", resouceArtPreLoginPathRoot + "animation/animation/monster/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_npc_prelogin", resouceArtPreLoginPathRoot + "animation/animation/npc/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_scene_element_prelogin", resouceArtPreLoginPathRoot + "animation/animation/scene_element/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_animation_weapon_prelogin", resouceArtPreLoginPathRoot + "animation/animation/weapon/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);

        SetGroupAssets("art_animator_controller_prelogin", resouceArtPreLoginPathRoot + "animation/animator_controller/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);

        SetGroupAssets("art_animator_time_line_playable_prelogin", resouceArtPreLoginPathRoot + "animation/time_line_playable/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);

        SetGroupAssets("art_effect_prelogin", resouceArtPreLoginPathRoot + "effect/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_animation_prelogin", resouceArtPreLoginPathRoot + "effect/animation/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_animation_prelogin", resouceArtPreLoginPathRoot + "effect/animation/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_materials_prelogin", resouceArtPreLoginPathRoot + "effect/materials/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_meshs_prelogin", resouceArtPreLoginPathRoot + "effect/meshs/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_meshs_prelogin", resouceArtPreLoginPathRoot + "effect/meshs/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_meshs_statice_prelogin", resouceArtPreLoginPathRoot + "effect/meshs_statice/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_meshs_statice_prelogin", resouceArtPreLoginPathRoot + "effect/meshs_statice/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_scences_prelogin", resouceArtPreLoginPathRoot + "effect/scences/", null, false, AddressableLabels.eLabel.HotFixResPreLogin8);
        SetGroupAssets("art_effect_scences_prelogin", resouceArtPreLoginPathRoot + "effect/scences/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin8);

        SetGroupAssets("art_effect_textures_prelogin", resouceArtPreLoginPathRoot + "effect/textures/", "*", true, AddressableLabels.eLabel.HotFixResPreLogin8);
        
        SetGroupAssets("art_lightData_prelogin", resouceArtPreLoginPathRoot + "lightData/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);

        SetGroupAssets("art_models_actor_prelogin", resouceArtPreLoginPathRoot + "models/actor/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_CG_chouka_prelogin", resouceArtPreLoginPathRoot + "models/CG_chouka/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_douqikaijia_prelogin", resouceArtPreLoginPathRoot + "models/douqikaijia/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_FX_prelogin", resouceArtPreLoginPathRoot + "models/FX/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_monster_prelogin", resouceArtPreLoginPathRoot + "models/monster/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_npc_prelogin", resouceArtPreLoginPathRoot + "models/npc/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_other_prelogin", resouceArtPreLoginPathRoot + "models/other/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_other_prelogin", resouceArtPreLoginPathRoot + "models/other/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_scene_element_prelogin", resouceArtPreLoginPathRoot + "models/scene_element/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_models_weapon_prelogin", resouceArtPreLoginPathRoot + "models/weapon/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);

        SetGroupAssets("art_scenes_ground_textures_prelogin", resouceArtPreLoginPathRoot + "scenes/ground_textures/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_ground_textures_prelogin", resouceArtPreLoginPathRoot + "scenes/ground_textures/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_models_prelogin", resouceArtPreLoginPathRoot + "scenes/models/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_prefab_prelogin", resouceArtPreLoginPathRoot + "scenes/prefab/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_prefab_prelogin", resouceArtPreLoginPathRoot + "scenes/prefab/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_scenes_prelogin", resouceArtPreLoginPathRoot + "scenes/scenes/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_shadow_prelogin", resouceArtPreLoginPathRoot + "scenes/shadow/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_skybox_prelogin", resouceArtPreLoginPathRoot + "scenes/skybox/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_scenes_skybox_prelogin", resouceArtPreLoginPathRoot + "scenes/skybox/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);

        SetGroupAssets("art_scripts_asset_prelogin", resouceArtPreLoginPathRoot + "scripts_asset/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);

        SetGroupAssets("art_temporary_folder_prelogin", resouceArtPreLoginPathRoot + "temporary_folder/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_temporary_folder_prelogin", resouceArtPreLoginPathRoot + "temporary_folder/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);

        SetGroupAssets("art_ui_animation_asset_prelogin", resouceArtPreLoginPathRoot + "ui_animation_asset/", "*", false, AddressableLabels.eLabel.HotFixResPreLogin9);
        SetGroupAssets("art_ui_animation_asset_prelogin", resouceArtPreLoginPathRoot + "ui_animation_asset/", null, false, AddressableLabels.eLabel.HotFixResPreLogin9);


        //PostLogin
        //bake_bone
        SetGroupAssets("bake_bone_postlogin", resouceArtPostLoginPathRoot + "bake_bone/monster/", null, false, AddressableLabels.eLabel.HotFixResPostLogin4);
        SetGroupAssets("bake_bone_tex_postlogin", resouceArtPostLoginPathRoot + "bake_bone/monster/texture/", null, false, AddressableLabels.eLabel.HotFixResPostLogin4);
        SetGroupAssets("art_animation_actor_postlogin", resouceArtPostLoginPathRoot + "animation/animation/actor/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_camera_postlogin", resouceArtPostLoginPathRoot + "animation/animation/camera/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_camera_postlogin", resouceArtPostLoginPathRoot + "animation/animation/camera/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_CG_chouka_postlogin", resouceArtPostLoginPathRoot + "animation/animation/CG_chouka/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_monster_postlogin", resouceArtPostLoginPathRoot + "animation/animation/monster/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_npc_postlogin", resouceArtPostLoginPathRoot + "animation/animation/npc/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_scene_element_postlogin", resouceArtPostLoginPathRoot + "animation/animation/scene_element/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_animation_weapon_postlogin", resouceArtPostLoginPathRoot + "animation/animation/weapon/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);

        SetGroupAssets("art_animator_controller_postlogin", resouceArtPostLoginPathRoot + "animation/animator_controller/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);

        SetGroupAssets("art_animator_time_line_playable_postlogin", resouceArtPostLoginPathRoot + "animation/time_line_playable/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);

        SetGroupAssets("art_effect_postlogin", resouceArtPostLoginPathRoot + "effect/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_animation_postlogin", resouceArtPostLoginPathRoot + "effect/animation/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_animation_postlogin", resouceArtPostLoginPathRoot + "effect/animation/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_materials_postlogin", resouceArtPostLoginPathRoot + "effect/materials/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_meshs_postlogin", resouceArtPostLoginPathRoot + "effect/meshs/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_meshs_postlogin", resouceArtPostLoginPathRoot + "effect/meshs/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_meshs_statice_postlogin", resouceArtPostLoginPathRoot + "effect/meshs_statice/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_meshs_statice_postlogin", resouceArtPostLoginPathRoot + "effect/meshs_statice/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_scences_postlogin", resouceArtPostLoginPathRoot + "effect/scences/", null, false, AddressableLabels.eLabel.HotFixResPostLogin8);
        SetGroupAssets("art_effect_scences_postlogin", resouceArtPostLoginPathRoot + "effect/scences/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin8);

        SetGroupAssets("art_effect_textures_postlogin", resouceArtPostLoginPathRoot + "effect/textures/", "*", true, AddressableLabels.eLabel.HotFixResPostLogin8);

        SetGroupAssets("art_lightData_postlogin", resouceArtPostLoginPathRoot + "lightData/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);

        SetGroupAssets("art_models_actor_postlogin", resouceArtPostLoginPathRoot + "models/actor/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_CG_chouka_postlogin", resouceArtPostLoginPathRoot + "models/CG_chouka/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_douqikaijia_postlogin", resouceArtPostLoginPathRoot + "models/douqikaijia/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_FX_postlogin", resouceArtPostLoginPathRoot + "models/FX/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_monster_postlogin", resouceArtPostLoginPathRoot + "models/monster/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_npc_postlogin", resouceArtPostLoginPathRoot + "models/npc/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_other_postlogin", resouceArtPostLoginPathRoot + "models/other/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_other_postlogin", resouceArtPostLoginPathRoot + "models/other/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_scene_element_postlogin", resouceArtPostLoginPathRoot + "models/scene_element/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_models_weapon_postlogin", resouceArtPostLoginPathRoot + "models/weapon/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);

        SetGroupAssets("art_scenes_ground_textures_postlogin", resouceArtPostLoginPathRoot + "scenes/ground_textures/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_ground_textures_postlogin", resouceArtPostLoginPathRoot + "scenes/ground_textures/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_models_postlogin", resouceArtPostLoginPathRoot + "scenes/models/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_prefab_postlogin", resouceArtPostLoginPathRoot + "scenes/prefab/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_prefab_postlogin", resouceArtPostLoginPathRoot + "scenes/prefab/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_scenes_postlogin", resouceArtPostLoginPathRoot + "scenes/scenes/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_shadow_postlogin", resouceArtPostLoginPathRoot + "scenes/shadow/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_skybox_postlogin", resouceArtPostLoginPathRoot + "scenes/skybox/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_scenes_skybox_postlogin", resouceArtPostLoginPathRoot + "scenes/skybox/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);

        SetGroupAssets("art_scripts_asset_postlogin", resouceArtPostLoginPathRoot + "scripts_asset/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);

        SetGroupAssets("art_temporary_folder_postlogin", resouceArtPostLoginPathRoot + "temporary_folder/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_temporary_folder_postlogin", resouceArtPostLoginPathRoot + "temporary_folder/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);

        SetGroupAssets("art_ui_animation_asset_postlogin", resouceArtPostLoginPathRoot + "ui_animation_asset/", "*", false, AddressableLabels.eLabel.HotFixResPostLogin9);
        SetGroupAssets("art_ui_animation_asset_postlogin", resouceArtPostLoginPathRoot + "ui_animation_asset/", null, false, AddressableLabels.eLabel.HotFixResPostLogin9);
        
    }

    /// <summary>
    /// 删除分组中不存在的资源
    /// </summary>
    /// <param name="groupNameList">分组名列表</param>
    private static void ClearAllGroup(List<string> groupNameList)
    {
        List<AddressableAssetEntry> entries = new List<AddressableAssetEntry>();
        for (int index = 0, count = groupNameList.Count; index < count; index++)
        {
            string groupName = groupNameList[index];
            AddressableAssetGroup group = AssetSettings.FindGroup(groupName);
            if (group == null)
            {
                Debug.LogError(string.Format("没有找到对应的分组，分组名为：{0}。请先手动创建分组", groupName));
                continue;
            }

            //m_assetEntryList.Clear();

            //group.GatherAllAssets(m_assetEntryList, true, true, true, null);
            entries.Clear();
            foreach (var asset in group.entries)
            {
                entries.Add(asset);
            }

            foreach (var asset in entries)
            {
                group.RemoveAssetEntry(asset, true);
                if (asset.ParentEntry!=null)
                {
                    group.RemoveAssetEntry(asset.ParentEntry, true);
                }
            }
        }
    }

    static string GetFilePrePath(string filePath, string key)
    {
        var prePath = "";
        prePath = filePath.Substring(filePath.IndexOf(key) + key.Length);
        if (prePath.Contains("/"))
        {
            prePath = prePath.Substring(0, prePath.LastIndexOf("/"));
        }
        else
        {//有的没有前缀
            prePath = "";
        }
        //models/的不能带前缀，表格配置都没有带
        if ("models/" == key)
        {
            prePath = "";
        }
        return prePath;
    }

    /// <summary>
    /// 设置分组下的资源
    /// </summary>
    /// <param name="groupName">分组名</param>
    /// <param name="assetFolderPath">资源所有的文件路径</param>
    /// <param name="searchPattern">资源的后缀，如果后缀为null，表示根据文件夹进行分组设置</param>
    static void SetGroupAssets(string groupName, string assetPath, string searchPattern, bool searchAllDirectories,AddressableLabels.eLabel label, string prifixFolder = "", string prePath = "")
    {
        string[] assets;
        if (string.IsNullOrEmpty(searchPattern))
        {
            assets = GetFolderPaths(assetPath);
        }
        else
        {
            assets = GetAssetPaths(assetPath, searchPattern, searchAllDirectories);
        }

        if (assets == null || assets.Length < 1)
        {
            Debug.LogError(string.Format("{0} 路径下没有找到对应资源", assetPath));
            return;
        }

        AddressableAssetGroup group = null;
        if ("table" == groupName)
        {
            SetCommonMultiGroupByAssetNum(groupName, label, assets, 10, "table/");
        }
        else if ("ui_texture_prelogin" == groupName || "ui_texture_postlogin" == groupName)
        {
            SetCommonMultiGroupBySize(groupName, label, assets,8,18, "dgame_texture/");
        }
        else if ("effect_prelogin" == groupName || "effect_postlogin" == groupName)
        {
            SetCommonMultiGroupByAssetNum(groupName, label, assets, 10, "effect/");
        }
        else if ("ui_view_prelogin" == groupName || "ui_view_postlogin" == groupName)
        {
            SetCommonMultiGroupByAssetNum(groupName, label, assets,10, "view/");
        }
        else if (("models_prelogin" == groupName || "models_postlogin" == groupName))
        {
            SetCommonMultiGroupByAssetNum(groupName, label, assets,10, "models/");
        }
        else if (("art_effect_textures_prelogin" == groupName || "art_effect_textures_postlogin" == groupName))
        {
            SetCommonMultiGroupBySize(groupName, label, assets,10,15, "textures/");
        }
        else
        {
            group = AssetSettings.FindGroup(groupName);
            if (group == null)
            {
                Debug.LogError(string.Format("没有找到对应的分组，分组名为：{0}。请先手动创建分组", groupName));
                return;
            }

            // 添加新资源
            foreach (var path in assets)
            {
                AddAssetEntry(group, path, label, prePath);
            }
        }
        
    }

    /**通用分多组
     * eachPackSize 每组的M数
     * groupCount 分多少组
     * prePath 是否包含子文件夹作为前缀
     **/

    private static void SetCommonMultiGroupBySize(string groupName, AddressableLabels.eLabel label, string[] assets,int eachPackSize,int groupCount, string suffix)
    {
        AddressableAssetGroup group;
        //将dgame_texture文件夹下的散图按照每个包8M分配到18个组中，用来解决一些界面解压ab包导致的卡顿问题
        var eachPackBytes = 1048576f * eachPackSize;
        var groupIndex = 1;
        var totalSize = 0f;
        group = AssetSettings.FindGroup($"{groupName}{groupIndex}");
        // 添加新资源
        foreach (var path in assets)
        {
            if (path.EndsWith(".meta"))
            {
                continue;
            }
            if (group == null)
            {
                Debug.LogError(string.Format("没有找到对应的分组，分组名为：{0}。请先手动创建分组", groupName));
                return;
            }
            var lSize = 0f;
            if (File.Exists(path))
                lSize = new FileInfo(path).Length;
            string prePath = GetFilePrePath(path, suffix);
            AddAssetEntry(group, path, label, prePath);
            totalSize += lSize;
            if (totalSize > eachPackBytes && groupIndex < groupCount)
            {
                groupIndex++;
                totalSize = 0f;
                group = AssetSettings.FindGroup($"{groupName}{groupIndex}");
            }
        }
    }

    /**通用分多组
 * groupCount 分多少组
 * prePath 是否包含子文件夹作为前缀
 **/

    private static void SetCommonMultiGroupByAssetNum(string groupName, AddressableLabels.eLabel label, string[] assets,int groupCount, string suffix)
    {
        AddressableAssetGroup group;
        //去掉meta文件
        List<string> assetPathFilterMeta = new List<string>();
        for (int i = 0; i < assets.Length; i++)
        {
            if (assets[i].EndsWith(".meta"))
            {
                continue;
            }
            assetPathFilterMeta.Add(assets[i]);
        }
        // 按组添加资源,共groupCount组
        int eachGroupLength = assetPathFilterMeta.Count / groupCount;
        for (int i = 1; i < groupCount+1; i++)
        {
            group = AssetSettings.FindGroup($"{groupName}{i}");
            if (group == null)
            {
                Debug.LogError(string.Format("没有找到对应的分组，分组名为：{0}。请先手动创建分组", groupName));
                return;
            }
            for (int j = eachGroupLength * (i - 1); j < eachGroupLength * i; j++)
            {
                string prePath = GetFilePrePath(assetPathFilterMeta[j], suffix);
                AddAssetEntry(group, assetPathFilterMeta[j], label, prePath);
            }
        }
        //剩下的进最后
        int leftLength = assetPathFilterMeta.Count - eachGroupLength * groupCount;
        if (leftLength > 0)
        {
            group = AssetSettings.FindGroup($"{groupName}{groupCount}");
            for (int j = assetPathFilterMeta.Count - 1; j >= assetPathFilterMeta.Count - 1 - leftLength; j--)
            {
                if (j<0)
                {
                    break;
                }
                string prePath = GetFilePrePath(assetPathFilterMeta[j], suffix);
                AddAssetEntry(group, assetPathFilterMeta[j], label, prePath);
            }
        }
    }

    /// <summary>
    /// 获取目录下的文件夹列表
    /// </summary>
    static string[] GetFolderPaths(string searchPath)
    {
        string[] pathArray = Directory.GetDirectories(searchPath);
        string[] paths = new string[pathArray.Length];
        for (int i = 0, count = pathArray.Length; i < count; i++)
        {
            paths[i] = pathArray[i].Substring(pathArray[i].IndexOf("Assets")).Replace("\\", "/");
        }
        return paths;
    }

    /// <summary>
    /// 获取目录下的资源列表
    /// </summary>
    static string[] GetAssetPaths(string searchPath, string searchPattern, bool searchAllDirectories)
    {
        string[] pathArray = Directory.GetFiles(searchPath, searchPattern, searchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        string[] paths = new string[pathArray.Length];
        for (int i = 0, count = pathArray.Length; i < count; i++)
        {
            paths[i] = pathArray[i].Substring(pathArray[i].IndexOf("Assets")).Replace("\\", "/");
        }
        return paths;
    }

    /// <summary>
    /// group分组中添加资源
    /// </summary>
    /// <param name="group"></param>
    /// <param name="assetPath">资源路径</param>
    /// <returns></returns>
    static void AddAssetEntry(AddressableAssetGroup group, string assetPath,AddressableLabels.eLabel label, string prePath = "")
    {
        string guid = AssetDatabase.AssetPathToGUID(assetPath);
        AddressableAssetEntry entry = group.GetAssetEntry(guid);
        entry = AssetSettings.CreateOrMoveEntry(guid, group, false, true);
        string keyAddressable= Path.GetFileName(assetPath);
        if (string.IsNullOrEmpty(prePath) == false)
        {
            keyAddressable = $"{prePath}/{keyAddressable}";
        }

        if (keyAddressable.EndsWith(".meta"))
        {
            return;
        }
        entry.address = keyAddressable;
        entry.SetLabel(label.ToString(), true);
    }
    public static bool IsInitAB = false;
    public static bool isAllLocalAB = false;
    public static void SetGroupBuildAndLoadPath(string[] args)
    {
        IsInitAB = false;
        for (int i = 0; i < args.Length; ++i)
        {
            if (args[i].Equals("IsAllLocalAB=true"))
            {
                isAllLocalAB = true;
            }
            if (args[i].Equals("IsInitAB=true"))
            {
                IsInitAB = true;
            }
        }
        Debug.Log($"SetGroupBuildAndLoadPath  isAllLocalAB {isAllLocalAB}");
        Debug.Log($"SetGroupBuildAndLoadPath  IsInitAB {IsInitAB}");
        if (isAllLocalAB == false)
        {
            return;
        }
        else if (isAllLocalAB)
        {
            Debug.Log($"===> isAllLocalAB");
            AutoBuild.AddScriptingDefineSymbolsWithAddressables("Skip_Check_AB_Update");
        }
        for (int index = 0; index < m_groupNameList.Count; index++)
        {
            string groupName = m_groupNameList[index];
            AddressableAssetGroup group = AssetSettings.FindGroup(groupName);
            if (group == null)
            {
                Debug.LogError(string.Format("没有找到对应的分组，分组名为：{0}。请先手动创建分组", groupName));
                continue;
            }
            BundledAssetGroupSchema assetSchema = group.GetSchema<BundledAssetGroupSchema>();
            ProfileValueReference pvrBuild = assetSchema.BuildPath;
            pvrBuild.SetVariableByName(AssetSettings, "LocalBuildPath");
            ProfileValueReference pvrLoad = assetSchema.LoadPath;
            pvrLoad.SetVariableByName(AssetSettings, "LocalLoadPath");
            //AssetSettings.BuildRemoteCatalog = false;//下边的路径会隐藏
        }
    }



    //首包资源列表需要写文件，不然读取卡顿，获取资源大小也不正常
    const string fileBundleList = "Assets/StreamingAssets/fileBundleList.txt";
    static List<string> listFileBundle = new List<string>();
    //[MenuItem("Addressable/CopyToStream",false,1)]
    public static void CopyEnterPackBundleToStreamingAssets()
    {
        listFileBundle.Clear();
        if (File.Exists(fileBundleList) == false)
        {
            File.Create(fileBundleList).Close();
        }
        BuildTarget buildTarget = BuildTarget.Android;
        switch (buildTarget)
        {
            case BuildTarget.Android:
                buildTarget = BuildTarget.Android;
                break;
            case BuildTarget.iOS:
                buildTarget = BuildTarget.iOS;
                break;
            case BuildTarget.StandaloneWindows:
                buildTarget = BuildTarget.StandaloneWindows;
                break;
        }
        string dirPathRemoteBuild = Path.Combine(Application.dataPath.Replace("Assets", ""), "ServerData", buildTarget.ToString());
        if (Directory.Exists(dirPathRemoteBuild)==false)
        {
            return;
        }
        string[] files=Directory.GetFiles(dirPathRemoteBuild);
        if (files.Length<=0)
        {
            return;
        }
        //去掉全路径前边的路径，只留后边的文件
        List<string> listOnlyFileName = new List<string>();
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = files[i].Replace('\\', '/');
            int idx = files[i].LastIndexOf('/');
            listOnlyFileName.Add(files[i].Substring(idx+1));
        }
        bool isHaveCopy = false;
        for (int i = 0; i < listOnlyFileName.Count; i++)
        {
            for (int j = 0; j < WebRequestQueue.s_groupNameEnterPackList.Count; j++)
            {
                string stringPrefix = $"{WebRequestQueue.s_groupNameEnterPackList[j].ToLower()}_assets";
                if (listOnlyFileName[i].StartsWith(stringPrefix))//包全部小写
                {
                    isHaveCopy = true;
                    break;
                }
            }
            if (isHaveCopy)
            {
                break;
            }
        }
        if (isHaveCopy == false)
        {
            return;
        }

        string dirName = "Bundles";
        string destDirPath = Path.Combine(Application.streamingAssetsPath, dirName);
        if (Directory.Exists(destDirPath))
        {//删除后重新创建，清除上次的残留
            //删除非空文件夹中文件
            DirectoryInfo di = new DirectoryInfo(destDirPath);
            di.Delete(true);
        }
        if (Directory.Exists(destDirPath))
        {//删除空目录
            Directory.Delete(destDirPath);
        }
        Directory.CreateDirectory(destDirPath);
        //拷贝到对应目录下
        for (int i = 0; i < listOnlyFileName.Count; i++)
        {
            for (int j = 0; j < WebRequestQueue.s_groupNameEnterPackList.Count; j++)
            {
                //资源
                string stringAssetsPrefix = $"{WebRequestQueue.s_groupNameEnterPackList[j].ToLower()}_assets";
                //场景
                string stringScenePrefix= $"{WebRequestQueue.s_groupNameEnterPackList[j].ToLower()}_scenes";
                if (listOnlyFileName[i].StartsWith(stringAssetsPrefix)
                    ||listOnlyFileName[i].StartsWith(stringScenePrefix)
                    || listOnlyFileName[i].Contains("_unitybuiltinshaders_")//特殊资源6.5M
                    )//包全部小写
                {
                   string sourceFile = Path.Combine(dirPathRemoteBuild, listOnlyFileName[i]);
                   string destFile = Path.Combine(destDirPath, listOnlyFileName[i]);
                   
                   AddListFilterRepeate(listFileBundle,listOnlyFileName[i]);
                    //解决file exists的IOException
                    if (File.Exists(destFile)==false)
                    {
                        File.Copy(sourceFile, destFile);
                    }
                }
            }
        }

        ////拷贝特殊文件夹
        //CopyFolderPackBundleToStreamingAssets("effect_prelogin_assets_3d");
        //CopyFolderPackBundleToStreamingAssets("effect_prelogin_assets_2d");
        //写文件
        if (listFileBundle.Count > 0)
        {
            File.WriteAllLines(fileBundleList, listFileBundle);
            Debug.LogError($"写入文件{fileBundleList}成功！");
        }
    }
    public static void AddListFilterRepeate(List<string> listString,string str)
    {
        if (listString.Contains(str) ==false)
        {
            listString.Add(str);
        }
    }

    public static void CopyFolderPackBundleToStreamingAssets(string folderName)
    {
        BuildTarget buildTarget = BuildTarget.Android;
        switch (buildTarget)
        {
            case BuildTarget.Android:
                buildTarget = BuildTarget.Android;
                break;
            case BuildTarget.iOS:
                buildTarget = BuildTarget.iOS;
                break;
            case BuildTarget.StandaloneWindows:
                buildTarget = BuildTarget.StandaloneWindows;
                break;
        }
        string dirPathRemoteBuild = Path.Combine(Application.dataPath.Replace("Assets", ""), "ServerData", buildTarget.ToString(), folderName);
        if (Directory.Exists(dirPathRemoteBuild) == false)
        {
            return;
        }
        string[] files = Directory.GetFiles(dirPathRemoteBuild);
        if (files.Length <= 0)
        {
            return;
        }
        string dirName = "Bundles";
        string destDirPath = Path.Combine(Application.streamingAssetsPath, dirName,folderName);
        if (Directory.Exists(destDirPath))
        {//删除后重新创建，清除上次的残留
            //删除非空文件夹中文件
            DirectoryInfo di = new DirectoryInfo(destDirPath);
            di.Delete(true);
        }
        if (Directory.Exists(destDirPath))
        {//删除空目录
            Directory.Delete(destDirPath);
        }
        Directory.CreateDirectory(destDirPath);
        //拷贝目录
        DirectoryCopy(dirPathRemoteBuild, destDirPath);
    }
    static void DirectoryCopy(string sourceDirName, string destDirName)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
            Directory.CreateDirectory(destDirName);

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            AddListFilterRepeate(listFileBundle, file.Name);
            file.CopyTo(temppath, true);
        }
    }
}