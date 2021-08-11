using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class Device
    {
        public bool isLandscape;
        public float aspect;

        public Device()
        {
            isLandscape = Screen.width > Screen.height;
            aspect = isLandscape ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
        }
    }

}
