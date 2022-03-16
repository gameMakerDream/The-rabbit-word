using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class AddRoomPanelMeditor : Mediator,IUpdater
{
    public new static string NAME = "AddRoomPanelMeditor";
    private Button BtnAdd;
    private Button BtnCarrot;
    private Button BtnStone;
    private Button BtnHappy;
    private Button BtnRest;
    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public AddRoomPanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        BtnAdd.onClick.AddListener(OnClickBtnAdd);
        BtnCarrot.onClick.AddListener(OnClickBtnCarrot);
        BtnStone.onClick.AddListener(OnClickBtnStone);
        BtnHappy.onClick.AddListener(OnClickBtnHappy);
        BtnRest.onClick.AddListener(OnClickBtnRest);

    }
    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_AddRoomComplete);
        return list.ToArray();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_AddRoomComplete:
                Update(null);
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
    private void OnClickBtnAdd()
    {
  
    }
    private void OnClickBtnCarrot()
    {
        Debug.Log(NAME + ":创建Carrot房间");
        RoomData data = new RoomData(RoomType.Carrot);
        SendNotification(Define.Cmd_AddRoom, data);
    }
    private void OnClickBtnStone()
    {
        Debug.Log(NAME + ":创建Stone房间");
        RoomData data = new RoomData(RoomType.Stone);
        SendNotification(Define.Cmd_AddRoom, data);
    }
    private void OnClickBtnHappy()
    {
        Debug.Log(NAME + ":创建Happy房间");
        RoomData data = new RoomData(RoomType.Happy);
        SendNotification(Define.Cmd_AddRoom,data);
    }
    private void OnClickBtnRest()
    {
        Debug.Log(NAME + ":创建Rest房间");
        RoomData data = new RoomData(RoomType.Rest);
        SendNotification(Define.Cmd_AddRoom, data);
    }
    public void Update(object data)
    {
        View.transform.position = new Vector3(Define.AddRoomPanelX, Define.AddRoomPanelY, 0);
    }
}
