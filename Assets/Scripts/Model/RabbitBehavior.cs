using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior
{
    public Vector3 Position;
    public BehaviorType BehaviorType;
    public RabbitData RabbitData;
    public RabbitBehavior(string id,Vector3 position,BehaviorType behaviorType)
    {
        RabbitNodeDataProxy rabbitNodeDataProxy = AppFacade.GetInstance(() => new AppFacade()).RetrieveProxy(RabbitNodeDataProxy.NAME) as RabbitNodeDataProxy;
        RabbitData = rabbitNodeDataProxy.GetItem(id);
        Position = position;
        BehaviorType= behaviorType;
    }
}
