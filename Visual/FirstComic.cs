﻿using UnityEngine;
using UnityEngine.UI;

public class FirstComic : MonoBehaviour
{
    [SerializeField] private Text _comicText1, _comicText2, _comicText3;
    [SerializeField] private Animator _comicAnimator;

    [Header("Links to instances")]
    [SerializeField] private LocalizationManager localizationManager;
    [SerializeField] private DialogueAdditionalActions dialogueAdditionalActions;

    public void startComic()
    {
        _comicText1.text = localizationManager.GetLocalizedValue("comic_1");
        _comicText2.text = localizationManager.GetLocalizedValue("comic_2");
        _comicText3.text = localizationManager.GetLocalizedValue("comic_3");

        dialogueAdditionalActions.hideUI();
        Screen.lockCursor = true;

        _comicAnimator.Play("comic1");
    }

    public void animationEvent_comicDone()
    {
        dialogueAdditionalActions.turnOnFirstLevel();
    }
}
