using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class ConfigTools : ScriptableWizard
{
    public int _Total;
    [MenuItem("Tools/ConfigLogoImages")]
    private static void ConfigLogoImages()
    {
        ScriptableWizard.DisplayWizard<ConfigTools>("Input Array Size...", "Run", "Cancel");
    }

    void OnWizardCreate()
    {
        int total = _Total;

        GameObject obj = GameObject.Find("LogoPlyer");

        for (int i = 0; i < total; ++i)
        {
            string no = string.Format("{0:D5}", i);
            string path = "LogoScene/Logo/Logo Sting White with Shadow_" + no;
            obj.GetComponent<LogoMgr>()._Sprites[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }

    void OnWizardOtherButton()
    {
    }

    [MenuItem("Tools/PackageAssetBundle")]
    private static void PackageAssetBundle()
    {
        Debug.Log("Packaging AssetBundle...");
        string packagePath = UnityEditor.EditorUtility.OpenFolderPanel("Select Package Path", "", "");
        if (packagePath.Length <= 0 || !Directory.Exists(packagePath))
            return;
        Debug.Log("Output Path: " + packagePath);
        BuildPipeline.BuildAssetBundles(packagePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
    }
}