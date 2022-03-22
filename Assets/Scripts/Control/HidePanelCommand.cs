using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;

public class HidePanelCommand : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        PanelType panelType = (PanelType)notification.Body;
        switch (panelType)
        {
            case PanelType.Main:
                Facade.RemoveMediator(MainPanelMeditor.NAME);
                Facade.RemoveProxy(MainPanelDataProxy.NAME);
                break;
            case PanelType.Game:
                Facade.RemoveMediator(GamePanelMeditor.NAME);
                Facade.RemoveProxy(GamePanelDataProxy.NAME);
                break;
            case PanelType.Setting:
                Facade.RemoveMediator(SettingPanelMeditor.NAME);
                Facade.RemoveProxy(SettingPanelDataProxy.NAME);
                break;
            case PanelType.Photo:
                Facade.RemoveMediator("PhotoPanelMeditor");
                break;
            case PanelType.RoomNode:
                Facade.RemoveCommand(Define.Cmd_AddRoom);
                Facade.RemoveMediator(RoomNodeMeditor.NAME);
                Facade.RemoveProxy(RoomNodeDataProxy.NAME);
                break;
            default:
                break;
        }
    }


}
