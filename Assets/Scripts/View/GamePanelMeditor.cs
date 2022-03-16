using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelMeditor : Mediator,IUpdater
{
    public new static string NAME = "GamePanelMeditor";

    private Text TxTCarrot;
    private Text TxTStone;
    private Button BtnSetting;
    private Button BtnCarrotAdd;
    private Button BtnStoneAdd;
    private Button BtnPhoto;
    private Button BtnAD;

    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public GamePanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        TxTCarrot = viewComponent.transform.Find("Carrot/BG/TxT").GetComponent<Text>();
        TxTStone = viewComponent.transform.Find("Stone/BG/TxT").GetComponent<Text>();
        BtnSetting = viewComponent.transform.Find("BtnSetting").GetComponent<Button>();
        BtnCarrotAdd = viewComponent.transform.Find("Carrot/BG/BtnAdd").GetComponent<Button>();
        BtnStoneAdd = viewComponent.transform.Find("Stone/BG/BtnAdd").GetComponent<Button>();
        BtnPhoto = viewComponent.transform.Find("BtnPhoto").GetComponent<Button>();
        BtnAD = viewComponent.transform.Find("BtnAD").GetComponent<Button>();


        BtnSetting.onClick.AddListener(OnClickSetting);
        BtnCarrotAdd.onClick.AddListener(OnClickCarrotAdd);
        BtnStoneAdd.onClick.AddListener(OnClickStoneAdd);
        BtnPhoto.onClick.AddListener(OnClickPhoto);
        BtnAD.onClick.AddListener(OnClickAD);

    }


    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_UpdateGamePanel);
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_UpdateGamePanel:
                Update(notification.Body);
                break;
            default:
                break;
        }
        base.HandleNotification(notification);
    }
    public override void OnRegister()
    {
        View.SetActive(true);
        base.OnRegister();
    }
    public override void OnRemove()
    {
        View.SetActive(false);
        base.OnRemove();
    }
    public void Update(object data)
    {
        GamePanelData gpd=data as GamePanelData;
        TxTCarrot.text = gpd.CarrotCount.ToString();
        TxTStone.text=gpd.StoneCount.ToString();
    }

    private void OnClickSetting()
    {
        SendNotification(Define.Cmd_OpenPanel,PanelType.Setting);
    }
    private void OnClickCarrotAdd()
    {
        
    }
    private void OnClickStoneAdd()
    {

    }
    private void OnClickPhoto()
    {

    }
    private void OnClickAD()
    {
        
    }
}
