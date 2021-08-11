using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ZFramework
{
    [SerializeField]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private string version;

        [SerializeField]
        public EGameMode GameMode;

        [SerializeField]
        private ELogLevel logLevel;

        [SerializeField]
        private int screenWeight;

        [SerializeField]
        private int screenHeight;

        private static GameSettings instance;
        public static GameSettings Instance
        {
            get
            {
                instance = Resources.Load("GameSettings") as GameSettings;
                if (instance == null)
                {
                    instance = CreateInstance<GameSettings>();
#if UNITY_EDITOR
                    string properPath = "Assets/Scripts/ZFramework";
                    if (!Directory.Exists(Path.Combine(properPath, "Resources")))
                    {
                        AssetDatabase.CreateFolder(properPath, "Resources");
                    }
                    string fullPath = Path.Combine(Path.Combine(properPath, "Resources"), "GameSettings.asset");
                    AssetDatabase.CreateAsset(instance, fullPath);
#endif
                }
                return instance;
            }
        }

        public string Version
        {
            get
            {
                if (string.IsNullOrEmpty(version))
                {
                    version = "0.0.1";
                }
                return version;
            }
            set => version = value;
        }

        public ELogLevel LogLevel
        {
            get => logLevel;
            set
            {
                logLevel = value;
                MDebug.Log(string.Format("Switch Log Level To : {0}. {1}", (int)value, value.ToString()));
            }
        }

        public int ScreenWeight { 
            get
            { 
                if (screenWeight == 0)
                {
                    screenWeight = 2340;
                }
                return screenWeight;
            } 
            set => screenWeight = value; 
        }
        public int ScreenHeight {
            get
            {
                if (screenHeight == 0)
                {
                    screenHeight = 1080;
                }
                return screenHeight;
            }
            set => screenHeight = value; 
        }

        public enum EGameMode
        {
            Develop,
            Release
        }

        public enum ELogLevel
        {
            All,
            DevInfo,
            DevError,
            GameInfo,
            GameWarn,
            GameError
        }
    }
}
