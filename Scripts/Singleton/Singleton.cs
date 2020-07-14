using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : new()
{
 
    public static T Instance
    {
        get
        {
            return Nested.instance;
        }
    }
    /// <summary>
    /// 隐藏类
    /// </summary>
    class Nested
    {
        static Nested() { }

        internal static readonly T instance = new T();
    }
}
