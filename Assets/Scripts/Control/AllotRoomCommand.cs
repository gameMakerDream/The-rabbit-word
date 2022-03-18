using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class AllotRoomCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        string[] data = (string[])notification.Body;
        string rabbitId = data[0];
        string roomId = data[1];
        RabbitNodeDataProxy rabbitNodeDataProxy = Facade.RetrieveProxy(RabbitNodeDataProxy.NAME) as RabbitNodeDataProxy;
        RoomNodeDataProxy roomNodeDataProxy = Facade.RetrieveProxy(RoomNodeDataProxy.NAME) as RoomNodeDataProxy;
        RoomData roomData = roomNodeDataProxy.GetItem(roomId);
        rabbitNodeDataProxy.AllotRabbit(rabbitId, roomId, roomData.RoomType);
        roomNodeDataProxy.AllotRoom(roomId, rabbitId);


        //1 拖拽到房间范围内并且松开手指 就分配房间 
        //2 rabbit落地后碰到碰撞体之后发送工作命令.
        //3 工作命令获取两个视图脚本 让rabbit前往工作区

    }
}
