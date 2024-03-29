using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGameOnLvl7
{
    public class VisualLvl7 : MonoBehaviour
    {
        [SerializeField] private GameObject _miniGameUI, _counter, _exitPortalRoot, _exitPortal;
        [SerializeField] private TMP_Text _counterText, _topInscription, _bottomInscription;
        [SerializeField] private Image _timer;
        [SerializeField] private RectTransform _timerMask, _timerObject;

        private Color _white = new (255, 255, 255, 255);
        private Color _red = new (255, 0, 0, 255);
        private Color _green = new (0, 255, 0, 255);
        private Color _blue = new (0, 0, 255, 255);
        private Color _orange = new (255, 48, 0, 255);
        private Color _yellow = new (240, 255, 0, 255);

        [Header("Links to instances")]
        [SerializeField] private MiniGameOnLvl7Logic miniGameOnLvl7Logic;
        private LocalizationManager localizationManager;

        public void WriteOnAnyColor()
        {
            _topInscription.text = localizationManager.GetLocalizedValue("lvl_7_upperText_1") + "\n\n";
            _bottomInscription.text = "\n" + localizationManager.GetLocalizedValue("color_6");

            _topInscription.color = _white;
            _bottomInscription.color = _white;
        }

        public void WriteOnTopInscription(string key)
        {
            _topInscription.text = localizationManager.GetLocalizedValue(key) + "\n\n";
        }

        public void WriteOnLowerText(string currentTarget)
        {
            _bottomInscription.text = "\n" + localizationManager.GetLocalizedValue("color_" + currentTarget);
        }

        public void ChangeTextColor(int currentTarget)
        {
            switch (currentTarget)
            {
                case 0:
                    _bottomInscription.color = _white;
                    break;
                case 1:
                    _bottomInscription.color = _red;
                    break;
                case 2:
                    _bottomInscription.color = _green;
                    break;
                case 3:
                    _bottomInscription.color = _blue;
                    break;
                case 4:
                    _bottomInscription.color = _orange;
                    break;
                case 5:
                    _bottomInscription.color = _yellow;
                    break;
            }
        }

        public void WinVisulisation()
        {
            _miniGameUI.SetActive(false);

            _exitPortalRoot.transform.localPosition = new Vector3(0, -2.21f, 0);
            _exitPortal.transform.localScale = new Vector3(0, 0, 0);

            StartCoroutine(RisePortalWin(0));
        }

        private void Awake()
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }

        private void Start()
        {
            if (PlayerPrefs.GetString("Language") == "en_US")
            {
                _timerMask.sizeDelta = new Vector2(1.7f, 1.7f);
                _timerObject.sizeDelta = new Vector2(1.7f, 1.7f);
                _counter.transform.localPosition = new Vector3(0, 0.5f, 0);
            }
            else if (PlayerPrefs.GetString("Language") == "ru_RU")
            {
                _timerMask.sizeDelta = new Vector2(2.05f, 2.05f);
                _timerObject.sizeDelta = new Vector2(2.05f, 2.05f);
                _counter.transform.localPosition = new Vector3(0, 0.57f, 0);
            }

            WriteOnAnyColor();
        }

        private void Update()
        {
            _timer.fillAmount = miniGameOnLvl7Logic.TimeBeforeDeath;
            _counterText.text = miniGameOnLvl7Logic.CountBeforeWin.ToString();
        }

        private IEnumerator RisePortalWin(float x)
        {
            if (x < 0.06)
            {
                _exitPortal.transform.localScale = new Vector3(x, x, x);
                yield return new WaitForSeconds(0.0025f);
                StartCoroutine(RisePortalWin(x + 0.001f));
            }
            else
            {
                _exitPortal.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            }
        }
    }
}
