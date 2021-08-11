using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using ConfigData;

namespace ZFramework
{
    public static class EditorConfigData
    {
        private static string CONFIG_DATA_PATH;
        private const string DATA_SUFFIX = ".bytes";
        private static Dictionary<string, IConfig> dataMap = new Dictionary<string, IConfig>();

        public static void Init()
        {
            dataMap.Clear();
            dataMap.Add("UI_Data", new UI_Data());
        }

        public static void LoadEditorData()
        {
            foreach (string fileName in ConfigData.DataCfg.editorDataNameList)
            {
                using (FileStream fs = new FileStream(Path.Combine(CONFIG_DATA_PATH, fileName + DATA_SUFFIX), FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    using (MemoryStream stream = new MemoryStream(bytes))
                    {
                        using (CryptoStream cs = new CryptoStream(stream, UEncrypt.Instance.decoder, CryptoStreamMode.Read))
                        {
                            using (BinaryReader br = new BinaryReader(cs, Encoding.UTF8))
                            {
                                IConfig Data = GetDataByName(fileName);
                                if (Data != null)
                                {
                                    Data.MergeFrom(br);
                                    MDebug.Log(string.Format("LoadData Successed : {0}", fileName));
                                }
                            }
                        }
                    }
                }
            }
        }

        public static IConfig GetDataByName(string fileName)
        {
            string fullName = fileName + "_Data";
            if (dataMap.ContainsKey(fullName))
            {
                return dataMap[fullName];
            }
            else
            {
                MDebug.LogErr(string.Format("Get DataFile Failed : {0}.", fileName));
                return null;
            }
        }
    }

}
