using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitData
{
    public double Strength;
    public double Mood;
    public string Id;
    public string RoomId;
    public RoomType WorkRoomType;
    public RabbitData()
    {
        Strength = 1;
        Mood = 1;
        Id = string.Empty;
        RoomId= string.Empty;
        WorkRoomType = RoomType.None;
    }

}
