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
        /// ����ǰ�� ��Ҫ����Ѱ��view�ϵ����
        /// </summary>
        public virtual void OnBeforeCreate()
        {

        }

        /// <summary>
        /// ��Ӽ����¼�
        /// </summary>
        public virtual void AddListener()
        {

        }

        /// <summary>
        /// ɾ������¼�
        /// </summary>
        public virtual void RemoveListener()
        {

        }

        /// <summary>
        /// �����ɹ� ��Ҫ�����߼�ע��
        /// </summary>
        public virtual void OnCreate()
        {

        }

        /// <summary>
        /// ���ڻ�������ĵڶ������ϴ�
        /// </summary>
        public virtual void OnRefresh()
        {

        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual void OnHide()
        {

        }

        /// <summary>
        /// ��������
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