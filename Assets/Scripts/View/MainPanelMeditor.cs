using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanelMeditor : Mediator
{
    public static string NAME = "MainPanelMeditor";

    private Button BtnNewGame;
    private Button BtnContinueGame;
    private Button BtnSetting;
    public MainPanelMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {

    }
}
