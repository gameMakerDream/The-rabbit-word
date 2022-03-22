using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNodeMeditor : Mediator,IGeter<RoomView>
{
    public new static string NAME = "RoomNodeMeditor";
    public List<RoomView> RoomViewList;
    private GameObject View
    {
        get { return (GameObject)ViewComponent; }
    }
    public RoomNodeMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        RoomViewList = new List<RoomView>();
    }

    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_LoadRoom);
        list.Add(Define.Msg_AddRoom);
        list.Add(Define.Msg_AddRoomProgress);
        list.Add(Define.Msg_AddRoomComplete) ;
        return list.ToArray();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_LoadRoom:
                RoomNodeData roomNodeData = (RoomNodeData)notification.Body;
                LoadRoom(roomNodeData);
                break;
            case Define.Msg_AddRoom:
                RoomData roomData = (RoomData)notification.Body;
                AddRoom(roomData);
                break;
            case Define.Msg_AddRoomProgress:
                RoomData roomData1= (RoomData)notification.Body;
                GetItem(roomData1.ID).AddRoomProgress(roomData1.BuildTime);
                break;
            case Define.Msg_AddRoomComplete:
                RoomData roomData2 = (RoomData)notification.Body;
                GetItem(roomData2.ID).AddRoomComplete();
                break;
            default:
                break;
        }
        base.HandleNotification(notification);
    }

    public override void OnRegister()
    {
        View.SetActive(true);
        base.OnRegister();
    }

    public override void OnRemove()
    {
        View.SetActive(false);
        base.OnRemove();
    }


    private void AddRoom(RoomData data)
    {
        string roomName = "Room" + data.RoomType.ToString();
        GameObject obj = Resources.Load<GameObject>(roomName);
        GameObject room= Object.Instantiate(obj,View.transform);
        room.transform.localPosition = Vector3.zero;
        room.transform.localScale = Vector3.one;
        room.transform.localRotation = Quaternion.identity;
        room.name = data.ID;
        RoomView roomView = room.AddComponent<RoomView>();
        roomView.Initialization();
        RoomViewList.Add(roomView);
        SendNotification(Define.Cmd_AddRoomComplete, data.ID);
    }
    private void LoadRoom(RoomNodeData data)
    {
        for (int i = 0; i < data.RoomDataList.Count; i++)
        {
            RoomData roomData= data.RoomDataList[i];
            AddRoom(roomData);
        }
    }
    public RoomView GetItem(string roomId)
    {
        return Util.BinarySearch(RoomViewList.ToArray(), roomId, Compare);
    }

    public int Compare(object x, object y)
    {
        string a = (string)x;
        RoomView b = (RoomView)y;
        if (int.Parse(a) > int.Parse(b.name))
            return 1;
        if (int.Parse(a) < int.Parse(b.name))
            return -1;
        return 0; ;
    }
}
