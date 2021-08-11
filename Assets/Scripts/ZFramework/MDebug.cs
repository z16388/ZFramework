using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public static class MDebug
    {
        public static void Log(string log)
        {
            if (GameSettings.Instance.LogLevel <= GameSettings.ELogLevel.GameInfo)
            {
                Debug.Log(string.Format("[info]:{0}", log));
            }
        }
        
        public static void LogWarn(string log)
        {
            if (GameSettings.Instance.LogLevel <= GameSettings.ELogLevel.GameWarn)
            {
                Debug.LogWarning(string.Format("[warn]:{0}", log));
            }  
        }

        public static void LogErr(string log)
        {
            if (GameSettings.Instance.LogLevel <= GameSettings.ELogLevel.GameError)
            {
                Debug.LogError(string.Format("[error]:{0}", log));
            }
        }

        public static void LogDev(string log)
        {
#if UNITY_EDITOR
            if (GameSettings.Instance.LogLevel <= GameSettings.ELogLevel.DevInfo)
            {
                Debug.LogWarning(string.Format("[dev]:{0}", log));
            }
#endif
        }

        public static void LogDevErr(string log)
        {
#if UNITY_EDITOR
            if (GameSettings.Instance.LogLevel <= GameSettings.ELogLevel.DevError)
            {
                Debug.LogError(string.Format("[dev]:{0}", log));
            }  
#endif
        }
    }
}
