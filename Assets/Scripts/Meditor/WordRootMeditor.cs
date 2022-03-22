using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRootMeditor : Mediator
{
    public static string Name = "WordRootMeditor";
    public WordRootMeditor(GameObject viewComponent) : base(NAME, viewComponent)
    {

    }
}
