using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class MsgHelper
    {
        public MsgHelper()
        {

        }

        private static Dictionary<string, Action<object>> RegisteredMsgs = new Dictionary<string, Action<object>>();

        public static void Register(string msgName, Action<object> onMsgReceiced)
        {
            if (!RegisteredMsgs.ContainsKey(msgName))
            {
                RegisteredMsgs.Add(msgName, _ => { });
            }

            RegisteredMsgs[msgName] += onMsgReceiced;
        }

        public static void UnRegisterAll(string msgName)
        {
            if (RegisteredMsgs.ContainsKey(msgName))
            {
                RegisteredMsgs.Remove(msgName);
                MDebug.LogDev(string.Format("UnRegisterAll Msg Successed.Name is : {0}", msgName));
            }
            else
            {
                MDebug.LogDevErr(string.Format("UnRegisterAll Msg Name Not Found: {0}.", msgName));
            }
        }

        public static void UnRegister(string msgName, Action<object> onMsgReceived)
        {
            if (RegisteredMsgs.ContainsKey(msgName))
            {
                RegisteredMsgs[msgName] -= onMsgReceived;
                MDebug.LogDev(string.Format("UnRegister Msg Successed.Name is : {0}", msgName));
            }
            else
            {
                MDebug.LogDevErr(string.Format("UnRegister Msg Name Not Found: {0}.", msgName));
            }
        }

        public static void Send(string msgName, object data = null)
        {
            if (RegisteredMsgs.ContainsKey(msgName))
            {
                MDebug.Log(string.Format("Send Msg : {0}", msgName));
                RegisteredMsgs[msgName](data);
            }
            else
            {
                MDebug.LogDevErr(string.Format("Send Msg Name Not Found: {0}.", msgName));
            }
        }
    }
}

