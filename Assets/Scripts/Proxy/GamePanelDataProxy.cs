using LitJson;
using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelDataProxy : Proxy
{
    public static new string NAME = "MainPanelProxy";
    public MainPanelData VO
    {
        get { return (MainPanelData)Data; }
    }
    public GamePanelDataProxy(object data) : base(NAME,data)
    {
        //PlayerPrefsDataProxy ppdProxy = Facade.RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        //Data = ppdProxy.VO.GPD;
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":ע��ɹ�������" + Define.Msg_UpdateGamePanel + "��Ϣ");
        SendNotification(Define.Msg_UpdateGamePanel,Data);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":�Ƴ��ɹ�");
    }


}
