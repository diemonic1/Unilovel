using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private float _delayUpward, _delayDownward, _stepUpward, _stepDownward;

    private bool _controlVolumeBySlider;

    public void StartFadingVolume()
    {
        _controlVolumeBySlider = false;
        StartCoroutine(FadingVolume(Mathf.Round((PlayerPrefs.GetInt("masterVolumePrefs") - 100) / 2)));
    }

    private void Start()
    {
        _masterMixerGroup.audioMixer.SetFloat("MasterVolume", -80);

        if (PlayerPrefs.GetInt("masterVolumePrefs") != 0)
            StartCoroutine(RisingVolume(-80));
    }

    private IEnumerator RisingVolume(float currentVolume)
    {
        if (currentVolume < Mathf.Round((PlayerPrefs.GetInt("masterVolumePrefs") - 100) / 2))
        {
            currentVolume += _stepUpward;
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", currentVolume);
            yield return new WaitForSeconds(_delayUpward);
            StartCoroutine(RisingVolume(currentVolume));
        }
        else
        {
            _controlVolumeBySlider = true;
        }
    }

    private IEnumerator FadingVolume(float currentVolume)
    {
        if (currentVolume > -80)
        {
            currentVolume -= _stepDownward;
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", currentVolume);
            yield return new WaitForSeconds(_delayDownward);
            StartCoroutine(FadingVolume(currentVolume));
        }
    }

    private void Update()
    {
        if (_controlVolumeBySlider)
        {
            if (PlayerPrefs.GetInt("masterVolumePrefs") == 0)
                _masterMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Round(PlayerPrefs.GetInt("masterVolumePrefs") - 100));
            else
                _masterMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Round((PlayerPrefs.GetInt("masterVolumePrefs") - 100) / 2));
        }
    }
}
