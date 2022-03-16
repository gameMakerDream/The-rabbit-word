using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PanelType
{
    Main,
    Game,
    Setting,
    Photo,
    Loading,
    RoomNode,
    Room,
    RabbitNode,
    Rabbit

}
public enum LanguageType
{
    Chinese,
    English
}
public enum RoomType
{
    None = -1,
    Carrot = 0,
    Stone = 1,
    Happy = 2,
    Rest = 3
}
public enum RoomState
{
    Invalid,
    Valid
}
public enum RabbitState
{
    None,
    Busy,
    Idle,
}
public class Define
{

    public static int RoomY = 0;
    public static int RoomX = 0;
    public static int AddRoomPanelX = 0;
    public static int AddRoomPanelY = 0;






    public const string Cmd_StartUp = "Cmd_StartUp";
    public const string Cmd_StartGame = "Cmd_StartGame";
    public const string Cmd_OpenPanel = "Cmd_OpenPanel";
    public const string Cmd_HidePanel = "Cmd_HidePanel";
    public const string Cmd_AddRoom = "Cmd_AddRoom";




    public const string Msg_ChangeVolume = "Msg_ChangeVolume";
    public const string Msg_ChangeLanguage = "Msg_ChangeLanguage";
    public const string Msg_UpdateMainPanel = "Msg_UpdateMainPanel";
    public const string Msg_UpdateGamePanel = "Msg_UpdateGamePanel";
    public const string Msg_UpdateSettingPanel = "Msg_UpdateSettingPanel";
    public const string Msg_LoadRoom = "Msg_LoadRoom";
    public const string Msg_AddRoom = "Msg_AddRoom";
    public const string Msg_AddRoomComplete = "Msg_AddRoomComplete";



}















public class LanguageTag
{
    public const string Tag_Continue = "继续";
    public const string Tag_NewGame = "新游戏";
    public const string Tag_Setting = "设置";
    public const string Tag_Language = "语言";
    public const string Tag_BackMain = "标题界面";

}
