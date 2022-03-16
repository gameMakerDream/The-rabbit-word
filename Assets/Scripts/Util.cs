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
    public static void StartCroutine()
    {
        
    }
}
