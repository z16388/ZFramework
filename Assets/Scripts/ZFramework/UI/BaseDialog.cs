using FairyGUI;
using System;
using System.Collections.Generic;

namespace ZFramework
{
    public class BaseDialog
    {

        protected GComponent _view;
        public int instanceId;
        private DialogInfo _info;
        private object _data;
        List<MsgRecord> mListMsgRecord = new List<MsgRecord>();

        private class MsgRecord
        {
            private static readonly Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();
            public string Name;
            public Action<object> OnMsgReceived;

            public static MsgRecord Init(string msgName, Action<object> onMsgReceiced)
            {
                MsgRecord retMsgRecord = null;

                retMsgRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop() : new MsgRecord();
                retMsgRecord.Name = msgName;
                retMsgRecord.OnMsgReceived = onMsgReceiced;

                return retMsgRecord;
            }

            public void Recycle()
            {
                Name = null;
                OnMsgReceived = null;
                mMsgRecordPool.Push(this);
            }
        }

        protected void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgHelper.Register(msgName, onMsgReceived);
            mListMsgRecord.Add(MsgRecord.Init(msgName, onMsgReceived));
        }

        protected void UnRegisterMsg(string msgName)
        {
            var targetRecords = mListMsgRecord.FindAll(recorder => recorder.Name == msgName);

            if (targetRecords != null)
            {
                targetRecords.ForEach(record =>
                {
                    MsgHelper.UnRegister(record.Name, record.OnMsgReceived);
                    mListMsgRecord.Remove(record);
                });

                targetRecords.Clear();
            }
        }

        protected void SendMsg(string msgName, object data = null)
        {
            MsgHelper.Send(msgName, data);
        }

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

        //public void SetDialogType(DialogType dialogType)
        //{
        //    _dialogType = dialogType;
        //}

        public GComponent GetView()
        {
            return _view;
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
        public virtual void OnDestory()
        {
            foreach (var msgRecord in mListMsgRecord)
            {
                MsgHelper.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }

            mListMsgRecord.Clear();
        }

        public void Update()
        {

        }
    }
}