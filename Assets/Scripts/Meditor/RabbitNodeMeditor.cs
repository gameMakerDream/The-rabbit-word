using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitNodeMeditor : Mediator,IGeter<RabbitView>
{
    public new static string NAME = "RabbitNodeMeditor";
    public List<RabbitView> RabbitViewList;

    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public RabbitNodeMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {

    }

    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_LoadRabbit);
        list.Add(Define.Msg_AddRabbit);
        list.Add(Define.Msg_RabbitBehavior);
        return list.ToArray();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_LoadRabbit:
                RabbitNodeData rabbitNodeData = (RabbitNodeData)notification.Body;
                LoadRabbit(rabbitNodeData);
                break;
            case Define.Msg_AddRabbit:
                RabbitData rabbitData = (RabbitData)notification.Body;
                AddRabbit(rabbitData);
                break;
            case Define.Msg_RabbitBehavior:
                RabbitBehavior rabbitBehavior = (RabbitBehavior)notification.Body;
                GetItem(rabbitBehavior.RabbitData.Id).ExcuteBehavior(rabbitBehavior);
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


    private void AddRabbit(RabbitData data)
    {
        string rabbitName = "Rabbit";
        GameObject obj = Resources.Load<GameObject>(rabbitName);
        GameObject rabbit = Object.Instantiate(obj, View.transform);
        rabbit.transform.localPosition = Vector3.zero;
        rabbit.transform.localScale = Vector3.one;
        rabbit.transform.localRotation = Quaternion.identity;
        rabbit.name = data.Id;
        SendNotification(Define.Msg_AddRabbitComplete);
    }
    private void LoadRabbit(RabbitNodeData data)
    {
        for (int i = 0; i < data.RabbitDataList.Count; i++)
        {
            RabbitData rabbitData = data.RabbitDataList[i];
            AddRabbit(rabbitData);
        }
    }

    public RabbitView GetItem(string roomId)
    {
        return Util.BinarySearch(RabbitViewList.ToArray(), roomId, Compare);
    }

    public int Compare(object x, object y)
    {
        string a = (string)x;
        RabbitView b = (RabbitView)y;
        if (int.Parse(a) > int.Parse(b.name))
            return 1;
        if (int.Parse(a) < int.Parse(b.name))
            return -1;
        return 0; ;
    }
}
