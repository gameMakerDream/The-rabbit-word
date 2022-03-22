using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;
using LitJson;

public class SettingPanelDataProxy : Proxy
{

    public static new string NAME = "SettingPanelDataProxy";
    public MainPanelData VO
    {
        get { return (MainPanelData)Data; }
    }
    public SettingPanelDataProxy(object data) : base(NAME,data)
    {
        //PlayerPrefsDataProxy ppdProxy = Facade.RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        //Data = ppdProxy.VO.SPD;
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功，发送" + Define.Msg_UpdateSettingPanel + "消息");
        SendNotification(Define.Msg_UpdateSettingPanel, VO);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }

}
