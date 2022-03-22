using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
/// <summary>
/// puremvc约束:
/// 1.Meditor只发送命令 不发送消息
/// 2.Proxy只发送消息 不发送命令
/// 3.Meditor绝不修改数据
/// 
/// 
/// 
/// </summary>
public class Main : MonoBehaviour
{

    private void Start()
    {
        AppFacade.GetInstance(() => new AppFacade());
    }
}
