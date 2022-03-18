using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    private Transform BornTrans;
    [HideInInspector]
    public List<WorkPositionData> WorkPositionList;
    // Start is called before the first frame update
    public void Initialization()
    {
        BornTrans = transform.Find("BornPosition");
        for (int i = 0; i < Define.MaxRoomWorkingArea; i++)
        {
            Vector3 position = transform.Find("WorkArea" + (i + 1)).position;
            WorkPositionData workPositionStruct = new WorkPositionData(i, true,position.x,position.y,position.z);
            WorkPositionList.Add(workPositionStruct);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddRoomProgress(double progress)
    {
        Debug.Log("RoomID:"+gameObject.name +"进度"+ progress/Define.BuildTime);
    }
    public void AddRoomComplete ()
    {
        Debug.Log("RoomID:"+gameObject.name +"建造完成");
    }

}
