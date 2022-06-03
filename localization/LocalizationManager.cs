using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private string _currentLanguage;
    private Dictionary<string, string> localizedText;

	public delegate void ChangeLangText();
    public event ChangeLangText OnLanguageChanged;

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

    public void LoadLocalizedText(string languageName)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + languageName + ".json";

        string dataAsJson;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(path);
            while (!reader.isDone) { }

            dataAsJson = reader.text;
        }
        else
            dataAsJson = File.ReadAllText(path);

        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        localizedText = new Dictionary<string, string>();

        for (int i = 0; i < loadedData.items.Length; i++)
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);

        PlayerPrefs.SetString("Language", languageName);

        setLanguegeInMenu(languageName);

        OnLanguageChanged?.Invoke();
    }

    protected virtual void setLanguegeInMenu(string languageName) { }

    public string GetLocalizedValue(string key)
    {
        if (localizedText.ContainsKey(key))
            return localizedText[key];
        else
            throw new Exception("Localized text with key \"" + key + "\" not found");
    }

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
}