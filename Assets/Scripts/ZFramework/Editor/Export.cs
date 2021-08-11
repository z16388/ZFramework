using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
public class ExportUnityPackage
{
#if UNITY_EDITOR
    [MenuItem("ZFramework/ExportFramework", false, 100000)]
    private static void MenuClicked()
    {
        string assetPathName = "Assets/Scripts";
        string fileName = "ZFramework_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".unitypackage";
        AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        Application.OpenURL("file:///" + Application.dataPath + "/../");
    }
#endif
}