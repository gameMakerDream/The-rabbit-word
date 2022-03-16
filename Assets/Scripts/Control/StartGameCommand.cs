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
        //1新 2继续
        int type = (int)notification.Body;
        PlayerPrefsDataProxy ppdProxy=Facade.RetrieveProxy("PlayerPrefsDataProxy") as PlayerPrefsDataProxy;
        if (type == 1)
        {
            //if (!ppdProxy.VO.IsNewGame)
            //{
            //    //显示个弹框提示
            //    ppdProxy.OverrideData();
            //}
        }
        SendNotification(Define.Cmd_OpenPanel, PanelType.Game);
        SendNotification(Define.Cmd_OpenPanel, PanelType.RoomNode);
        SendNotification(Define.Cmd_OpenPanel, PanelType.Loading);
        //开始加载数据

    }
 
}
