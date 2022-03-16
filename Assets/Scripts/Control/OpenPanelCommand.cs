using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class OpenPanelCommand : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        GameObject root = GameObject.Find("Root");
        GameObject panel;
        PlayerPrefsDataProxy ppdProxy = Facade.RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        PanelType panelType = (PanelType)notification.Body;
        switch (panelType)
        {
            case PanelType.Main:
                panel = root.transform.Find("UIRoot/MainPanel").gameObject;
                Facade.RegisterMediator(new MainPanelMeditor(panel));
                Facade.RegisterProxy(new MainPanelDataProxy(ppdProxy.VO.MPD));
                break;
            case PanelType.Game:
                panel = root.transform.Find("UIRoot/GamePanel").gameObject;
                Facade.RegisterMediator(new GamePanelMeditor(panel));
                Facade.RegisterProxy(new GamePanelDataProxy(ppdProxy.VO.GPD));
                break;
            case PanelType.Setting:
                panel = root.transform.Find("UIRoot/SettingPanel").gameObject;
                Facade.RegisterMediator(new SettingPanelMeditor(panel));
                Facade.RegisterProxy(new SettingPanelDataProxy(ppdProxy.VO.SPD));
                break;
            case PanelType.Photo:
                panel = root.transform.Find("UIRoot/PhotoPanel").gameObject;
                //
                //
                break;
            case PanelType.RoomNode:
                Facade.RegisterCommand(Define.Cmd_AddRoom, () => new AddRoomCommand());
                panel = root.transform.Find("WordRoot/RoomNode").gameObject;
                Facade.RegisterMediator(new RoomNodeMeditor(panel));
                Facade.RegisterProxy(new RoomNodeDataProxy(ppdProxy.VO.RND));
                break;
            case PanelType.Room:
                break;
            case PanelType.RabbitNode:
                break;
            case PanelType.Rabbit:
                break;
            default:
                break;
        }
    }


}
