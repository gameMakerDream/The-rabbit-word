using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelData
{
    public double SoundVoloum;
    public LanguageType LanguageType;
    public bool SoundToggle;
    public SettingPanelData()
    {
        SoundVoloum = 1;
        LanguageType = LanguageType.English;
        SoundToggle = true;
    }
}
