using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class AddRoomCompleteCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        string roomId = (string)notification.Body;
        RoomNodeMeditor roomNodeMeditor = Facade.RetrieveMediator(RoomNodeMeditor.NAME) as RoomNodeMeditor;
        RoomNodeDataProxy roomNodeDataProxy = Facade.RetrieveMediator(RoomNodeDataProxy.NAME) as RoomNodeDataProxy;
        RoomView roomView = roomNodeMeditor.GetItem(roomId);
        roomNodeDataProxy.SetRoomWorkPositions(roomId, roomView.WorkPositionList);
    }
}
