﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetsPV;
namespace AssetsPV
{
    public static class Extensions
    {
        private static Random r = new Random();
        public static T RandomElement<T>(this IEnumerable<T> list)
        {
            if(list == null || list.Count() == 0)
                return default(T);
            int idx = 0, tgt = r.Next(list.Count());
            foreach(T t in list)
            {
                if(tgt == idx)
                {
                    return t;
                }
                idx++;
            }
            return default(T);
        }
        public static int FindByIndex<T>(this IList<T> list, T target)
        {
            if(list == null || list.Count() == 0)
                return -1;
            int idx = 0;
            foreach(T t in list)
            {
                if(target.Equals(list[idx]))
                {
                    return idx;
                }
                idx++;
            }
            return -1;
        }
        public static T RandomElement<T>(this T[,] mat)
        {
            if(mat == null || mat.Length == 0)
                return default(T);

            return mat[r.Next(mat.GetLength(0)), r.Next(mat.GetLength(1))];
        }
        public static T[,] Fill<T>(this T[,] mat, T item)
        {
            if(mat == null || mat.Length == 0)
                return mat;

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = item;
                }
            }
            return mat;
        }

        public static T[] Repeat<T>(this T item, int count)
        {
            if(item == null)
                return null;
            T[] items = new T[count];
            for(int i = 0; i < count; i++)
            {
                items[i] = item;
            }
            return items;
        }

        public static byte[,] Fill(this byte[,] mat, byte item)
        {
            if(mat == null || mat.Length == 0)
                return mat;

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = item;
                }
            }
            return mat;
        }
        public static byte[,,] Fill(this byte[,,] mat, byte item)
        {
            if(mat == null || mat.Length == 0)
                return mat;

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    for(int k = 0; k < mat.GetLength(2); k++)
                    {
                        mat[i, j, k] = item;
                    }
                }
            }
            return mat;
        }
        public static short[,] Fill(this short[,] mat, short item)
        {
            if(mat == null || mat.Length == 0)
                return mat;

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = item;
                }
            }
            return mat;
        }
        public static T[,,] Fill<T>(this T[,,] mat, T item)
        {
            if(mat == null || mat.Length == 0)
                return mat;

            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    for(int k = 0; k < mat.GetLength(2); k++)
                    {
                        mat[i, j, k] = item;
                    }
                }
            }
            return mat;
        }
        public static T[] Fill<T>(this T[] arr, T item)
        {
            if(arr == null || arr.Length == 0)
                return arr;

            for(int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = item;
            }
            return arr;
        }

        public static List<T> ToList<T>(this T[,,] mat)
        {
            if(mat == null || mat.Length == 0)
                return new List<T>();
            int xs = mat.GetLength(0), ys = mat.GetLength(1), zs = mat.GetLength(2);
            List<T> l = new List<T>(xs * ys * zs);
            for(int k = 0; k < zs; k++)
            {
                for(int j = 0; j < ys; j++)
                {
                    for(int i = 0; i < xs; i++)
                    {
                        l.Add(mat[i, j, k]);
                    }
                }
            }
            return l;
        }
        public static T[] ToArray<T>(this T[,,] mat)
        {
            if(mat == null || mat.Length == 0)
                return new T[0];
            int xs = mat.GetLength(0), ys = mat.GetLength(1), zs = mat.GetLength(2);
            T[] a = new T[xs * ys * zs];
            int idx = 0;
            for(int k = 0; k < zs; k++)
            {
                for(int j = 0; j < ys; j++)
                {
                    for(int i = 0; i < xs; i++)
                    {
                        a[idx++] = mat[i, j, k];
                    }
                }
            }
            return a;
        }
        public static T[] Flatten<T>(this T[][] mat)
        {
            if(mat == null)
                return null;
            if(mat.Length == 0)
                return new T[0];
            int xs = mat.Length, ys = mat[0].Length;
            T[] a = new T[xs * ys];
            int idx = 0;

            for(int j = 0; j < ys; j++)
            {
                for(int i = 0; i < xs; i++)
                {
                    a[idx++] = mat[i][j];
                }
            }

            return a;
        }
        public static T[,,] Replicate<T>(this T[,,] mat)
        {
            if(mat == null)
                return null;
            if(mat.Length == 0)
                return new T[0, 0, 0];
            int xs = mat.GetLength(0), ys = mat.GetLength(1), zs = mat.GetLength(2);
            T[,,] dupe = new T[xs, ys, zs];

            for(int i = 0; i < xs; i++)
            {
                for(int j = 0; j < ys; j++)
                {
                    for(int k = 0; k < zs; k++)
                    {
                        dupe[i, j, k] = mat[i, j, k];
                    }
                }
            }
            return dupe;
        }
        public static T[,] Replicate<T>(this T[,] mat)
        {
            if(mat == null)
                return null;
            if(mat.Length == 0)
                return new T[0, 0];
            int xs = mat.GetLength(0), ys = mat.GetLength(1);
            T[,] dupe = new T[xs, ys];

            for(int i = 0; i < xs; i++)
            {
                for(int j = 0; j < ys; j++)
                {
                    dupe[i, j] = mat[i, j];
                }

            }
            return dupe;
        }
        public static T[] Replicate<T>(this T[] mat)
        {
            if(mat == null)
                return null;
            if(mat.Length == 0)
                return new T[0];
            int xs = mat.Length;
            T[] dupe = new T[xs];

            for(int i = 0; i < xs; i++)
            {
                dupe[i] = mat[i];
            }
            return dupe;
        }

    }
}
