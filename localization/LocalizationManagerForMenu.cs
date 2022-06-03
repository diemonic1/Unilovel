using UnityEngine;

public class LocalizationManagerForMenu : LocalizationManager
{
    [Header("Links to instances")]
    [SerializeField] private MainMenu mainMenu;

    protected override void setLanguegeInMenu(string languageName) 
    {
        mainMenu.dropDownMenuSetLanguage(languageName);
    }
}