using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class LocalizationManager : MonoBehaviour
{
    private string _currentLanguage;
    private Dictionary<string, string> localizedText;

    public delegate void ChangeLangText();

    public event ChangeLangText OnLanguageChanged;

    public string CurrentLanguage
    {
        get
        {
            return _currentLanguage;
        }

        set
        {
            PlayerPrefs.SetString("Language", value);
            _currentLanguage = PlayerPrefs.GetString("Language");
            LoadLocalizedText(_currentLanguage);
        }
    }

    public void LoadLocalizedText(string languageName)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + languageName + ".json";

        string dataAsJson = File.ReadAllText(path);

        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        localizedText = new Dictionary<string, string>();

        for (int i = 0; i < loadedData.items.Length; i++)
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);

        PlayerPrefs.SetString("Language", languageName);

        SetLanguegeInMenu(languageName);

        OnLanguageChanged?.Invoke();
    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText.ContainsKey(key))
            return localizedText[key];
        else
            throw new Exception("Localized text with key \"" + key + "\" not found");
    }

    protected virtual void SetLanguegeInMenu(string languageName)
    {
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
                PlayerPrefs.SetString("Language", "ru_RU");
            else
                PlayerPrefs.SetString("Language", "en_US");
        }

        _currentLanguage = PlayerPrefs.GetString("Language");

        LoadLocalizedText(_currentLanguage);
    }
}