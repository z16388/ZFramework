using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;
using ZFramework;

namespace ZUI.Main
{
    public class UI_TestUI : BaseDialog
    {
        public GButton btn;
        public override void OnBeforeCreate()
        {
            btn = (GButton)_view.GetChild("btn_test");
            RegisterMsg("Test", OnMsg);
        }

        public override void OnCreate()
        {
            base.OnCreate();
            btn.onClick.Set(OnBtnClick);
        }

        public void OnBtnClick()
        {
            SendMsg("Test");
        }

        private void OnMsg(object data)
        {
            MDebug.LogDevErr("Msg CLose");
            UIHelper.Close<UI_TestUI>();
        }
    }
}