using UnityEngine;

public class PauseMenuForDialogue : PauseMenu
{
    [SerializeField] private GameObject _nextPhraseOfDialogButton;

    protected override void additionalAction()
    {
        _nextPhraseOfDialogButton.SetActive(!_nextPhraseOfDialogButton.activeSelf);
    }
}
