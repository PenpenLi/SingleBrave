using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;


using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Xml;

//  ResourceExport.cs
//  Lu Zexi
//  2012-7-11


/// <summary>
/// ��Դ�������
/// </summary>
public class ResourceExport
{
    //ROOT
    private const string RES_ROOT_DIR = "Assets/ResourcesWWW/";    //��Դ��Ŀ¼
    private const string RES_CACHE_DIR = "Assets/ResourcesCache/";    //������Դ��Ŀ¼
    private const string RES_AVATAR_DIR = "Assets/ResourcesHeroCache/AvatarM/";   //ͷ����ԴĿ¼
    private const string RES_ITEM_DIR = "Assets/ResourcesHeroCache/Item/";   //��Ʒ��ԴĿ¼
    private const string RES_TMP_ROOT_DIR = "Assets/TmpRes/";   //��ʱ��Դ

    //private const string RES_EXP_DIR = "e://res/";   //��Դ�洢��Ŀ¼
	private const string RES_EXP_DIR = "/Users/luzexi/Desktop/Work/res/";

    private const string RES_FILE_POST = ".res";    //�ļ���׺
    private const string RES_LOAD_DIR = "http://192.168.1.250/sanguo/server/service/res/res/";   //����Ŀ¼
    private const int VERSION = 1;  //�汾��

    //��Դ�ļ�
    private const string RES_FILE_NAME = "resource.txt";    //��Դ�ļ�

    //ǰ׺
    private const string RES_GUI_PRE = "GUI,BATTLE";       //GUIǰ׺
    private const string RES_MODEL_PRE = "MODEL";   //ģ��ǰ׺
    private const string RES_EFFECT_PRE = "effect"; //��Чǰ׺
    private const string RES_TEX_PRE = "Tex";   //ͼƬǰ׺
    private const string RES_TABLE_PRE = "TABLE";   //��Դ��ǰ׺
    private const string RES_AVATAR_PRE = "Tex";    //ͷ��ǰ׺
    private const string RES_ITEM_PRE = "item"; //��Ʒǰ׺

    //Ŀ¼
    private const string RES_GUI_DIR = "GUI/";  //GUIĿ¼
    private const string RES_GUI_CACHE_DIR = "GUICache/";   //GUI����
    private const string RES_GUI_RES_NAME = "gui";   //GUI��Դ��
    private const string RES_GUI_CACHE_RES_NAME = "gui_cache";   //GUICache��Դ��
    private const string RES_MODEL_DIR = "Model/";  //MODELĿ¼
    private const string RES_MODEL_RES_NAME = "model";  //ģ����Դ��
    private const string RES_EFFECT_DIR = "Effect/";    //��ЧĿ¼
    private const string RES_EFFECT_RES_NAME = "effect";    //��Ч��Դ��
    private const string RES_TEX_DIR = "Tex/";    //ͼƬĿ¼
    private const string RES_TEX_RES_NAME = "tex";   //ͼƬ����Դ��
    private const string RES_TEX_AVATAR_M_DIR = "AvatarM/"; //��ͷ��
    //private const string RES_TEX_AVATAR_M_NAME = "avatarm"; //��ͷ����Դ����
    private const string RES_TEX_ITEM_DIR = "Item/"; //��ƷͼƬ
    private const string RES_TABLE_DIR = "Table/";  //���ݱ�Ŀ¼
    private const string RES_TABLE_RES_NAME = "table";  //���ݱ�����Դ��


    //��ƽ̨Ŀ¼
    private const string RES_WIN_DIR = "win32test/"; //WINĿ¼
    private const string RES_IOS_DIR = "ios/";   //IOSĿ¼
    private const string RES_ANDROID_DIR = "android/";   //��׿Ŀ¼


    //���Դ����Դ
    [MenuItem("GameTool/����IOS��Դ���")]
    static void EXPORT_ALL_TEST_IOS()
    {
        uint crcIOSGUI;
        ExportAllSingleResource(RES_AVATAR_DIR, RES_IOS_DIR + RES_TEX_AVATAR_M_DIR, RES_AVATAR_PRE, BuildTarget.iPhone);
        ExportAllSingleResource(RES_ITEM_DIR, RES_IOS_DIR + RES_TEX_ITEM_DIR, RES_ITEM_PRE, BuildTarget.iPhone);
    }

    [MenuItem("GameTool/����ƽ̨��Դ���")]
    static void ExportAllPlatform()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            ExportAllWindows();
            ExportAllIOS();
            ExportAllAndroid();

            //List<string> lstName = new List<string>();
            //List<string> lstDir = new List<string>();
            //List<uint> lstCrc = new List<uint>();
            
            ////win
            //uint crcWINGUI;
            //uint crcWINMODEL;
            //uint crcWINEFFECT;
            //uint crcWINTEX;
            //uint crcWINTABLE;
            //lstCrc.Clear();
            //lstDir.Clear();
            //lstName.Clear();
            //ExportAllResource(RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME, out crcWINGUI, BuildTarget.StandaloneWindows);
            ////lstCrc.Add(crcWINGUI);
            ////lstDir.Add(RES_GUI_DIR);
            ////lstName.Add(RES_GUI_RES_NAME);
            //ExportAllResource(RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME, out crcWINMODEL, BuildTarget.StandaloneWindows);
            ////lstCrc.Add(crcWINMODEL);
            ////lstDir.Add(RES_MODEL_DIR);
            ////lstName.Add(RES_MODEL_RES_NAME);
            //ExportAllResource(RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME, out crcWINEFFECT, BuildTarget.StandaloneWindows);
            ////lstCrc.Add(crcWINEFFECT);
            ////lstDir.Add(RES_EFFECT_DIR);
            ////lstName.Add(RES_EFFECT_RES_NAME);
            //ExportAllResource(RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE, RES_TEX_RES_NAME, out crcWINTEX , BuildTarget.StandaloneWindows);
            ////lstCrc.Add(crcWINTEX);
            ////lstDir.Add(RES_TEX_DIR);
            ////lstName.Add(RES_TEX_RES_NAME);
            //ExportAllResource(RES_WIN_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcWINTABLE, BuildTarget.StandaloneWindows);
            //lstCrc.Add(crcWINTABLE);
            //lstDir.Add(RES_TABLE_DIR);
            //lstName.Add(RES_TABLE_RES_NAME);
            //ExportXml(RES_WIN_DIR, RES_FILE_NAME,lstName,lstDir,lstCrc);
            ////ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);


