using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    private LanguageType LanguageType = LanguageType.English;
    private Dictionary<string, string> ChineseDic = new Dictionary<string, string>();
    private Dictionary<string, string> EnglishDic = new Dictionary<string, string>();
    public static LanguageManager Instance;
    private void Awake()
    {
        Instance = this;
        AddWords();
        LoadConfig();
    }
    private void Start()
    {

    }
    private void AddWords()
    {
        ChineseDic.Add("新游戏", "新游戏");
        ChineseDic.Add("继续", "继续");
        ChineseDic.Add("语言", "简体中文");
        ChineseDic.Add("设置", "设置");
        ChineseDic.Add("标题页面", "返回标题页面");

        EnglishDic.Add("新游戏", "New Game");
        EnglishDic.Add("继续", "Continue");
        EnglishDic.Add("语言", "English");
        EnglishDic.Add("设置", "Setting");
        EnglishDic.Add("标题页面", "Back Main Menu");
    }
    public string GetWords(string tag)
    {
        if (LanguageType == LanguageType.Chinese)
            return ChineseDic[tag];
        else
            return EnglishDic[tag];
    }
    public void ChangLanguage(LanguageType language)
    {
        LanguageType = language;
        AppFacade.GetInstance(() => new AppFacade()).SendNotification(Define.Msg_ChangeLanguage);
    }
    private void LoadConfig()
    {
        PlayerPrefsDataProxy ppdProxy= AppFacade.GetInstance(() => new AppFacade()).RetrieveProxy(PlayerPrefsDataProxy.NAME) as PlayerPrefsDataProxy;
        LanguageType = ppdProxy.VO.SPD.LanguageType;
    }


}
