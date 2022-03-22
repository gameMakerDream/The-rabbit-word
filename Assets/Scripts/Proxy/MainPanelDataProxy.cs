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
        Debug.Log(NAME + ":ע��ɹ�������" + Define.Msg_UpdateMainPanel + "��Ϣ");
        SendNotification(Define.Msg_UpdateMainPanel, VO);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":�Ƴ��ɹ�");
    }


}
