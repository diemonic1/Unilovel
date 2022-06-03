using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LoaderScript : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private AudioSource _fluteSound;
    [SerializeField] private float _fluteSoundDelay;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("masterVolumePrefs") != 0)
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Round((PlayerPrefs.GetFloat("masterVolumePrefs") - 100) / 2));

        Screen.lockCursor = true;

        StartCoroutine(playFluteSound());
    }

    private IEnumerator playFluteSound()
    {
        yield return new WaitForSeconds(_fluteSoundDelay);
        _fluteSound.Play();
    }

    public void animationEvent_exitLoader()
    {
        Application.LoadLevel(PlayerPrefs.GetString("nameOfNextScene"));
    }
}