using System;
namespace ZFramework
{
    public interface ILoader
    {
        int Id { get; }

        void Initialize();

        void Dispose();

        T Load<T>(string path) where T : UnityEngine.Object;

        void LoadAsync<T>(string path, Action<T> onLoadFinished) where T : UnityEngine.Object;

        void Unload(string path);

        void UnloadAll();
    }
}
