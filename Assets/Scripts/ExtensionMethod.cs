using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethod
{
    public static Text GetTextGameObject(this Button button)
    {
        return button.transform.Find("Text").GetComponent<Text>();
    }
}
