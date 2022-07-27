using UnityEngine;

public class FinalComic : MonoBehaviour
{
    [SerializeField] private AudioSource _soundRing;
    [SerializeField] private Animator _comicAnimator;

    [Header("Links to instances")]
    [SerializeField] private MainMenu mainMenu;

    public void StartComic()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _comicAnimator.Play("comic2");
    }

    public void AnimationEvent_endOfComic()
    {
        mainMenu.OpenMenu();
    }

    public void AnimationEvent_ringSoundPlay()
    {
        _soundRing.Play();
    }
}
