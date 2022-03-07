using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFacade : Facade
{


    public AppFacade(GameObject root)
    {
        RegisterCommand(Define.Cmd_StartUp, () => new StartUpCommand());
    }

  


}
