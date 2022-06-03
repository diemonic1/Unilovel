using UnityEngine.UI;
using UnityEngine;

public class CharacterNames : MonoBehaviour
{
    [SerializeField] private string[] _names;
    [SerializeField] private string[] _namesForLevel4;

    [SerializeField] private Animator _nameAnimator;

    [SerializeField] private GameObject _nameObject1, _nameObject2, _nameObject3, _nameQuestionsObject;

    private Text _name1, _name2, _name3, _nameQuestions;

    private int _currentDialogue = -10, _thirdDialogueCounter = 0;

    [Header("Links to instances")]
    [SerializeField] private LocalizationManager localizationManager;
    [SerializeField] private DialogueSceneBuilder dialogueSceneBuilder;

    private void Start()
    {
        _currentDialogue = dialogueSceneBuilder.getCurrentDialogueNumber();

        _name1 = _nameObject1.GetComponent<Text>();
        _name2 = _nameObject2.GetComponent<Text>();
        _name3 = _nameObject3.GetComponent<Text>();
        _nameQuestions = _nameQuestionsObject.GetComponent<Text>();
    }

    public void showName()
    {
        if (_currentDialogue != 3)
            _name1.text = localizationManager.GetLocalizedValue(_names[_currentDialogue]);
        else
        {
            _name1.text = localizationManager.GetLocalizedValue(_namesForLevel4[0]);
            _name2.text = localizationManager.GetLocalizedValue(_namesForLevel4[1]);
            _name3.text = localizationManager.GetLocalizedValue(_namesForLevel4[2]);
        }

        if (_currentDialogue != 3 || _thirdDialogueCounter == 0)
        {
            _thirdDialogueCounter++;

            if (_currentDialogue == 0) 
            {
                _nameQuestionsObject.SetActive(false);
                _nameAnimator.speed = 1.2f;
            }

            _nameAnimator.Play("openName1");
        }
        else if (_thirdDialogueCounter == 1) // in the third dialog this opens 3 names
        {
            _thirdDialogueCounter++;
            _nameAnimator.Play("openName2");
        }
        else
            _nameAnimator.Play("openName3");
    }

    public void hideName()
    {
        _nameObject1.SetActive(false);
        _nameObject2.SetActive(false);
        _nameObject3.SetActive(false);
    }
}

