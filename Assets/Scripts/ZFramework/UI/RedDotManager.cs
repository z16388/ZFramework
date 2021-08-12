using System;
using System.Collections.Generic;
using FairyGUI;

namespace ZFramework

{
    ///
    /// 
    /// 一些条件
    /// 满足了通知红点显示
    /// 不满足通知红点取消
    ///
    /// ==》事件==》封装一些处理
    ///
    /// 1. 事件封装处理
    /// 2. 条件检查 ==》不长时间循环检查，循环检查太费了
    ///
    /// && 红点一般刷新的频次比初始化的频次要多
    /// 所以存储的地方改用List而不是Map

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
