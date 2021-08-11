using System;
using System.Collections.Generic;
using System.IO;


namespace ConfigData
{
    public class IConfig
    {
        protected int ReadInt32(BinaryReader br)
        {
            return br.ReadInt32();
        }

        protected long ReadInt64(BinaryReader br)
        {
            return br.ReadInt64();
        }

        protected string ReadString(BinaryReader br)
        {
            return br.ReadString();
        }

        protected float ReadFloat(BinaryReader br)
        {
            return br.ReadSingle();
        }

        protected bool ReadBool(BinaryReader br)
        {
            return br.ReadBoolean();
        }

        protected int[] ReadInt32Array(BinaryReader br)
        {
            int length = br.ReadInt32();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = br.ReadInt32();
            }
            return array;
        }

        protected long[] ReadInt64Array(BinaryReader br)
        {
            int length = br.ReadInt32();
            long[] array = new long[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = br.ReadInt64();
            }
            return array;
        }

        protected string[] ReadStringArray(BinaryReader br)
        {
            int length = br.ReadInt32();
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = br.ReadString();
            }
            return array;
        }

        protected float[] ReadFloatArray(BinaryReader br)
        {

            int length = br.ReadInt32();
            float[] array = new float[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = br.ReadSingle();
            }
            return array;
        }

        protected int[][] ReadInt32ArrayMtp(BinaryReader br)
        {

            int length = br.ReadInt32();
            int[][] array = new int[length][];
            for (int i = 0; i < length; i++)
            {
                int len2 = br.ReadInt32();
                array[i] = new int[len2];
                for (int j = 0; j < len2; j++)
                {
                    array[i][j] = br.ReadInt32();
                }
            }
            return array;
        }

        protected string[][] ReadStringArrayMtp(BinaryReader br)
        {
            int length = br.ReadInt32();
            string[][] array = new string[length][];
            for (int i = 0; i < length; i++)
            {
                int len2 = br.ReadInt32();
                array[i] = new string[len2];
                for (int j = 0; j < len2; j++)
                {
                    array[i][j] = br.ReadString();
                }
            }
            return array;
        }

        protected float[][] ReadFloatArrayMtp(BinaryReader br)
        {

            int length = br.ReadInt32();
            float[][] array = new float[length][];
            for (int i = 0; i < length; i++)
            {
                int len2 = br.ReadInt32();
                array[i] = new float[len2];
                for (int j = 0; j < len2; j++)
                {
                    array[i][j] = br.ReadSingle();
                }
            }
            return array;
        }

        //public void ReadInt32ArrayMap(BinaryReader br, out Dictionary<int, int>[] array)
        //{
        //    array = null;
        //    try
        //    {
        //        int length = br.ReadInt32();
        //        array = new Dictionary<int, int>[length];
        //        for (int i = 0; i < length; i++)
        //        {
        //            int len2 = br.ReadInt32();
        //            array[i] = new float[len2];
        //            for (int j = 0; j < len2; j++)
        //            {
        //                array[i][j] = br.ReadSingle();
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("[Error] ReadInt32ArrayMap Exception: " + exp);
        //        array = null;
        //        return false;
        //    }
        //}

        //public bool ReadStringArrayMap(BinaryReader br, out Dictionary<string, string>[] array)
        //{
        //    try
        //    {
        //        string data = br.ReadString();
        //        string[] dataList = data == string.Empty ? null : data.Split('|');
        //        if (dataList == null)
        //        {
        //            array = new Dictionary<string, string>[0];
        //            return true;
        //        }

        //        array = new Dictionary<string, string>[dataList.Length];
        //        for (int i = 0; i < dataList.Length; i++)
        //        {
        //            if (dataList[i] == string.Empty)
        //                array[i] = new Dictionary<string, string>();
        //            else
        //            {
        //                string[] tempArray = dataList[i].Split(':');
        //                Dictionary<string, string> dic = new Dictionary<string, string>();
        //                dic[tempArray[0]] = tempArray.Length < 2 ? string.Empty : tempArray[1];
        //                array[i] = dic;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("[Error] ReadStringArrayMap Exception: " + exp);
        //        array = null;
        //        return false;
        //    }
        //}

        //public bool ReadInt32ArrayMap(BinaryReader br, out Dictionary<float, float>[] array)
        //{
        //    try
        //    {
        //        string data = br.ReadString();
        //        string[] dataList = data == string.Empty ? null : data.Split('|');
        //        if (dataList == null)
        //        {
        //            array = new Dictionary<float, float>[0];
        //            return true;
        //        }

        //        array = new Dictionary<float, float>[dataList.Length];
        //        for (int i = 0; i < dataList.Length; i++)
        //        {
        //            if (dataList[i] == string.Empty)
        //                array[i] = new Dictionary<float, float>();
        //            else
        //            {
        //                string[] tempList = dataList[i].Split(':');
        //                Dictionary<float, float> dic = new Dictionary<float, float>();
        //                dic[float.Parse(tempList[0])] = (tempList.Length < 2 || tempList[1] == string.Empty) ? 0 : float.Parse(tempList[1]);
        //                array[i] = dic;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("[Error] ReadFloatArrayMap Exception: " + exp);
        //        array = null;
        //        return false;
        //    }
        //}

        protected Dictionary<int, T> MakeDictionary<T>(BinaryReader br) where T : IConfig, new()
        {

            int rowNum = br.ReadInt32();

            try
            {
                Dictionary<int, T> result = new Dictionary<int, T>();
                for (int i = 0; i < rowNum; i++)
                {
                    T line = new T();
                    line.MergeFrom(br);
                    result.Add(line.GetKey(), line);
                }
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine("[Error] MakeDictionary Exception: " + exp);
                return null;
            }
        }

        protected Dictionary<int, Dictionary<int, T>> MakeMDictionary<T>(BinaryReader br) where T : IConfig, new()
        {

            int rowNum = br.ReadInt32();
            try
            {
                Dictionary<int, Dictionary<int, T>> result = new Dictionary<int, Dictionary<int, T>>();
                for (int i = 0; i < rowNum; i++)
                {
                    T line = new T();
                    line.MergeFrom(br);
                    int dicKey = line.GetDicKey();
                    if (!result.ContainsKey(dicKey))
                        result[dicKey] = new Dictionary<int, T>();

                    result[dicKey].Add(line.GetKey(), line);
                }
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine("[Error] MakeMDictionary Exception: " + exp);
                return null;
            }
        }

        protected List<T> MakeList<T>(BinaryReader br) where T : IConfig, new()
        {

            int rowNum = br.ReadInt32();
            try
            {
                List<T> result = new List<T>();
                for (int i = 0; i < rowNum; i++)
                {
                    T line = new T();
                    line.MergeFrom(br);
                    result.Add(line);
                }
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine("[Error] MakeList Exception: " + exp);
                return null;
            }
        }

        protected Dictionary<int, List<T>> MakeMRDictionary<T>(BinaryReader br) where T : IConfig, new()
        {

            int rowNum = br.ReadInt32();

            try
            {
                Dictionary<int, List<T>> result = new Dictionary<int, List<T>>();
                for (int i = 0; i < rowNum; i++)
                {
                    T line = new T();
                    line.MergeFrom(br);
                    int dicKey = line.GetDicKey();
                    if (!result.ContainsKey(dicKey))
                        result[dicKey] = new List<T>();

                    result[dicKey].Add(line);
                }
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine("[Error] MakeMRDictionary Exception: " + exp);
                return null;
            }
        }

        public virtual void MergeFrom(BinaryReader br) { }
        protected virtual int GetKey() { return 0; }
        protected virtual int GetDicKey() { return 0; }
    }
}
