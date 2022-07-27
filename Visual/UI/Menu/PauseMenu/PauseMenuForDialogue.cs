using UnityEngine;

public class PauseMenuForDialogue : PauseMenu
{
    [SerializeField] private GameObject _nextPhraseOfDialogButton;

    protected override void AdditionalAction()
    {
        _nextPhraseOfDialogButton.SetActive(!_nextPhraseOfDialogButton.activeSelf);
    }
}
