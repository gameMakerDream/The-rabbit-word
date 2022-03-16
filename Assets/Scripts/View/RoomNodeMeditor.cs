using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNodeMeditor : Mediator
{
    public new static string NAME = "RoomNodeMeditor";

    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public RoomNodeMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        
    }

    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_LoadRoom);
        list.Add(Define.Msg_AddRoom);
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
        SendNotification(Define.Msg_AddRoomComplete);
    }
    private void LoadRoom(RoomNodeData data)
    {
        for (int i = 0; i < data.RoomDataList.Count; i++)
        {
            RoomData roomData= data.RoomDataList[i];
            AddRoom(roomData);
        }
    }
}
