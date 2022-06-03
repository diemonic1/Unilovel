using UnityEngine;

public class FinalComic : MonoBehaviour
{
    [SerializeField] private AudioSource _soundRing;
    [SerializeField] private Animator _comicAnimator;

    [Header("Links to instances")]
    [SerializeField] private MainMenu mainMenu;

    public void startComic()
    {
        Screen.lockCursor = true;
        _comicAnimator.Play("comic2");
    }

    public void animationEvent_endOfComic()
    {
        mainMenu.OpenMenu();
    }

    public void animationEvent_ringSoundPlay()
    {
        _soundRing.Play();
    }
}
