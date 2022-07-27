using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LoaderScript : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private AudioSource _fluteSound;
    [SerializeField] private float _fluteSoundDelay;

    public void AnimationEvent_exitLoader()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("nameOfNextScene"));
    }

    private void Start()
    {
        if (PlayerPrefs.GetFloat("masterVolumePrefs") != 0)
            _masterMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Round((PlayerPrefs.GetFloat("masterVolumePrefs") - 100) / 2));

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(PlayFluteSound());
    }

    private IEnumerator PlayFluteSound()
    {
        yield return new WaitForSeconds(_fluteSoundDelay);
        _fluteSound.Play();
    }
}