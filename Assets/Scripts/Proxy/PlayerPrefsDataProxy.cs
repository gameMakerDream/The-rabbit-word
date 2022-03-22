using LitJson;
using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataProxy : Proxy
{
    public static new string NAME = "PlayerPrefsDataProxy";
    public  PlayerPrefsData VO
    {
        get { return (PlayerPrefsData)Data; }
    }
    public PlayerPrefsDataProxy() : base(NAME)
    {
        Data= Util.LoadData<PlayerPrefsData>();
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }
    public void OverrideData()
    {
        Data = new PlayerPrefsData();
    }

    //private PlayerPrefsData LoadPlayerPrefsData()
    //{
    //    string json = PlayerPrefs.GetString("PlayerPrefsData");
    //    PlayerPrefsData vo = new PlayerPrefsData();
    //    if (!string.IsNullOrEmpty(json))
    //        vo = JsonMapper.ToObject<PlayerPrefsData>(json);
    //    return new PlayerPrefsData();
    //}
}