            ////ios
            //uint crcIOSGUI;
            //uint crcIOSMODEL;
            //uint crcIOSEFFECT;
            //uint crcIOSTEX;
            //uint crcIOSTABLE;
            //lstCrc.Clear();
            //lstDir.Clear();
            //lstName.Clear();
            //ExportAllResource(RES_IOS_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME,out crcIOSGUI, BuildTarget.iPhone);
            ////lstCrc.Add(crcIOSGUI);
            ////lstDir.Add(RES_GUI_DIR);
            ////lstName.Add(RES_GUI_RES_NAME);
            //ExportAllResource(RES_IOS_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME,out crcIOSMODEL, BuildTarget.iPhone);
            ////lstCrc.Add(crcIOSMODEL);
            ////lstDir.Add(RES_MODEL_DIR);
            ////lstName.Add(RES_MODEL_RES_NAME);
            //ExportAllResource(RES_IOS_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME,out crcIOSEFFECT , BuildTarget.iPhone);
            ////lstCrc.Add(crcIOSEFFECT);
            ////lstDir.Add(RES_EFFECT_DIR);
            ////lstName.Add(RES_EFFECT_RES_NAME);
            //ExportAllResource(RES_IOS_DIR + RES_TEX_DIR, RES_TEX_PRE, RES_TEX_RES_NAME,out crcIOSTEX , BuildTarget.iPhone);
            ////lstCrc.Add(crcIOSTEX);
            ////lstDir.Add(RES_TEX_DIR);
            ////lstName.Add(RES_TEX_RES_NAME);
            //ExportAllResource(RES_IOS_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME,out crcIOSTABLE, BuildTarget.iPhone);
            //lstCrc.Add(crcIOSTABLE);
            //lstDir.Add(RES_TABLE_DIR);
            //lstName.Add(RES_TABLE_RES_NAME);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME,lstName,lstDir,lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);

