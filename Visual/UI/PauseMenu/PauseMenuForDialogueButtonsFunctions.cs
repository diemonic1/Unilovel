using UnityEngine;

public class PauseMenuForDialogueButtonsFunctions : PauseMenuButtonsFunctions
{
    public override void exitGame()
    {
        _ClickSound.Play();
        pauseMenu.turnPause();
        transitionToNextScene.exitFromGame();
    }

    public override void backButton()
    {
        _ClickSound.Play();
        _menu.SetActive(true);
        _exitMenu1.SetActive(false);
        _exitMenu2.SetActive(false);
    }
}
