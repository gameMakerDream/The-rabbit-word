using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
/// <summary>
/// puremvcԼ��:
/// 1.Meditorֻ�������� ��������Ϣ
/// 2.Proxyֻ������Ϣ ����������
/// 3.Meditor�����޸�����
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
