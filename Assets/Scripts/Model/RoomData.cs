using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData
{
    public RabbitData[] RabbitList;
    public RoomType RoomType;
    public RoomState RoomState;
    public string ID;
    public RoomData(RoomType roomType)
    {
        RabbitList = new RabbitData[5];
        RoomType = roomType;
        RoomState = RoomState.Invalid;
        ID = string.Empty;
    }
}
