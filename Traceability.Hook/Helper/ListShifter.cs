using System;
using System.Collections.Generic;

namespace Traceability.Hook.Helper
{
    public static class ListShifter
    {
        public static void ShiftLeft<T>(List<T> lst, int shifts)
        {
            for (int i = shifts; i < lst.Count; i++)
            {
                lst[i - shifts] = lst[i];
            }

            for (int i = lst.Count - shifts; i < lst.Count; i++)
            {
                lst[i] = default(T);
            }
        }
        public static void ShiftRight<T>(List<T> lst, int shifts)
        {
            for (int i = lst.Count - shifts - 1; i >= 0; i--)
            {
                lst[i + shifts] = lst[i];
            }

            for (int i = 0; i < shifts; i++)
            {
                lst[i] = default(T);
            }
        }
        public static void ShiftLeft<T>(T[] arr, int shifts)
        {
            Array.Copy(arr, shifts, arr, 0, arr.Length - shifts);
            Array.Clear(arr, arr.Length - shifts, shifts);
        }

        public static void ShiftRight<T>(T[] arr, int shifts)
        {
            Array.Copy(arr, 0, arr, shifts, arr.Length - shifts);
            Array.Clear(arr, 0, shifts);
        }
    }
}
