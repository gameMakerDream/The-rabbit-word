using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
public class WorkPositionData
{
    public int ID;
    public bool IsVaild;
    public double X;
    public double Y;
    public double Z;
    public WorkPositionData()
    {
        
    }
    public WorkPositionData(int id,bool isVaild,double x,double y,double z)
    {
        ID=id;
        IsVaild = isVaild;
        X = x;
        Y = y;
        Z = z;
    }
}
public class RoomData
{
   
    public List<string> RabbitIdList;
    public RoomType RoomType;
    public RoomState RoomState;
    public string ID;
    public double BuildTime;
    public List<WorkPositionData> WorkPositionList;
    public Timer timer;
    public RoomData()
    {
        
    }
    public RoomData(RoomType roomType)
    {
        RabbitIdList = new List<string>();
        RoomType = roomType;
        RoomState = RoomState.Invalid;
        ID = string.Empty;
        WorkPositionList = new List<WorkPositionData>();
        BuildTime = 0;
        timer = null;
    }

    public double[] GetValidWorkPositon()
    {
        for (int i = 0; i < WorkPositionList.Count; i++)
        {
            WorkPositionData workPosition = WorkPositionList[i];
            if (workPosition.IsVaild)
            {
                workPosition.IsVaild = false;
                return new double[] { workPosition.X, workPosition.Y, workPosition.Z };
            }
        }
        return new double[] { 0,0,0};
    }
    public WorkPositionData GetWorkPosition(int workPositionId)
    {
        for (int i = 0; i < WorkPositionList.Count; i++)
        {
            WorkPositionData workPosition = WorkPositionList[i];
            if (workPosition.ID == workPositionId)
                return workPosition;
        }
        return null;
    }

}
