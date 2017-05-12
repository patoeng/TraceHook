using System;

namespace TraceabilityConnector.Helper
{
    public static class ArrayFunctions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        public static T[] InsertArray<T>(this T[] data,T[] target, int index)
        {
            T[] result = new T[data.Length];
            for (var i = 0; i < target.Length; i++)
            {
                result[index + i] = target[i];
            }
            return result;
        }
        public static void InsertArray(int[] data, int[] target, int index)
        {
            for (var i = 0; i < target.Length; i++)
            {
                data[index + i] = target[i];
            }
        }
    }
}
