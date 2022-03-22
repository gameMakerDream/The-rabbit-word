using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootMeditor : Mediator
{
    public static string NAME = "UIRootMeditor";
    // Start is called before the first frame update
    public UIRootMeditor(GameObject viewComponent):base(NAME, viewComponent)
    {
        
    }
}
