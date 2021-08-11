using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public interface IPool<T>
    {
        T Allocate();
        bool Recycle(T obj);
    }

    public interface IObjectFactory<T>
    {
        T Create();
    }

    public abstract class Pool<T> : IPool<T>
    {
        public int CurCount
        {
            get { return mCachedStack.Count; }
        }

        protected Stack<T> mCachedStack = new Stack<T>();
        protected IObjectFactory<T> mFactory;
        protected int mMaxCount = 5;

        public virtual T Allocate()
        {
            return mCachedStack.Count > 0 ? mCachedStack.Pop() : mFactory.Create();
        }

        public abstract bool Recycle(T obj);
    }

    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        public CustomObjectFactory(Func<T> factoryMethod)
        {
            mFactoryMethod = factoryMethod;
        }
        protected Func<T> mFactoryMethod;

        public T Create()
        {
            return mFactoryMethod();
        }
    }
}
