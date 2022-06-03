using System.Collections;
using UnityEngine;

public class BackgroundColorAnimation : MonoBehaviour
{
    [SerializeField] private int _divisor;
    [SerializeField] private float _minValueRed, _minValueGreen, _minValueBlue;

    private float _mainClampRed, _randomStepRed, _mainClampGreen, _randomStepGreen, _mainClampBlue, _randomStepBlue;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        _randomStepRed = -3;
        _randomStepGreen = -2;
        _randomStepBlue = -4;
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        _randomStepRed = -Mathf.Sign(_randomStepRed) * Random.Range(8, 17);
        _randomStepGreen = -Mathf.Sign(_randomStepGreen) * Random.Range(8, 17);
        _randomStepBlue = -Mathf.Sign(_randomStepBlue) * Random.Range(8, 17);

        yield return new WaitForSeconds(Random.Range(9, 15));
        StartCoroutine(loop());
    }

    private void FixedUpdate()
    {
        _mainClampRed += _randomStepRed;
        _mainClampRed = Mathf.Clamp(_mainClampRed, 0, 10000);
        _mainClampGreen += _randomStepGreen;
        _mainClampGreen = Mathf.Clamp(_mainClampGreen, 0, 10000);
        _mainClampBlue += _randomStepBlue;
        _mainClampBlue = Mathf.Clamp(_mainClampBlue, 0, 10000);

        _camera.backgroundColor = new Color(_minValueRed + _mainClampRed / _divisor, _minValueGreen + _mainClampGreen / _divisor, _minValueBlue + _mainClampBlue / _divisor);
    }
}
