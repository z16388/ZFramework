using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class Global: MonoBehaviour
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
        }
    }
}
