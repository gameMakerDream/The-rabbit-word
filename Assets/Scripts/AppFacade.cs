using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFacade : Facade
{


    public AppFacade(GameObject root)
    {
        RegisterCommand(Define.Cmd_StartUp, () => new StartUpCommand());
        SendNotification(Define.Cmd_StartUp,root);
        RemoveCommand(Define.Cmd_StartUp);
    }


}
