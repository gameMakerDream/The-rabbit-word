using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Facade.RegisterProxy(new PlayerPrefsDataProxy());
        GameObject root = GameObject.Find("Root");
        root.AddComponent<SoundManager>();
        root.AddComponent<LanguageManager>();
        root.AddComponent<MonoUtil>();
        Facade.RegisterCommand(Define.Cmd_OpenPanel, () => new OpenPanelCommand());
        Facade.RegisterCommand(Define.Cmd_HidePanel, () => new HidePanelCommand());
        SendNotification(Define.Cmd_OpenPanel, PanelType.Main);
        Debug.Log("ÓÎÏ·¿ªÊ¼");
    }


}
