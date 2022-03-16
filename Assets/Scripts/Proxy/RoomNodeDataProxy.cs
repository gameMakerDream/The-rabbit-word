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
        Debug.Log(NAME + ":注册成功，发送" + Define.Msg_LoadRoom + "消息");
        SendNotification(Define.Msg_LoadRoom, VO);
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }

    public void AddRoomData(RoomData data)
    {
        data.ID=CreateID();
        VO.RoomDataList.Add(data);
        Debug.Log(NAME + "增加房间数据，发送" + Define.Msg_AddRoom + "消息");
        SendNotification(Define.Msg_AddRoom, data);
    }
    private string CreateID()
    {
        return (VO.RoomDataList.Count).ToString();
    }
}
