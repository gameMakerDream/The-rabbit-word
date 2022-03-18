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
        PlayerPrefsDataProxy playerPrefsDataProxy=Facade.RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
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
        SendNotification(Define.Cmd_OpenPanel, PanelType.RabbitNode);
        SendNotification(Define.Cmd_OpenPanel, PanelType.Loading);
        for (int i = 0; i < playerPrefsDataProxy.VO.RND.RoomDataList.Count; i++)
        {
            RoomData roomData = playerPrefsDataProxy.VO.RND.RoomDataList[i];
            SendNotification(Define.Cmd_AddRoom, roomData);
        }
        for (int i = 0; i < playerPrefsDataProxy.VO.RND1.RabbitDataList.Count; i++)
        {
            RabbitData rabbitData = playerPrefsDataProxy.VO.RND1.RabbitDataList[i];
            SendNotification(Define.Cmd_AddRabbit, rabbitData);
        }
        for (int i = 0; i < playerPrefsDataProxy.VO.RND1.RabbitDataList.Count; i++)
        {
            string rabbitId = playerPrefsDataProxy.VO.RND1.RabbitDataList[i].Id;
            string roomId = playerPrefsDataProxy.VO.RND1.RabbitDataList[i].RoomId;
            SendNotification(Define.Cmd_AllotRoom, new string[] { rabbitId, roomId });
            SendNotification(Define.Cmd_StartWork, new string[] {rabbitId,roomId });
        }

        //这里是加载持久话数据 分配完后恢复位置或者不回复也行  直接发送开始工作命令


    }

}
