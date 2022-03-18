using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanelMeditor : Mediator, IMultiLanguage,IUpdater
{
    public new static string NAME = "MainPanelMeditor";

    private Button BtnNewGame;
    private Button BtnContinue;
    private Button BtnSetting;
    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public MainPanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        BtnNewGame = viewComponent.transform.Find("BtnNewGame").GetComponent<Button>() ;
        BtnContinue = viewComponent.transform.Find("BtnContinue").GetComponent<Button>() ;
        BtnSetting = viewComponent.transform.Find("BtnSetting").GetComponent<Button>();
        BtnNewGame.onClick.AddListener(OnClickNewGame);
        BtnContinue.onClick.AddListener(OnClickContinue);
        BtnSetting.onClick.AddListener(OnClickSetting);
    }

    public override string[] ListNotificationInterests()
    {
        List<string> list= new List<string>();
        list.Add(Define.Msg_ChangeLanguage);
        list.Add(Define.Msg_UpdateMainPanel);
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_ChangeLanguage:
                ChangeLanguage();
                break;
            case Define.Msg_UpdateMainPanel:
                Update(notification.Body);
                break;
            default:
                break;
        }
        base.HandleNotification(notification);
    }
    public override void OnRegister()
    {
        ChangeLanguage();
        View.SetActive(true);
        base.OnRegister();
    }
    public override void OnRemove()
    {
        View.SetActive(false);
        base.OnRemove();
    }
  
    private void OnClickNewGame()
    {
        SendNotification(Define.Cmd_StartGame,1);
    }
    private void OnClickContinue()
    {
        SendNotification(Define.Cmd_StartGame,2);
    }
    private void OnClickSetting()
    {
        SendNotification(Define.Cmd_OpenPanel,PanelType.Setting);
    }




    public void ChangeLanguage()
    {
        BtnNewGame.GetTextGameObject().text = LanguageManager.Instance.GetWords(LanguageTag.Tag_NewGame);
        BtnContinue.GetTextGameObject().text = LanguageManager.Instance.GetWords(LanguageTag.Tag_Continue);
    }

    public void Update(object data)
    {
        MainPanelData mpd = data as MainPanelData;
        BtnContinue.gameObject.SetActive(!mpd.IsNewGame);
    }
}
