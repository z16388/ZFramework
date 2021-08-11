using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ConfigData;

namespace ZFramework
{
    public class GenerateUICode
    {
        private static UI_Data data;

        [MenuItem("ZFramework/Éú³ÉUI´úÂë", false, 101)]
        private static void GenUI()
        {
            EditorConfigData.Init();
            EditorConfigData.LoadEditorData();

            data = (UI_Data)EditorConfigData.GetDataByName("UI");

            //GenAllPackage();
            //GenAllUI();
        }

        private static void GenAllPackage()
        {

        }

        private static void GenAllUI()
        {

        }
    }
}
