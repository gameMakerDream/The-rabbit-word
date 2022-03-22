using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class AddRoomCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RoomData roomData = (RoomData)notification.Body;
        RoomNodeDataProxy rndProxy = Facade.RetrieveProxy(RoomNodeDataProxy.NAME) as RoomNodeDataProxy;
        rndProxy.AddRoomData(roomData);
    }
}
