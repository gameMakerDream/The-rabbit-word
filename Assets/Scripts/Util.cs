using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util
{

    public static T LoadData<T>()where T:new()
    {
        string json = PlayerPrefs.GetString(typeof(T).ToString());
        T vo = new T();
        if (!string.IsNullOrEmpty(json))
            vo = JsonMapper.ToObject<T>(json);
        return new T();
    }
    public static T BinarySearch<T, T1>(T[] array, T1 key, Func<T1, T, int> compareMethod)
    {
        int high = array.Length - 1;
        int low = high / 2;
        int middleIndex = low;
        while (low <= high)
        {
            if (compareMethod(key, array[middleIndex])==1)//大于号
            {
                low = middleIndex + 1;
                middleIndex = ((low + high) / 2);
            }
            else if (compareMethod(key, array[middleIndex])==-1)//小于号
            {
                high = middleIndex;
                middleIndex = ((low + high) / 2);
            }
            else
            {
                return array[middleIndex];
            }
        }
        return default(T);
    }

}
