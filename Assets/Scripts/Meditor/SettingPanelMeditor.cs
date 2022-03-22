using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPanelMeditor : Mediator,IMultiLanguage,IUpdater
{
    public new static string NAME = "SettingPanelMeditor";

    private Button BtnContinue;
    private Button BtnBackMain;
    private Text TxTTitle;
    private Text TxTLanguage;
    private Slider SliderSound;
    private Toggle ToggleSound;

    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public SettingPanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        TxTTitle = viewComponent.transform.Find("BG/Title").GetComponent<Text>();
        TxTLanguage = viewComponent.transform.Find("BG/Language/TxT").GetComponent<Text>();
        BtnContinue = viewComponent.transform.Find("BG/BtnContinue").GetComponent<Button>();
        BtnBackMain = viewComponent.transform.Find("BG/BtnBackMain").GetComponent<Button>();
        SliderSound = viewComponent.transform.Find("BG/Sound/Slider").GetComponent<Slider>();
        ToggleSound = viewComponent.transform.Find("BG/Sound/Toggle").GetComponent<Toggle>();
        BtnContinue.onClick.AddListener(OnClickContinue);
        BtnBackMain.onClick.AddListener(OnClickBackMain);
    }

    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Define.Msg_UpdateSettingPanel);
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Define.Msg_UpdateSettingPanel:
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


    private void OnClickContinue()
    {
        SendNotification(Define.Cmd_HidePanel,PanelType.Setting);
    }
    private void OnClickBackMain()
    {
        
    }
    public void ChangeLanguage()
    {
        TxTTitle.text = LanguageManager.Instance.GetWords(LanguageTag.Tag_Setting);
        BtnContinue.GetTextGameObject().text = LanguageManager.Instance.GetWords(LanguageTag.Tag_Continue);
        BtnBackMain.GetTextGameObject().text = LanguageManager.Instance.GetWords(LanguageTag.Tag_BackMain);
    }

    public void Update(object data)
    {
        SettingPanelData spd = data as SettingPanelData;
        SliderSound.value = (float)spd.SoundVoloum;
        ToggleSound.isOn = spd.SoundToggle;
        TxTLanguage.text = LanguageManager.Instance.GetWords(LanguageTag.Tag_Language);
    }
}
