using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZFramework
{
    public class Global: MonoBehaviourSimplify
    {
        public static GameObject UIRoot;
        public static GameObject MainCameraObj;
        public static AudioListener audioListener;
        public static GameObject mainObject;

        public static Device Device;
        public static UHelper UHelper;
        public static UIHelper UIHelper;
        public static AudioHelper AudioHelper;

        public static UMath UMath;

        public static ConfigData.DataCfg DataCfg;

        private Global()
        {
        }

        private void Awake()
        {
        }

        private void Start()
        {
            mainObject = gameObject;
            UIRoot = GameObject.Find("UIRoot");
            MainCameraObj = GameObject.Find("Main Camera");
            audioListener = transform.GetComponent<AudioListener>();
            MainCameraObj.SetActive(false);

            DataCfg = new ConfigData.DataCfg();
            DataCfg.LoadBaseData();

            Device = new Device();
            UHelper = new UHelper();
            UIHelper = new UIHelper();
            AudioHelper = new AudioHelper();
            UMath = new UMath();

            RegisterMessages();
            ShowSplash();
        }

        private void RegisterMessages()
        {
            RegisterMsg(Messages.Common.StartGame, OnStartGame);
        }

        private void OnStartGame(object obj)
        {
            UIHelper.Close<UI_SplashUI>();
            //UIPackage.RemovePackage("UI/Splash");
            StartGame();
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Game");
            UIHelper.Open<UI_MainUI>();
            UIHelper.Close<UI_SplashUI>();
        }

        private void ShowSplash()
        {
            UIHelper.Open<UI_SplashUI>();
        }

        protected override void VDestroy()
        {
            
        }
    }
}
