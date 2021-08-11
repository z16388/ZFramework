using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZFramework
{
    public sealed class LoadTool
    {
        public static void Initialize(params ILoader[] loaders)
        {
            _map.Clear();
            for (int i = 0; i < loaders.Length; i++)
            {
                var loader = loaders[i];
                loader.Initialize();
                _map.Add(loader.Id, loader);
            }
        }

        public static void Dispose()
        {
            foreach (var a in _map)
            {
                a.Value.Dispose();
            }
            _map.Clear();
        }

        public static T Load<T>(string path, int loaderId = 1) where T : UnityEngine.Object
        {
            if (_map.ContainsKey(loaderId))
            {
                return _map[loaderId].Load<T>(path);
            }

            return default;
        }

        public static void LoadAsync<T>(string path, Action<T> onloadFinshed, int loaderId = 1) where T : UnityEngine.Object
        {
            if (_map.ContainsKey(loaderId))
            {
                _map[loaderId].LoadAsync<T>(path, onloadFinshed);
                return;
            }
            MDebug.LogErr("Dont Contain This Loader" + loaderId);
            onloadFinshed?.Invoke(default);
        }

        public static void Unload(string path, int loaderId = -1)
        {
            if (_map.ContainsKey(loaderId))
            {
                _map[loaderId].Unload(path);
            }
            else
            {
                foreach (var a in _map)
                {
                    a.Value.Unload(path);
                }
            }
        }

        public static void UnloadAll(int loaderId = -1)
        {
            if (_map.ContainsKey(loaderId))
            {
                _map[loaderId].UnloadAll();
            }
            else
            {
                foreach (var a in _map)
                {
                    a.Value.UnloadAll();
                }
            }
        }

        static Dictionary<int, ILoader> _map = new Dictionary<int, ILoader>();
    }
}
