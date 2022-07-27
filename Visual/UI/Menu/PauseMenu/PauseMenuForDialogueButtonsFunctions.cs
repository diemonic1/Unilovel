using UnityEngine;

public class PauseMenuForDialogueButtonsFunctions : PauseMenuButtonsFunctions
{
    public override void ExitFromGame()
    {
        _clickSound.Play();
        pauseMenu.TurnPause();
        transitionToNextScene.ExitFromGame();
    }

    public override void BackButton()
    {
        _clickSound.Play();
        _menu.SetActive(true);
        _exitMenu1.SetActive(false);
        _exitMenu2.SetActive(false);
    }
}
