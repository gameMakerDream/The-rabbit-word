using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;
using LitJson;
using System;

public class RabbitNodeDataProxy : Proxy,IGeter<RabbitData>
{

    public static new string NAME = "RabbitNodeDataProxy";
    public RabbitNodeData VO
    {
        get { return (RabbitNodeData)Data; }
    }
    public RabbitNodeDataProxy() : base(NAME)
    {
        Data = new RabbitNodeData();
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }

    public void AddRabbitData(RabbitData data)
    {
        data.Id = CreateId();
        VO.RabbitDataList.Add(data);
        Debug.Log(NAME + "增加Rabbit数据，发送" + Define.Msg_AddRabbit + "消息");
        SendNotification(Define.Msg_AddRabbit, data);
    }
    public void AllotRabbit(string rabbitId,string roomId,RoomType roomType)
    {
        RabbitData rabbitData=GetItem(rabbitId);
        rabbitData.RoomId = roomId;
        rabbitData.WorkRoomType = roomType;
    }
    //public void AllotWorkPosition(string rabbitId,Vector3 workPosition)
    //{
    //    RabbitData rabbitData=GetItem(rabbitId);
    //    rabbitData.WorkPosition = workPosition;
    //    SendNotification(Define.Msg_RabbitOpreate, rabbitData);
    //}
    public RabbitData GetItem(string rabbitId)
    {
        return Util.BinarySearch(VO.RabbitDataList.ToArray(), rabbitId, Compare);
    }
    public int Compare(object x, object y)
    {
        string a = (string)x;
        RabbitData b= (RabbitData)y;
        if (int.Parse(a) > int.Parse(b.Id))
            return 1;
        if (int.Parse(a) < int.Parse(b.Id))
            return -1;
        return 0;
    }
    private string CreateId()
    {
        return (VO.RabbitDataList.Count).ToString();
    }
   
}
