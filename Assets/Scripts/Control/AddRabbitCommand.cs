using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class AddRabbitCommand:SimpleCommand
{
    public override void Execute(INotification notification)
    {
        RabbitData rabbitData = (RabbitData)notification.Body;
        RabbitNodeDataProxy rndProxy = Facade.RetrieveProxy(RabbitNodeDataProxy.NAME) as RabbitNodeDataProxy;
        rndProxy.AddRabbitData(rabbitData);
    }
}
