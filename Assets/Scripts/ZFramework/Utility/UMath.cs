using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFramework
{
    public class UMath
    {
        public UMath()
        {

        }

        public bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }

        public T GetRandomValue<T>(T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }
    }

}
