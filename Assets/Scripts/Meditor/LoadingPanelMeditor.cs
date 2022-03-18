using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanelMeditor : Mediator
{
    public new static string NAME = "LoadingPanelMeditor";
    private Image ProgressContent;
    private Text ProgressText;
    private GameObject View
    {
        get { return (GameObject)ViewComponent; }

    }
    public LoadingPanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {
        ProgressContent = viewComponent.transform.Find("FillContent").GetComponent<Image>();
        ProgressText = ProgressContent.transform.Find("Text").GetComponent<Text>();
    }


    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
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

    private void SetProgress(float progress)
    {
        ProgressContent.fillAmount=progress;
        ProgressText.text = (int)progress + "%";                           
    }

}
