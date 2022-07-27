using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key;

    private Text _currentText;

    [Header("Links to instances")]
    private LocalizationManager localizationManager;

    protected virtual void UpdateText()
    {
        if (gameObject == null)
            return;

        if (localizationManager == null)
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();

        if (_currentText == null)
            _currentText = GetComponent<Text>();

        _currentText.text = localizationManager.GetLocalizedValue(key);
    }

    private void Awake()
    {
        if (localizationManager == null)
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();

        if (_currentText == null)
            _currentText = GetComponent<Text>();

        localizationManager.OnLanguageChanged += UpdateText;
    }

    private void Start()
    {
        UpdateText();
    }

    private void OnDestroy()
    {
        localizationManager.OnLanguageChanged -= UpdateText;
    }
}