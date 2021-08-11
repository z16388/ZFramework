using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class SimpleObjectPool<T>: Pool<T>
    {
        readonly Action<T> mResetMethod;

        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
        {
            mFactory = new CustomObjectFactory<T>(factoryMethod);
            mResetMethod = resetMethod;

            for (int i = 0; i < initCount; i ++)
            {
                mCachedStack.Push(mFactory.Create());
            }
        }

        public override bool Recycle(T obj)
        {
            mResetMethod?.Invoke(obj);

            mCachedStack.Push(obj);
            return true;
        }


    }
}
