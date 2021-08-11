using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class Main : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<Global>();
        }
    }
}
