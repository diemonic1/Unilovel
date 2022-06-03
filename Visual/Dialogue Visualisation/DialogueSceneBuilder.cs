using System.Collections;
using UnityEngine;

public class DialogueSceneBuilder : MonoBehaviour
{
    [SerializeField] private debug _testDialogue;
    
    [SerializeField] private GameObject[] _backgrounds;
    [SerializeField] private GameObject[] _musicPlaylist;

    private int _currentDialogue = -10;
    private enum debug
    {
        none = 0,
        Alice = 1,
        Anasteisha = 2,
        Citrinnefer = 3,
        DekabrinaAndMarie = 4,
        Anna = 5,
        Lusin = 6,
        Isidora = 7,
        Anemone = 8,
    }

    public int getCurrentDialogueNumber() 
    {
        if (_testDialogue > 0) 
            PlayerPrefs.SetInt("dial", ((int)(_testDialogue) - 1));

        if (_currentDialogue == -10) 
            _currentDialogue = PlayerPrefs.GetInt("dial");

        return _currentDialogue;
    }

    private void Start()
    {
        _currentDialogue = getCurrentDialogueNumber();

        _backgrounds[_currentDialogue].SetActive(true);
        _musicPlaylist[_currentDialogue].SetActive(true);

        StartCoroutine(StartDialogueDelay());
    }

    private IEnumerator StartDialogueDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Screen.lockCursor = false;

        StartDialogue();
    }

    private void StartDialogue() 
    {
        // It uses a ready-made asset for line-by-line output of dialog text.
        GetComponent<dialogueOutput>().startOutput(_currentDialogue);
    }
}

