using LitJson;
using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelDataProxy : Proxy
{
    public static new string NAME = "MainPanelProxy";
    public MainPanelData VO
    {
        get { return (MainPanelData)Data; }
    }
    public MainPanelDataProxy(object data) : base(NAME,data)
    {
        //PlayerPrefsDataProxy ppdProxy = Facade.RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        //Data = ppdProxy.VO.MPD;
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功，发送" + Define.Msg_UpdateMainPanel + "消息");
        SendNotification(Define.Msg_UpdateMainPanel, VO);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }


}
