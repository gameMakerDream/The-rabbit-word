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
        ChineseDic.Add("����Ϸ", "����Ϸ");
        ChineseDic.Add("����", "����");
        ChineseDic.Add("����", "��������");
        ChineseDic.Add("����", "����");
        ChineseDic.Add("����ҳ��", "���ر���ҳ��");

        EnglishDic.Add("����Ϸ", "New Game");
        EnglishDic.Add("����", "Continue");
        EnglishDic.Add("����", "English");
        EnglishDic.Add("����", "Setting");
        EnglishDic.Add("����ҳ��", "Back Main Menu");
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
