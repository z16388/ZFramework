using System;
using System.Collections.Generic;
using FairyGUI;

namespace ZFramework

{
    ///
    /// 
    /// һЩ����
    /// ������֪ͨ�����ʾ
    /// ������֪ͨ���ȡ��
    ///
    /// ==���¼�==����װһЩ����
    ///
    /// 1. �¼���װ����
    /// 2. ������� ==������ʱ��ѭ����飬ѭ�����̫����
    ///
    /// && ���һ��ˢ�µ�Ƶ�αȳ�ʼ����Ƶ��Ҫ��
    /// ���Դ洢�ĵط�����List������Map

    public class RedDotManager
    {
        public bool AddRedDot<T>(GObject redDotObj) where T : RedDotConditionChecker, new()
        {
            if (redDotObj == null) return false;

            var data = _nodes.Find(a => a.GetType() == typeof(T));
            if (data == null)
            {
                data = new RedDotNode(new T());
                _nodes.Add(data);
            }

            return data.AddObj(redDotObj);
        }

        public void RemoveRedDot<T>(GObject redDotObj) where T : RedDotConditionChecker
        {
            if (redDotObj == null) return;

            var dataIndex = _nodes.FindIndex(a => a.GetType() == typeof(T));
            if (dataIndex < 0) return;

            var data = _nodes[dataIndex];
            data.RemoveObj(redDotObj);
            if (data.GetObjCount() <= 0)
            {
                _nodes.RemoveAt(dataIndex);
            }
        }

        public void RemoveRedDotAll(GObject obj)
        {
            if (obj == null) return;

            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                _nodes[i].RemoveObj(obj);
                if (_nodes[i].GetObjCount() <= 0)
                {
                    _nodes.RemoveAt(i);
                }
            }
        }

        public void Refresh()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes[i].Refresh();
            }
        }

        private List<RedDotNode> _nodes = new List<RedDotNode>();

        class RedDotNode
        {
            public RedDotNode(RedDotConditionChecker redDotConditionChecker)
            {
                _redDotConditionChecker = redDotConditionChecker;
            }

            public void Refresh()
            {
                bool isShow = _redDotConditionChecker.CheckIsShow();

                for (int i = _objects.Count - 1; i >= 0; i--)
                {
                    var obj = _objects[i];
                    if (obj == null)
                    {
                        _objects.RemoveAt(i);
                        continue;
                    }

                    obj.visible = isShow;
                }
            }

            public bool AddObj(GObject obj)
            {
                if (_objects.Contains(obj)) return false;

                _objects.Add(obj);

                return true;
            }

            public void RemoveObj(GObject obj)
            {
                _objects.Remove(obj);
            }

            public int GetObjCount()
            {
                for (int i = _objects.Count - 1; i >= 0; i--)
                {
                    var obj = _objects[i];
                    if (obj == null)
                    {
                        _objects.RemoveAt(i);
                    }
                }

                return _objects.Count;
            }

            public Type GetEventType()
            {
                return _redDotConditionChecker.GetType();
            }

            RedDotConditionChecker _redDotConditionChecker;
            List<GObject> _objects = new List<GObject>();
        }
    }

}
