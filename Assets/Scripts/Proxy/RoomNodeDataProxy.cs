using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;
using LitJson;

public class RoomNodeDataProxy : Proxy
{

    public static new string NAME = "RoomNodeDataProxy";
    public RoomNodeData VO
    {
        get { return (RoomNodeData)Data; }
    }
    public RoomNodeDataProxy(object data) : base(NAME, data)
    {

    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":ע��ɹ�������" + Define.Msg_LoadRoom + "��Ϣ");
        SendNotification(Define.Msg_LoadRoom, VO);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":�Ƴ��ɹ�");
    }

    public void AddRoomData(RoomData data)
    {
        data.ID=CreateID();
        VO.RoomDataList.Add(data);
        Debug.Log(NAME + "���ӷ������ݣ�����" + Define.Msg_AddRoom + "��Ϣ");
        SendNotification(Define.Msg_AddRoom, data);
    }
    private string CreateID()
    {
        return (VO.RoomDataList.Count).ToString();
    }
}