            ////android
            //uint crcANDROIDGUI;
            //uint crcANDROIDMODEL;
            //uint crcANDROIDEFFECT;
            //uint crcANDROIDTEX;
            //uint crcANDROIDTABLE;
            //lstCrc.Clear();
            //lstDir.Clear();
            //lstName.Clear();
            //ExportAllResource(RES_ANDROID_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME,out crcANDROIDGUI, BuildTarget.Android);
            ////lstCrc.Add(crcANDROIDGUI);
            ////lstDir.Add(RES_GUI_DIR);
            ////lstName.Add(RES_GUI_RES_NAME);
            //ExportAllResource(RES_ANDROID_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME,out crcANDROIDMODEL, BuildTarget.Android);
            ////lstCrc.Add(crcANDROIDMODEL);
            ////lstDir.Add(RES_MODEL_DIR);
            ////lstName.Add(RES_MODEL_RES_NAME);
            //ExportAllResource(RES_ANDROID_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME,out crcANDROIDEFFECT, BuildTarget.Android);
            ////lstCrc.Add(crcANDROIDEFFECT);
            ////lstDir.Add(RES_EFFECT_DIR);
            ////lstName.Add(RES_EFFECT_RES_NAME);
            //ExportAllResource(RES_ANDROID_DIR + RES_TEX_DIR, RES_TEX_PRE, RES_TEX_RES_NAME,out crcANDROIDTEX, BuildTarget.Android);
            ////lstCrc.Add(crcANDROIDTEX);
            ////lstDir.Add(RES_TEX_DIR);
            ////lstName.Add(RES_TEX_RES_NAME);
            //ExportAllResource(RES_ANDROID_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME,out crcANDROIDTABLE, BuildTarget.Android);
            //lstCrc.Add(crcANDROIDTABLE);
            //lstDir.Add(RES_TABLE_DIR);
            //lstName.Add(RES_TABLE_RES_NAME);
            //ExportXml(RES_ANDROID_DIR, RES_FILE_NAME,lstName,lstDir,lstCrc);
            ////ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
        }
    }

    ///////////////////////// ============================= win ======================= ////////////////////////////

    /// <summary>
    /// ��������WIN��Դ
    /// </summary>
    [MenuItem("GameTool/Windows/All")]
    static void ExportAllWindows()
    {
        if (EditorUtility.DisplayDialog("����!!!","ȷ��Ҫ���WIN��","��","����"))
        {
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            uint crcGUI;
            uint crcMODEL;
            uint crcEFFECT;
            uint crcTEX;
            uint crcTABLE;

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //battlefont


            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_WIN_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR,RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.StandaloneWindows);

            BuildPipeline.PopAssetDependencies();

            //lstCrc.Add(crcGUI);
            //lstDir.Add(RES_GUI_DIR);
            //lstName.Add(RES_GUI_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.StandaloneWindows);
            //lstCrc.Add(crcMODEL);
            //lstDir.Add(RES_MODEL_DIR);
            //lstName.Add(RES_MODEL_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.StandaloneWindows);
            //lstCrc.Add(crcEFFECT);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstName.Add(RES_EFFECT_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.StandaloneWindows);
            //lstCrc.Add(crcTEX);
            //lstDir.Add(RES_TEX_DIR);
            //lstName.Add(RES_TEX_RES_NAME);
            ExportAllResource(RES_ROOT_DIR, RES_WIN_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.StandaloneWindows);

            lstCrc.Add(crcTABLE);
            lstDir.Add(RES_TABLE_DIR);
            lstName.Add(RES_TABLE_RES_NAME);
            ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    ///// <summary>
    ///// ������Դ�ļ�
    ///// </summary>
    //[MenuItem("GameTool/Windows/File")]
    //static void ExportWinFile()
    //{
    //    if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
    //        ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
    //}

    [MenuItem("GameTool/Windows/TABLE")]
    static void ExportWindowsTABLE()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTABLE;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            ExportAllResource(RES_ROOT_DIR, RES_WIN_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.StandaloneWindows);
            lstName.Add(RES_TABLE_RES_NAME);
            lstDir.Add(RES_TABLE_DIR);
            lstCrc.Add(crcTABLE);
            ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    [MenuItem("GameTool/Windows/GUI")]
    static void ExportWindowsGUI()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcGUI;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME,out crcGUI, BuildTarget.StandaloneWindows);

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_WIN_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.StandaloneWindows);

            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.StandaloneWindows);

            BuildPipeline.PopAssetDependencies();
            //lstName.Add(RES_GUI_RES_NAME);
            //lstDir.Add(RES_GUI_DIR);
            //lstCrc.Add(crcGUI);
            //ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    [MenuItem("GameTool/Windows/Model")]
    static void ExportWindowsModel()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcMODEL;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME, out crcMODEL, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.StandaloneWindows);
            //lstName.Add(RES_MODEL_RES_NAME);
            //lstDir.Add(RES_MODEL_DIR);
            //lstCrc.Add(crcMODEL);
            //ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    [MenuItem("GameTool/Windows/Effect")]
    static void ExportWindowsEffect()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcEFFECT;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME,out crcEFFECT, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.StandaloneWindows);
            //lstName.Add(RES_EFFECT_RES_NAME);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstCrc.Add(crcEFFECT);
            //ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    [MenuItem("GameTool/Windows/Tex")]
    static void ExportWindowsTex()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTEX;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            //ExportAllResource(RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE , RES_TEX_RES_NAME , out crcTEX, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.StandaloneWindows);
            //lstName.Add(RES_TEX_RES_NAME);
            //lstDir.Add(RES_TEX_DIR);
            //lstCrc.Add(crcTEX);
            //ExportXml(RES_WIN_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    ///////////////////////// ============================= ios ======================= ////////////////////////////

    /// <summary>
    /// ��������IOS��Դ
    /// </summary>
    [MenuItem("GameTool/IOS/All")]
    static void ExportAllIOS()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            uint crcGUI;
            uint crcMODEL;
            uint crcEFFECT;
            uint crcTEX;
            uint crcTABLE;

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //battlefont


            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_IOS_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.iPhone);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.iPhone);

            BuildPipeline.PopAssetDependencies();

            //lstCrc.Add(crcGUI);
            //lstDir.Add(RES_GUI_DIR);
            //lstName.Add(RES_GUI_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.iPhone);
            //lstCrc.Add(crcMODEL);
            //lstDir.Add(RES_MODEL_DIR);
            //lstName.Add(RES_MODEL_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.iPhone);
            //lstCrc.Add(crcEFFECT);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstName.Add(RES_EFFECT_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.iPhone);
            //lstCrc.Add(crcTEX);
            //lstDir.Add(RES_TEX_DIR);
            //lstName.Add(RES_TEX_RES_NAME);
            ExportAllResource(RES_ROOT_DIR, RES_IOS_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.iPhone);

            lstCrc.Add(crcTABLE);
            lstDir.Add(RES_TABLE_DIR);
            lstName.Add(RES_TABLE_RES_NAME);
            ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    ///// <summary>
    ///// ������Դ�ļ�
    ///// </summary>
    //[MenuItem("GameTool/IOS/File")]
    //static void ExportIOSFile()
    //{
    //    if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
    //    {
    //        ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
    //    }
    //}

    [MenuItem("GameTool/IOS/TABLE")]
    static void ExportIOSTABLE()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTABLE;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            ExportAllResource(RES_ROOT_DIR, RES_IOS_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.iPhone);
            lstName.Add(RES_TABLE_RES_NAME);
            lstDir.Add(RES_TABLE_DIR);
            lstCrc.Add(crcTABLE);
            ExportAllResource(RES_CACHE_DIR, RES_IOS_DIR + RES_GUI_CACHE_DIR, RES_GUI_PRE, RES_GUI_CACHE_RES_NAME, out crcTABLE, BuildTarget.iPhone);
            lstName.Add(RES_GUI_CACHE_RES_NAME);
            lstDir.Add(RES_GUI_CACHE_DIR);
            lstCrc.Add(crcTABLE);
            ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    [MenuItem("GameTool/IOS/GUI")]
    static void ExportIOSGUI()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcGUI;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME,out crcGUI, BuildTarget.StandaloneWindows);

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_IOS_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.iPhone);

            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.iPhone);

            BuildPipeline.PopAssetDependencies();
            //lstName.Add(RES_GUI_RES_NAME);
            //lstDir.Add(RES_GUI_DIR);
            //lstCrc.Add(crcGUI);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    [MenuItem("GameTool/IOS/Model")]
    static void ExportIOSModel()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcMODEL;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME, out crcMODEL, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.iPhone);
            //lstName.Add(RES_MODEL_RES_NAME);
            //lstDir.Add(RES_MODEL_DIR);
            //lstCrc.Add(crcMODEL);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    [MenuItem("GameTool/IOS/Effect")]
    static void ExportIOSEffect()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcEFFECT;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME,out crcEFFECT, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.iPhone);
            //lstName.Add(RES_EFFECT_RES_NAME);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstCrc.Add(crcEFFECT);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    [MenuItem("GameTool/IOS/Tex")]
    static void ExportIOSTex()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTEX;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            //ExportAllResource(RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE , RES_TEX_RES_NAME , out crcTEX, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_IOS_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.iPhone);
            //lstName.Add(RES_TEX_RES_NAME);
            //lstDir.Add(RES_TEX_DIR);
            //lstCrc.Add(crcTEX);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    ///////////////////////// ============================= android ======================= ////////////////////////////

    /// <summary>
    /// ��������IOS��Դ
    /// </summary>
    [MenuItem("GameTool/Android/All")]
    static void ExportAllAndroid()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            uint crcGUI;
            uint crcMODEL;
            uint crcEFFECT;
            uint crcTEX;
            uint crcTABLE;

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);


            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_ANDROID_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.Android);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.Android);

            BuildPipeline.PopAssetDependencies();

            //lstCrc.Add(crcGUI);
            //lstDir.Add(RES_GUI_DIR);
            //lstName.Add(RES_GUI_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.Android);
            //lstCrc.Add(crcMODEL);
            //lstDir.Add(RES_MODEL_DIR);
            //lstName.Add(RES_MODEL_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.Android);
            //lstCrc.Add(crcEFFECT);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstName.Add(RES_EFFECT_RES_NAME);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.Android);
            //lstCrc.Add(crcTEX);
            //lstDir.Add(RES_TEX_DIR);
            //lstName.Add(RES_TEX_RES_NAME);
            ExportAllResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.Android);

            lstCrc.Add(crcTABLE);
            lstDir.Add(RES_TABLE_DIR);
            lstName.Add(RES_TABLE_RES_NAME);
            ExportXml(RES_ANDROID_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_WIN_DIR, RES_FILE_NAME, BuildTarget.StandaloneWindows);
        }
    }

    ///// <summary>
    ///// ������Դ�ļ�
    ///// </summary>
    //[MenuItem("GameTool/Android/File")]
    //static void ExportAndroidFile()
    //{
    //    if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
    //    ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
    //}

    [MenuItem("GameTool/Android/TABLE")]
    static void ExportAndroidTABLE()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTABLE;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            ExportAllResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_TABLE_DIR, RES_TABLE_PRE, RES_TABLE_RES_NAME, out crcTABLE, BuildTarget.Android);
            lstName.Add(RES_TABLE_RES_NAME);
            lstDir.Add(RES_TABLE_DIR);
            lstCrc.Add(crcTABLE);
            ExportXml(RES_ANDROID_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            //ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
        }
    }

    [MenuItem("GameTool/Android/GUI")]
    static void ExportAndroidGUI()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcGUI;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_GUI_DIR, RES_GUI_PRE, RES_GUI_RES_NAME,out crcGUI, BuildTarget.StandaloneWindows);

            BuildPipeline.PushAssetDependencies();
            List<UnityEngine.Object> lstAsset = new List<UnityEngine.Object>();
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZDHTJW.TTF", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/Font/FZHLJW.TTF", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Common/common.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/_BF/GUI/Property/property.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);

            //icon hero
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM3.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIAvatarM4.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            //icon item
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM1.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM2.prefab", typeof(UnityEngine.Object));
            lstAsset.Add(asset);
            //asset = AssetDatabase.LoadAssetAtPath("Assets/ResourcesWWW/GUIItemM3.prefab", typeof(UnityEngine.Object));
            //lstAsset.Add(asset);

            BuildPipeline.BuildAssetBundle(null, lstAsset.ToArray(), RES_EXP_DIR + RES_ANDROID_DIR + RES_GUI_DIR + "Share.res", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.Android);

            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_GUI_DIR, RES_GUI_PRE, BuildTarget.Android);

            BuildPipeline.PopAssetDependencies();
            //lstName.Add(RES_GUI_RES_NAME);
            //lstDir.Add(RES_GUI_DIR);
            //lstCrc.Add(crcGUI);
            //ExportXml(RES_IOS_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_IOS_DIR, RES_FILE_NAME, BuildTarget.iPhone);
        }
    }

    [MenuItem("GameTool/Android/Model")]
    static void ExportAndroidModel()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcMODEL;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_MODEL_DIR, RES_MODEL_PRE, RES_MODEL_RES_NAME, out crcMODEL, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_MODEL_DIR, RES_MODEL_PRE, BuildTarget.Android);
            //lstName.Add(RES_MODEL_RES_NAME);
            //lstDir.Add(RES_MODEL_DIR);
            //lstCrc.Add(crcMODEL);
            //ExportXml(RES_ANDROID_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
        }
    }

    [MenuItem("GameTool/Android/Effect")]
    static void ExportAndroidEffect()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcEFFECT;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();
            //ExportAllResource(RES_WIN_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, RES_EFFECT_RES_NAME,out crcEFFECT, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_EFFECT_DIR, RES_EFFECT_PRE, BuildTarget.Android);
            //lstName.Add(RES_EFFECT_RES_NAME);
            //lstDir.Add(RES_EFFECT_DIR);
            //lstCrc.Add(crcEFFECT);
            //ExportXml(RES_ANDROID_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
        }
    }

    [MenuItem("GameTool/Android/Tex")]
    static void ExportAndroidTex()
    {
        if (EditorUtility.DisplayDialog("����!!!", "ȷ��Ҫ�����", "��", "����"))
        {
            uint crcTEX;
            List<string> lstName = new List<string>();
            List<string> lstDir = new List<string>();
            List<uint> lstCrc = new List<uint>();

            //ExportAllResource(RES_WIN_DIR + RES_TEX_DIR, RES_TEX_PRE , RES_TEX_RES_NAME , out crcTEX, BuildTarget.StandaloneWindows);
            ExportAllSingleResource(RES_ROOT_DIR, RES_ANDROID_DIR + RES_TEX_DIR, RES_TEX_PRE, BuildTarget.Android);

            //lstName.Add(RES_TEX_RES_NAME);
            //lstDir.Add(RES_TEX_DIR);
            //lstCrc.Add(crcTEX);
            //ExportXml(RES_ANDROID_DIR, RES_FILE_NAME, lstName, lstDir, lstCrc);
            ////ExportFile(RES_ANDROID_DIR, RES_FILE_NAME, BuildTarget.Android);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// ������ԴXML
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="fileName"></param>
    private static void ExportXml(string dir, string fileName , List<string> names , List<string> dirs , List<uint> crcs)
    {
        string pathFile = RES_EXP_DIR + dir + fileName;
        if (!File.Exists(pathFile))
        {
            FileStream tmps = File.Create(pathFile);
            tmps.Close();
        }
        string content = File.ReadAllText(pathFile);

        CXML xml = null;
        if (content != "")
            xml = new CXML(content);
        else
            xml = new CXML();

        for (int i = 0; i < names.Count; i++)
        {
            string key = names[i];
            string pathDir = dirs[i];
            uint crc = crcs[i];
            List<XmlNode> lstNode = xml.GetNodes("res");
            bool exist = false;
            foreach (XmlNode item in lstNode)
            {
                if (xml.ContainNode(item, "name" , key))
                {
                    XmlNode nameItem = xml.GetNode(item, "name");
                    nameItem.InnerText = key;
                    XmlNode versionItem = xml.GetNode(item, "version");
                    versionItem.InnerText = "" + VERSION;
                    XmlNode pathItem = xml.GetNode(item, "path");
                    pathItem.InnerText = RES_LOAD_DIR + dir + pathDir + key + RES_FILE_POST;
                    XmlNode crcItem = xml.GetNode(item, "crc");
                    crcItem.InnerText = "" + crc;
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                XmlNode child = xml.AddNode("res");
                xml.AddNode(child, "name", key);
                xml.AddNode(child, "version", "" + VERSION);
                xml.AddNode(child, "path", RES_LOAD_DIR + dir + pathDir + key + RES_FILE_POST);
                xml.AddNode(child, "crc", ""+crc);
            }
        }

        FileStream fStream = File.Create(pathFile);
        xml.Save(fStream);
        fStream.Flush();
        fStream.Close();
    }

    /// <summary>
    /// ������Դ�ļ�
    /// </summary>
    /// <param name="dir"></param>
    private static void ExportFile(string dir , string fileName , BuildTarget target)
    {
        string pathFile = RES_EXP_DIR + dir + fileName;
        if (File.Exists(pathFile))
        {
            File.Delete(pathFile);
        }

        if (File.Exists(RES_EXP_DIR + dir + fileName.Replace(".txt",RES_FILE_POST)))
        {
            File.Delete(RES_EXP_DIR + dir + fileName.Replace(".txt", RES_FILE_POST));
        }

        string content = "";

        string[] files = Directory.GetFiles(RES_EXP_DIR + dir, "*.res", SearchOption.AllDirectories);
        for (int i = 0; i < files.Length; i++)
        {
            string tmpPath = files[i];
            FileInfo fInfo = new FileInfo(tmpPath);

            //�ų�GUI��Դ
            if (fInfo.Name.Contains("gui"))
                continue;

            byte[] buff = File.ReadAllBytes(tmpPath);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] op = md5.ComputeHash(buff);
            string md5Str = BitConverter.ToString(op).Replace("-", "");

            content += fInfo.Name.Replace(RES_FILE_POST, "");
            content += "," + RES_LOAD_DIR + tmpPath.Replace("\\", "/").Substring(RES_EXP_DIR.Length);
            content += "," + md5Str;
            content += "," + fInfo.Length;
            content += "\n";
        }

        File.WriteAllText(pathFile, content , System.Text.Encoding.UTF8);
        //File.WriteAllText(Application.dataPath + "/Resources/" +fileName, content, System.Text.Encoding.Unicode);
        //AssetDatabase.Refresh();
        //UnityEngine.Object tmpTxt = AssetDatabase.LoadMainAssetAtPath(RES_ROOT_DIR + fileName);
        //ExportResources(tmpTxt, dir, target);

        //File.Move(Application.dataPath + "/Resources/" + fileName, pathFile);
        //AssetDatabase.Refresh();
    }

    ///// <summary>
    ///// �������ϲ���Դ
    ///// </summary>
    ///// <param name="exportDir">����Ŀ¼</param>
    ///// <param name="prefix">����ǰ׺</param>
    ///// <param name="fileName">�����ļ���</param>
    ///// <param name="type">��������</param>
    //private static void ExportAllCacheResource(string exportDir, string prefix, string fileName, out uint crc, BuildTarget buildTarget)
    //{
    //    AssetDatabase.StartAssetEditing();
    //    string dirPath = RES_CACHE_DIR;
    //    DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
    //    if (dirInfo == null)
    //    {
    //        crc = 0;
    //        return;
    //    }
    //    FileInfo[] dirFiles = dirInfo.GetFiles();
    //    if (dirFiles == null)
    //    {
    //        crc = 0;
    //        return;
    //    }

    //    List<UnityEngine.Object> lst = new List<UnityEngine.Object>();

    //    List<string> lstpath = new List<string>();
    //    List<string> lstresName = new List<string>();
    //    string[] tmpJudge = prefix.Split(',');

    //    foreach (FileInfo f in dirFiles)
    //    {
    //        for (int i = 0; i < tmpJudge.Length; i++)
    //        {
    //            string tmpStr = tmpJudge[i];
    //            if ((!f.Name.Contains(".meta")) && f.Name[0] != '_' && f.Name.Substring(0, tmpStr.Length) == tmpStr)
    //            {
    //                string assetPath = dirPath + f.Name;
    //                UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));
    //                if (asset is GameObject)
    //                {
    //                    UnityEngine.Object tmpobj = PrefabUtility.CreateEmptyPrefab(RES_TMP_ROOT_DIR + f.Name);
    //                    GameObject gameObj = UnityEngine.Object.Instantiate(asset) as GameObject;
    //                    asset = PrefabUtility.ReplacePrefab(gameObj, tmpobj);
    //                    UnityEngine.Object.DestroyImmediate(gameObj);
    //                    lstpath.Add(RES_TMP_ROOT_DIR + f.Name);
    //                }
    //                if (asset == null)
    //                {
    //                    Debug.LogError("null asset : " + assetPath);
    //                    continue;
    //                }
    //                lst.Add(asset);
    //                lstresName.Add(asset.name);
    //                break;
    //            }
    //        }
    //    }
    //    ExportResources(lst.ToArray(), lstresName.ToArray(), exportDir, fileName, out crc, buildTarget);

    //    foreach (string item in lstpath)
    //    {
    //        AssetDatabase.DeleteAsset(item);
    //    }

    //    AssetDatabase.StopAssetEditing();
    //    AssetDatabase.Refresh();
    //}

    /// <summary>
    /// �������ϲ���Դ
    /// </summary>
    /// <param name="exportDir">����Ŀ¼</param>
    /// <param name="prefix">����ǰ׺</param>
    /// <param name="fileName">�����ļ���</param>
    /// <param name="type">��������</param>
    private static void ExportAllResource( string res_root , string exportDir , string prefix , string fileName , out uint crc , BuildTarget buildTarget)
    {
        AssetDatabase.StartAssetEditing();
        //string dirPath = RES_ROOT_DIR;
        string dirPath = res_root;
        DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
        if (dirInfo == null)
        {
            crc = 0;
            return;
        }
        FileInfo[] dirFiles = dirInfo.GetFiles();
        if (dirFiles == null)
        {
            crc = 0;
            return;
        }

        List<UnityEngine.Object> lst = new List<UnityEngine.Object>();

        List<string> lstpath = new List<string>();
        List<string> lstresName = new List<string>();
        string[] tmpJudge = prefix.Split(',');

        foreach (FileInfo f in dirFiles)
        {
            for (int i = 0; i < tmpJudge.Length; i++)
            {
                string tmpStr = tmpJudge[i];
                if ((!f.Name.Contains(".meta")) && f.Name[0] != '_' && f.Name.Substring(0, tmpStr.Length) == tmpStr)
                {
                    string assetPath = dirPath + f.Name;
                    UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(assetPath , typeof(UnityEngine.Object));
                    //UnityEngine.Object asset = AssetDatabase.LoadMainAssetAtPath(assetPath);
                    //UnityEngine.Object asset = Resources.Load(f.Name.Split('.')[0]);
                    //AssetDatabase.CreateAsset(asset, RES_TMP_ROOT_DIR + f.Name);
                    if (asset is GameObject)
                    {
                        UnityEngine.Object tmpobj = PrefabUtility.CreateEmptyPrefab(RES_TMP_ROOT_DIR + f.Name);
                        GameObject gameObj = UnityEngine.Object.Instantiate(asset) as GameObject;
                        asset = PrefabUtility.ReplacePrefab(gameObj, tmpobj);
                        UnityEngine.Object.DestroyImmediate(gameObj);
                        lstpath.Add(RES_TMP_ROOT_DIR + f.Name);
                    }
                    if (asset == null)
                    {
                        Debug.LogError("null asset : " + assetPath);
                        continue;
                    }
                    lst.Add(asset);
                    lstresName.Add(asset.name);
                    break;
                }
            }
        }
        ExportResources(lst.ToArray(), lstresName.ToArray(), exportDir, fileName, out crc, buildTarget);

        foreach (string item in lstpath)
        {
            AssetDatabase.DeleteAsset(item);
        }

        AssetDatabase.StopAssetEditing();
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// �������е�����Դ
    /// </summary>
    /// <param name="exportDir">����Ŀ¼</param>
    /// <param name="prefix">����ǰ׺</param>
    /// <param name="fileName">�����ļ���</param>
    /// <param name="type">��������</param>
    private static void ExportAllSingleResource( string res_root_dir , string exportDir, string prefix, BuildTarget buildTarget)
    {
        //AssetDatabase.StartAssetEditing();
        //string dirPath = RES_ROOT_DIR;
        string dirPath = res_root_dir;
        DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
        if (dirInfo == null)
        {
            return;
        }
        FileInfo[] dirFiles = dirInfo.GetFiles();
        if (dirFiles == null)
        {
            return;
        }

        List<UnityEngine.Object> lst = new List<UnityEngine.Object>();

        List<string> lstpath = new List<string>();
        List<string> lstresName = new List<string>();
        string[] tmpJudge = prefix.Split(',');

        foreach (FileInfo f in dirFiles)
        {
            for (int i = 0; i < tmpJudge.Length; i++)
            {
                string tmpStr = tmpJudge[i];
                if ((!f.Name.Contains(".meta")) && f.Name[0] != '_' && f.Name.Substring(0, tmpStr.Length) == tmpStr)
                {
                    string assetPath = dirPath + f.Name;
                    UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));
                    if (asset is GameObject)
                    {
                        UnityEngine.Object tmpobj = PrefabUtility.CreateEmptyPrefab(RES_TMP_ROOT_DIR + f.Name);
                        GameObject gameObj = UnityEngine.Object.Instantiate(asset) as GameObject;
                        asset = PrefabUtility.ReplacePrefab(gameObj, tmpobj);
                        UnityEngine.Object.DestroyImmediate(gameObj);
                        lstpath.Add(RES_TMP_ROOT_DIR + f.Name);
                    }
                    if (asset == null)
                    {
                        Debug.LogError("null asset : " + assetPath);
                        continue;
                    }
                    lst.Add(asset);
                    lstresName.Add(asset.name);
                    break;
                }
            }
        }

        for (int i = 0; i < lst.Count; i++)
        {
            uint crc = 1;
            ExportResources(lst[i], exportDir, out crc, buildTarget);
        }

        foreach (string item in lstpath)
        {
            AssetDatabase.DeleteAsset(item);
        }

        //AssetDatabase.StopAssetEditing();
        AssetDatabase.Refresh();
    }

    ///// <summary>
    ///// �ֱ𵼳�������Դ
    ///// </summary>
    ///// <param name="exportDir">����Ŀ¼</param>
    ///// <param name="prefix">ǰ׺</param>
    ///// <param name="buildTarget">����Ŀ��</param>
    //private static void ExportAllResource(string exportDir, string prefix, BuildTarget buildTarget)
    //{
    //    string dirPath = RES_ROOT_DIR;
    //    DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
    //    if (dirInfo == null) return;
    //    FileInfo[] dirFiles = dirInfo.GetFiles();
    //    if (dirFiles == null) return;

    //    foreach (FileInfo f in dirFiles)
    //    {
    //        if ((!f.Name.Contains(".meta")) && f.Name[0] != '_' && f.Name.Substring(0, prefix.Length) == prefix)
    //        {
    //            string assetPath = dirPath + f.Name;
    //            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath(assetPath , typeof(UnityEngine.Object));
    //            if (asset == null)
    //            {
    //                Debug.LogError("null asset : " + assetPath);
    //                continue;
    //            }
    //            ExportResources(asset, exportDir, buildTarget);
    //        }
    //    }
    //}

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="asset"></param>
    private static void ExportResources(UnityEngine.Object asset, string pathDir , out uint crc, BuildTarget buildTarget)
    {
        if (!Directory.Exists(RES_EXP_DIR))
            Directory.CreateDirectory(RES_EXP_DIR);
        if (!Directory.Exists(RES_EXP_DIR + pathDir))
            Directory.CreateDirectory(RES_EXP_DIR + pathDir);

        crc = 1;
        string path = RES_EXP_DIR + pathDir + asset.name + RES_FILE_POST;

        if (File.Exists(path))
            File.Delete(path);

        BuildPipeline.PushAssetDependencies();
        BuildPipeline.BuildAssetBundle(asset , new UnityEngine.Object[]{} , path , BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DisableWriteTypeTree, buildTarget);
        BuildPipeline.PopAssetDependencies();
    }

    /// <summary>
    /// ������Դ��
    /// </summary>
    /// <param name="assets"></param>
    /// <param name="pathDir"></param>
    /// <param name="buildTarget"></param>
    private static void ExportResources(UnityEngine.Object[] assets , string[] assetNames, string pathDir, string fileName , out uint crc , BuildTarget buildTarget)
    {
        if (!Directory.Exists(RES_EXP_DIR))
            Directory.CreateDirectory(RES_EXP_DIR);
        if (!Directory.Exists(RES_EXP_DIR+pathDir))
            Directory.CreateDirectory(RES_EXP_DIR+pathDir);

        string path = RES_EXP_DIR + pathDir + fileName + RES_FILE_POST;

        if (File.Exists(path))
            File.Delete(path);

        Debug.Log("======================== " + path + " =================");

        crc = 1;
        BuildPipeline.PushAssetDependencies();
        BuildPipeline.BuildAssetBundleExplicitAssetNames(assets,assetNames, path , BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DisableWriteTypeTree, buildTarget);
        BuildPipeline.PopAssetDependencies();
    }

    // ========================================================================================================== //

    [MenuItem("GameTool/��������WIN��Դ")]
    public static void ExportSingleWinObject()
    {
        UnityEngine.Object asset = Selection.activeObject;

        string path = EditorUtility.SaveFilePanel("Save Path", "", "", "res");
        BuildPipeline.PushAssetDependencies();
        BuildPipeline.BuildAssetBundle(asset, new UnityEngine.Object[] { }, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.StandaloneWindows);
        BuildPipeline.PopAssetDependencies();

        //UnityEngine.Object[] selectObjects = Selection.objects;
        //if (selectObjects == null)
        //    return;

        //string[] objNames = new string[selectObjects.Length];
        //for (int i = 0; i<objNames.Length ; i++ )
        //{
        //    objNames[i] = selectObjects[i].name;
        //    Debug.Log(objNames[i]);
        //}
        //string path = EditorUtility.SaveFilePanel("Save Path", "", "" , "res");

        //if (path.Length == 0 || path == null)
        //    return;

        ////���
        //BuildPipeline.PushAssetDependencies();
        ////BuildPipeline.BuildAssetBundle(null, selectObjects, path , BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets , BuildTarget.StandaloneWindows64);
        //BuildPipeline.BuildAssetBundleExplicitAssetNames(selectObjects, objNames, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets , BuildTarget.StandaloneWindows);
        //BuildPipeline.PopAssetDependencies();
        //AssetDatabase.Refresh();
        //Debug.Log("Success.");
        ////����
        //string fileName = Game.Utility.UtilityFunction.GetFileNameByPath(path);
        //byte[] datas = CFile.ReadAllBytes(path);
        //datas = CEncrypt.EncryptBytes(datas);
        //CFile.Write(Application.dataPath + "/" + fileName + ".bytes", datas);
        //Object[] objs = new Object[1];
        //AssetDatabase.Refresh();
        //objs[0] = AssetDatabase.LoadMainAssetAtPath("Assets/" + fileName + ".bytes");

        ////���´��
        //BuildPipeline.PushAssetDependencies();
        //BuildPipeline.BuildAssetBundle(objs[0], null, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
        //BuildPipeline.PopAssetDependencies();

        ////ɾ����ʱ�ļ�
        //AssetDatabase.DeleteAsset("Assets/" + fileName + ".bytes");
        //AssetDatabase.Refresh();
    }

    [MenuItem("GameTool/��������Android��Դ")]
    public static void ExportSingleAndroidObject()
    {
        UnityEngine.Object asset = Selection.activeObject;

        string path = EditorUtility.SaveFilePanel("Save Path", "", "", "res");
        BuildPipeline.PushAssetDependencies();
        BuildPipeline.BuildAssetBundle(asset, new UnityEngine.Object[] { }, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.Android);
        BuildPipeline.PopAssetDependencies();

        //UnityEngine.Object[] selectObjects = Selection.objects;
        //if (selectObjects == null)
        //    return;

        //string[] objNames = new string[selectObjects.Length];
        //for (int i = 0; i < objNames.Length; i++)
        //{
        //    objNames[i] = selectObjects[i].name;
        //    Debug.Log(objNames[i]);
        //}
        //string path = EditorUtility.SaveFilePanel("Save Path", "", "", "res");

        //if (path.Length == 0 || path == null)
        //    return;

        ////���
        //BuildPipeline.PushAssetDependencies();
        ////BuildPipeline.BuildAssetBundle(null, selectObjects, path , BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets , BuildTarget.StandaloneWindows64);
        //BuildPipeline.BuildAssetBundleExplicitAssetNames(selectObjects, objNames, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
        //BuildPipeline.PopAssetDependencies();
        //AssetDatabase.Refresh();
        //Debug.Log("Success.");
        ////����
        //string fileName = Game.Utility.UtilityFunction.GetFileNameByPath(path);
        //byte[] datas = CFile.ReadAllBytes(path);
        //datas = CEncrypt.EncryptBytes(datas);
        //CFile.Write(Application.dataPath + "/" + fileName + ".bytes", datas);
        //Object[] objs = new Object[1];
        //AssetDatabase.Refresh();
        //objs[0] = AssetDatabase.LoadMainAssetAtPath("Assets/" + fileName + ".bytes");

        ////���´��
        //BuildPipeline.PushAssetDependencies();
        //BuildPipeline.BuildAssetBundle(objs[0], null, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
        //BuildPipeline.PopAssetDependencies();

        ////ɾ����ʱ�ļ�
        //AssetDatabase.DeleteAsset("Assets/" + fileName + ".bytes");
        //AssetDatabase.Refresh();
    }

    [MenuItem("GameTool/��������IOS��Դ")]
    public static void ExportSingleIOSObject()
    {
        UnityEngine.Object asset = Selection.activeObject;

        string path = EditorUtility.SaveFilePanel("Save Path", "", "", "res");
        BuildPipeline.PushAssetDependencies();
        BuildPipeline.BuildAssetBundle(asset, new UnityEngine.Object[] { }, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.DisableWriteTypeTree , BuildTarget.iPhone);
        BuildPipeline.PopAssetDependencies();

        //UnityEngine.Object[] selectObjects = Selection.objects;
        //if (selectObjects == null)
        //    return;

        //string[] objNames = new string[selectObjects.Length];
        //for (int i = 0; i < objNames.Length; i++)
        //{
        //    objNames[i] = selectObjects[i].name;
        //    Debug.Log(objNames[i]);
        //}
        //string path = EditorUtility.SaveFilePanel("Save Path", "", "", "res");

        //if (path.Length == 0 || path == null)
        //    return;

        ////���
        //BuildPipeline.PushAssetDependencies();
        ////BuildPipeline.BuildAssetBundle(null, selectObjects, path , BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets , BuildTarget.StandaloneWindows64);
        //BuildPipeline.BuildAssetBundleExplicitAssetNames(selectObjects, objNames, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.iPhone);
        //BuildPipeline.PopAssetDependencies();
        //AssetDatabase.Refresh();
        //Debug.Log("Success.");

        ////����
        //string fileName = Game.Utility.UtilityFunction.GetFileNameByPath(path);
        //byte[] datas = CFile.ReadAllBytes(path);
        //datas = CEncrypt.EncryptBytes(datas);
        //CFile.Write(Application.dataPath + "/" + fileName + ".bytes", datas);
        //Object[] objs = new Object[1];
        //AssetDatabase.Refresh();
        //objs[0] = AssetDatabase.LoadMainAssetAtPath("Assets/" + fileName + ".bytes");

        ////���´��
        //BuildPipeline.PushAssetDependencies();
        //BuildPipeline.BuildAssetBundle(objs[0], null, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
        //BuildPipeline.PopAssetDependencies();

        ////ɾ����ʱ�ļ�
        //AssetDatabase.DeleteAsset("Assets/" + fileName + ".bytes");
        //AssetDatabase.Refresh();
    }

    //[MenuItem("GameTool/Export All Resources")]
    //static void ExportAllResources()
    //{
    //    //string path = EditorUtility.SaveFolderPanel("Select Folder", "", "");
    //    //if (path.Length == 0)
    //    //    return;

    //    //DirectoryInfo dirInfo = new DirectoryInfo(path);
    //    //if (dirInfo == null) return;

    //    //FileInfo[] dirFiles = dirInfo.GetFiles();
    //    //if (dirFiles == null) return;

    //    //DirectoryInfo[] dirs = dirInfo.GetDirectories();



    //    //foreach (FileInfo item in dirFiles)
    //    //{ 
    //    //}

    //    Debug.Log(PrefabUtility.GetPrefabParent(Selection.activeObject).name);

    //    return;
    //}

}
