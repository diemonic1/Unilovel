using UnityEngine;

public class LettersAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _letterW, _letterA, _letterS, _letterD;

    [SerializeField] private Sprite[] _darkLetterTextures;
    [SerializeField] private Sprite[] _lightLetterTextures;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical Axis") > 0)
            _letterW.sprite = _lightLetterTextures[0];
        else
            _letterW.sprite = _darkLetterTextures[0];

        if (Input.GetAxis("Vertical Axis") < 0)
            _letterS.sprite = _lightLetterTextures[2];
        else
            _letterS.sprite = _darkLetterTextures[2];

        if (Input.GetAxis("Horizontal Axis") > 0)
            _letterD.sprite = _lightLetterTextures[3];
        else
            _letterD.sprite = _darkLetterTextures[3];

        if (Input.GetAxis("Horizontal Axis") < 0)
            _letterA.sprite = _lightLetterTextures[1];
        else
            _letterA.sprite = _darkLetterTextures[1];
    }
}
