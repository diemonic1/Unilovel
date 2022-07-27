using System.Collections;
using UnityEngine;

public class IconsAnimations : MonoBehaviour
{
    [SerializeField] private float _amplitude, _stepOfRotation, _stepOfMotion;
    [SerializeField] private GameObject _iconOnLevel4, _iconOnLevel5;
    [SerializeField] private CanvasGroup _iconOnLevel6First, _iconOnLevel6Second;

    public void StartChangingIconOnLevel4()
    {
        StartCoroutine(ChangeIconOnLevel4());
    }

    public void StartChangingIconOnLevel5()
    {
        StartCoroutine(ChangeIconOnLevel5());
    }

    public void StartChangingIconOnLevel6()
    {
        StartCoroutine(ChangeIconOnLevel6());
    }

    private IEnumerator ChangeIconOnLevel4()
    {
        for (int i = 0; i < 60; i++)
        {
            _iconOnLevel4.transform.localEulerAngles = new Vector3(_iconOnLevel4.transform.localEulerAngles.x, _iconOnLevel4.transform.localEulerAngles.y, _iconOnLevel4.transform.localEulerAngles.z + _stepOfRotation);
            yield return new WaitForSeconds(0.0005f);
        }
    }

    private IEnumerator ChangeIconOnLevel5()
    {
        for (int i = 0; i < _amplitude; i++)
        {
            _iconOnLevel5.transform.localPosition = new Vector3(_iconOnLevel5.transform.localPosition.x, _iconOnLevel5.transform.localPosition.y + _stepOfMotion, _iconOnLevel5.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < _amplitude; i++)
        {
            _iconOnLevel5.transform.localPosition = new Vector3(_iconOnLevel5.transform.localPosition.x, _iconOnLevel5.transform.localPosition.y - _stepOfMotion, _iconOnLevel5.transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }

        _iconOnLevel5.transform.localPosition = new Vector3(_iconOnLevel5.transform.localPosition.x, 0, _iconOnLevel5.transform.localPosition.z);
    }

    private IEnumerator ChangeIconOnLevel6()
    {
        for (int i = 0; i < 24; i++)
        {
            _iconOnLevel6First.alpha += 0.025f;
            _iconOnLevel6Second.alpha -= 0.025f;
            yield return new WaitForSeconds(0);
        }

        _iconOnLevel6First.alpha = 1;
        _iconOnLevel6Second.alpha = 0.4f;

        (_iconOnLevel6Second, _iconOnLevel6First) = (_iconOnLevel6First, _iconOnLevel6Second);
    }
}
