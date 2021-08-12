using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public abstract partial class MonoBehaviourSimplify
    {
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

        private void OnDestroy()
        {
            VDestroy();

            foreach (var msgRecord in mListMsgRecord)
            {
                MsgHelper.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }

            mListMsgRecord.Clear();
        }

        protected abstract void VDestroy();
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
    }
}
