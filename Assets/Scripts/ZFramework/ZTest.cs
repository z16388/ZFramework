using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework;
using UnityEngine.UI;

public class ZTest : MonoBehaviourSimplify
{
    public void Awake()
    {
        MsgHelper.Register(Messages.Common.Test, DoTest);
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            MsgHelper.Send(Messages.Common.Test);
        }
#endif
    }

    private void DoTest(object data)
    {
#if UNITY_EDITOR
        MDebug.LogDev("Do Test");

        UIHelper.TestUI();
        //Global.AudioHelper.PlaySound("Test");
        //Global.AudioHelper.PlayBGM("bgm");
#endif
    }

    private void OnDestroy()
    {
        MsgHelper.UnRegisterAll(Messages.Common.Test);
    }

    //override protected void VDestroy()
    //{
    //    UnRegisterMsg(Messages.Common.Test);
    //}
}
