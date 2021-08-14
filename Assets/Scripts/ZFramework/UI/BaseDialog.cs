using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class BaseDialog: MonoBehaviourSimplify
    {
        protected GComponent _view;
        public int instanceId;
        private DialogInfo _info;
        private object _data;

        public object Data { get => _data; set => _data = value; }

        public BaseDialog()
        {

        }

        public void SetDialogView(GComponent view)
        {
            _view = view;
        }

        public void SetDialogInfo(DialogInfo info)
        {
            _info = info;
        }

        public DialogInfo GetDialogInfo()
        {
            return _info;
        }

        public GComponent GetView()
        {
            return _view;
        }

        public GObject GetViewObject()
        {
            string name = _info.GetDialogName();
            return GRoot.inst.GetChild(name);
        }

        /// <summary>
        /// 创建前期 主要用于寻找view上的组件
        /// </summary>
        public virtual void OnBeforeCreate()
        {

        }

        /// <summary>
        /// 添加监听事件
        /// </summary>
        public virtual void AddListener()
        {

        }

        /// <summary>
        /// 删除添加事件
        /// </summary>
        public virtual void RemoveListener()
        {

        }

        /// <summary>
        /// 创建成功 主要用于逻辑注册
        /// </summary>
        public virtual void OnCreate()
        {

        }

        /// <summary>
        /// 用于缓存界面后的第二次以上打开
        /// </summary>
        public virtual void OnRefresh()
        {

        }

        /// <summary>
        /// 界面隐藏
        /// </summary>
        public virtual void OnHide()
        {

        }

        /// <summary>
        /// 界面销毁
        /// </summary>
        public virtual void OnDestroy()
        {

        }

        protected override void VDestroy()
        {
            
        }

        public void SetBtnAction(GButton btn, EventCallback0 onBtnClick = null)
        {
            btn.sound = (NAudioClip)UIPackage.GetItemAssetByURL("ui://Main/click");
            btn.onClick.Set(onBtnClick);
        }

        public void Close()
        {
            string name = _info.GetDialogName();
            Component target = Global.UIRoot.GetComponent("UI_" + name);
            Destroy(target);

            GetViewObject().visible = false;
        }
    }
}