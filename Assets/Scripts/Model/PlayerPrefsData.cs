using PureMVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData
{
    public MainPanelData MPD;
    public GamePanelData GPD;
    public SettingPanelData SPD;
    public RoomNodeData RND;
    public PlayerPrefsData()
    {
        MPD = new MainPanelData();
        GPD = new GamePanelData();
        SPD = new SettingPanelData();
        RND = new RoomNodeData();
    }

}
