using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] protected Image[] _backgroundSprites;

    protected float _xAxisParallax, _yAxisParallax, _mainClamp1, _mainClamp2, _mainClamp3;
    private readonly float _parallaxRatio = 10;
    private float _randomStep1, _randomStep2, _randomStep3;

    protected virtual void FixedUpdate()
    {
    }

    private void Start()
    {
        _randomStep1 = -3;
        _randomStep2 = -2;
        _randomStep3 = -4;
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        _randomStep1 = -Mathf.Sign(_randomStep1) * Random.Range(5, 14);
        _randomStep2 = -Mathf.Sign(_randomStep2) * Random.Range(5, 14);
        _randomStep3 = -Mathf.Sign(_randomStep3) * Random.Range(5, 14);

        yield return new WaitForSeconds(Random.Range(3, 9));
        StartCoroutine(Loop());
    }

    private void Update()
    {
        _xAxisParallax = Mathf.Clamp((Input.mousePosition.x / Screen.width) * _parallaxRatio, 0, 10);
        _yAxisParallax = Mathf.Clamp((Input.mousePosition.y / Screen.height) * _parallaxRatio, 0, 10);

        _mainClamp1 += _randomStep1;
        _mainClamp1 = Mathf.Clamp(_mainClamp1, 0, 10000);
        _mainClamp2 += _randomStep2;
        _mainClamp2 = Mathf.Clamp(_mainClamp2, 0, 10000);
        _mainClamp3 += _randomStep3;
        _mainClamp3 = Mathf.Clamp(_mainClamp3, 0, 10000);
    }
}
