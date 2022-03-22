using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitOrder
{
    public Vector3 Destination;
    public OrderType OrderType;
    public RabbitData RabbitData;
    public RabbitOrder(string id,Vector3 position,OrderType orderType)
    {
        RabbitNodeDataProxy rabbitNodeDataProxy = AppFacade.GetInstance(() => new AppFacade()).RetrieveProxy(RabbitNodeDataProxy.NAME) as RabbitNodeDataProxy;
        RabbitData = rabbitNodeDataProxy.GetItem(id);
        Destination = position;
        OrderType= orderType;
    }
}
