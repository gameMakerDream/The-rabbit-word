using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        GameObject root = notification.Body as GameObject;
        GameObject uiRoot = root.transform.Find("UIRoot").gameObject;
        GameObject wordRoot = root.transform.Find("WordRoot").gameObject;
        Facade.RegisterMediator(new UIRootMeditor(uiRoot));
        Facade.RegisterMediator(new WordRootMeditor(wordRoot));
        //Facade.RegisterProxy();
        Debug.Log("ÓÎÏ·¿ªÊ¼");
    }
}
