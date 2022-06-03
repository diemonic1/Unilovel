using UnityEngine;

public class MainMenuUIBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _newGameMenuButton, _continueButton, _exitMenuButton, _loadLevelButton;

    public void buildMenuUI() 
    {
        if (PlayerPrefs.GetInt("progress") == 0)
        {
            _continueButton.SetActive(false);
            _loadLevelButton.SetActive(false);
            _newGameMenuButton.transform.localPosition = new Vector2(0, 90);
            _exitMenuButton.transform.localPosition = new Vector2(0, 50);
        }
        else if (PlayerPrefs.GetInt("EndGame") == 1)
        {
            _continueButton.SetActive(false);
            _newGameMenuButton.transform.localPosition = new Vector2(0, 90);
            _loadLevelButton.transform.localPosition = new Vector2(0, 50);
            _exitMenuButton.transform.localPosition = new Vector2(0, 10);
        }
        else
        {
            _loadLevelButton.SetActive(false);
            _exitMenuButton.transform.localPosition = new Vector2(0, 10);
        }
    }
}
