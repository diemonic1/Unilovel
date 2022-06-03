using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private float _delayUpward, _delayDownward, _stepUpward, _stepDownward;

    private bool _controlVolumeBySlider;

    private void Start()
    {
        _masterMixerGroup.audioMixer.SetFloat("MasterVolume", -80);

        if (PlayerPrefs.GetInt("masterVolumePrefs") != 0)
            StartCoroutine(risingVolume(-80));
    }

    private IEnumerator risingVolume(float _currentVolume)
    {
        if (_currentVolume < Mathf.Round((PlayerPrefs.GetInt("masterVolumePrefs") - 100) / 2))
        {
            _currentVolume += _stepUpward;
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", _currentVolume);
            yield return new WaitForSeconds(_delayUpward);
            StartCoroutine(risingVolume(_currentVolume));
        }
        else
            _controlVolumeBySlider = true;
    }

    public void startFadingVolume()
    {
        _controlVolumeBySlider = false;
        StartCoroutine(fadingVolume(Mathf.Round((PlayerPrefs.GetInt("masterVolumePrefs") - 100) / 2)));
    }

    private IEnumerator fadingVolume(float _currentVolume)
    {
        if (_currentVolume > -80)
        {
            _currentVolume -= _stepDownward;
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", _currentVolume);
            yield return new WaitForSeconds(_delayDownward);
            StartCoroutine(fadingVolume(_currentVolume));
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
