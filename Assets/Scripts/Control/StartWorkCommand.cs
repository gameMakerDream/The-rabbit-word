using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class StartWorkCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        object[] data = (object[])notification.Body;
        string rabbitId = (string)data[0];
        string roomId = (string)data[1];
        RoomNodeDataProxy roomNodeDataProxy = Facade.RetrieveProxy(RoomNodeDataProxy.NAME) as RoomNodeDataProxy;
        RoomData roomData = roomNodeDataProxy.GetItem(roomId);
        double[] xyz = roomNodeDataProxy.GetValidWorkPosition(roomId);
        Vector3 position = new Vector3((float)xyz[0], (float)xyz[1], (float)xyz[2]);
        RabbitOrder rabbitBehavior = new RabbitOrder(rabbitId,position,OrderType.Work);
        SendNotification(Define.Msg_RabbitBehavior, rabbitBehavior);

    }
}
