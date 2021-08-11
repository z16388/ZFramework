using System.Collections.Generic;
using System;
using UnityEngine;

namespace ZFramework
{
    public class ResourceLoader : ILoader
    {
        public int Id => 1;

        public void Dispose()
        {
            UnloadAll();
        }

        public void Initialize()
        {
        }

        public T Load<T>(string path) where T : UnityEngine.Object
        {
            if (_map.ContainsKey(path))
            {
                var go = _map[path];
                go.AddReference();
                return go.GetAsset() as T;
            }

            var asset = Resources.Load(path);
            var referenceHelper = new ReferenceHelper(asset);
            _map.Add(path, referenceHelper);

            return asset as T;
        }

        public void LoadAsync<T>(string path, Action<T> onLoadFinished) where T : UnityEngine.Object
        {
            if (_map.ContainsKey(path))
            {
                var go = _map[path];
                go.AddReference();
                var asset = go.GetAsset();
                onLoadFinished?.Invoke(asset as T);
                return;
            }

            var request = Resources.LoadAsync(path);

            request.completed += a =>
            {
                var asset = request.asset;
                if (asset != null)
                {
                    var referenceHelper = new ReferenceHelper(asset);
                    _map.Add(path, referenceHelper);
                }
                else
                {
                    MDebug.LogErr("Load Async Failed !!!" + path);
                }

                onLoadFinished?.Invoke(asset as T);
            };
        }

        public void Unload(string path)
        {
            if (!_map.ContainsKey(path))
            {
                return;
            }

            var helper = _map[path];
            helper.RemoveReference();
            if (helper.IsNeedDispose())
            {
                var asset = helper.GetAsset();
                Resources.UnloadAsset(asset);
                _map.Remove(path);
            }
        }

        public void UnloadAll()
        {
            foreach (var a in _map)
            {
                var asset = a.Value.GetAsset();
                Resources.UnloadAsset(asset);
            }
            _map.Clear();
            Resources.UnloadUnusedAssets();
            GC.Collect();
        }

        class ReferenceHelper
        {
            public ReferenceHelper(UnityEngine.Object obj)
            {
                _obj = obj;
                _count = 1;
            }

            public bool IsNeedDispose()
            {
                return _count <= 0;
            }

            public void AddReference()
            {
                _count++;
            }

            public void RemoveReference()
            {
                _count--;
            }

            public UnityEngine.Object GetAsset()
            {
                return _obj;
            }

            UnityEngine.Object _obj;
            int _count;
        }

        Dictionary<string, ReferenceHelper> _map = new Dictionary<string, ReferenceHelper>();
    }
}
