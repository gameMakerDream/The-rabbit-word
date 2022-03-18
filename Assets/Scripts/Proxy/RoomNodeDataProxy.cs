using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;
using LitJson;
using System.Threading.Tasks;
using UnityTimer;

public class RoomNodeDataProxy : Proxy,IGeter<RoomData>
{

    public static new string NAME = "RoomNodeDataProxy";
    public RoomNodeData VO
    {
        get { return (RoomNodeData)Data; }
    }
    public RoomNodeDataProxy() : base(NAME)
    {
        Data = new RoomNodeData();
    }
    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");
    }
    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }

    public void AddRoomData(RoomData data)
    {
        data.ID = CreateId();
        VO.RoomDataList.Add(data);
        Debug.Log(NAME + "增加房间数据，发送" + Define.Msg_AddRoom + "消息");
        SendNotification(Define.Msg_AddRoom, data);
        if (data.RoomState == RoomState.Invalid)
            BuildRoom(data);
    }
    public void SetRoomWorkPositions(string roomId, List<WorkPositionData> workPositionList)
    {
        RoomData data = GetItem(roomId);
        data.WorkPositionList = workPositionList;
    }
    public void AllotRoom(string roomId, string rabbitId)
    {
        RoomData roomData = GetItem(roomId);
        roomData.RabbitIdList.Add(rabbitId);
    }
    public RoomData GetItem(string roomId)
    {
        return Util.BinarySearch(VO.RoomDataList.ToArray(), roomId, Compare);
    }
    public int Compare(object x, object y)
    {
        string a = (string)x;
        RoomData b = (RoomData)y;
        if (int.Parse(a) > int.Parse(b.ID))
            return 1;
        if (int.Parse(a) < int.Parse(b.ID))
            return -1;
        return 0;
    }
    private string CreateId()
    {
        return (VO.RoomDataList.Count).ToString();
    }
    private void BuildRoom(RoomData data)
    {
        float time = (float)(Define.BuildTime - data.BuildTime);
        float offset = (float)data.BuildTime;
        data.timer = Timer.Register(time, 
            () =>
            {
                if (data.BuildTime >= Define.BuildTime)
                {
                    data.BuildTime = Define.BuildTime;
                    data.RoomState = RoomState.Valid;
                }
                data.timer = null;
                SendNotification(Define.Msg_AddRoomComplete, data);
            },
            (x) =>
            {
                data.BuildTime = x + offset;
                SendNotification(Define.Msg_AddRoomProgress, data);
            });
    }
    public double[] GetValidWorkPosition(string roomId)
    {
        RoomData data = GetItem(roomId);
        return data.GetValidWorkPositon();
    }
}
