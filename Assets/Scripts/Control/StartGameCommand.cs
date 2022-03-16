using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StartGameCommand : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        //1�� 2����
        int type = (int)notification.Body;
        PlayerPrefsDataProxy ppdProxy=Facade.RetrieveProxy("PlayerPrefsDataProxy") as PlayerPrefsDataProxy;
        if (type == 1)
        {
            //if (!ppdProxy.VO.IsNewGame)
            //{
            //    //��ʾ��������ʾ
            //    ppdProxy.OverrideData();
            //}
        }
        SendNotification(Define.Cmd_OpenPanel, PanelType.Game);
        SendNotification(Define.Cmd_OpenPanel, PanelType.RoomNode);
        SendNotification(Define.Cmd_OpenPanel, PanelType.Loading);
        //��ʼ��������

    }
 
}
