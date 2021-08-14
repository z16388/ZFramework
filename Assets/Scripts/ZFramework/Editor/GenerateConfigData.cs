using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ZFramework
{
    public class GenerateConfigData
    {
#if UNITY_EDITOR
        //private static string batPath = Path.Combine(Application.dataPath, "../../data/Tool/");
        //private static string runParam = string.Format("-e ./ -b ./Resources/Data -i {0} -c ./Data", batPath);
        private static string batPath = Path.Combine(Application.dataPath, "../../cehua/Data/");

        [MenuItem("ZFramework/生成配置表", false, 1)]
        private static void GenerateData()
        {
            //string fullName = Path.Combine(batPath, "ExcelTool.exe");
            string targetName = "导出配置表.bat";
            if (File.Exists(Path.Combine(batPath, targetName)))
            {
                //runProcess(fullName, runParam);
                runBat(batPath, targetName);
            }
            else
            {
                UnityEngine.Debug.LogError("找不到生成工具");
            }
        }

        private static void runBat(string targetDir, string targetName)
        {
            Process proc = new Process();

            proc.StartInfo.WorkingDirectory = targetDir;
            proc.StartInfo.FileName = targetName;

            proc.Start();
            proc.WaitForExit();
        }

        //private static int runProcess(string fileName, string appParam)
        //{
        //    int returnValue = -1;
        //    try
        //    {
        //        Process myProcess = new Process();
        //        ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(fileName);
        //        myProcessStartInfo.CreateNoWindow = true;
        //        myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //        myProcess.StartInfo = myProcessStartInfo;
        //        myProcess.StartInfo.UseShellExecute = false;
        //        myProcess.StartInfo.CreateNoWindow = false;
        //        myProcess.Start();

        //        while (!myProcess.HasExited)
        //        {
        //            myProcess.WaitForExit();
        //        }

        //        returnValue = myProcess.ExitCode;
        //        myProcess.Dispose();
        //        myProcess.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        UnityEngine.Debug.LogError(ex.Message.ToString());
        //    }
        //    return returnValue;
        //}
#endif
    }
}

