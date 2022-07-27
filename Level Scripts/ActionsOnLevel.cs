using System.Collections;
using UnityEngine;

public class ActionsOnLevel : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particlesGroupFirst, _particlesGroupSecond;
    [SerializeField] private GameObject _groupOfBlue, _groupOfRed;
    [SerializeField] private Rigidbody _playerRigidbody;

    private bool _canSwitchParticles;
    private int _currentLevel = -1;

    [Header("Links to instances")]
    [SerializeField] private LevelSceneBuilder levelSceneBuilder;
    [SerializeField] private IconsAnimations iconsAnimations;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_currentLevel == -1)
                _currentLevel = levelSceneBuilder.CurrentLevel;

            if (_currentLevel == 4)
            {
                Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);

                if (!_canSwitchParticles)
                {
                    _canSwitchParticles = true;
                    StartCoroutine(SwitchParticles());
                }

                iconsAnimations.StartChangingIconOnLevel4();
            }
            else if (_currentLevel == 5)
            {
                _playerRigidbody.AddForce(new Vector3(0f, 0.7f, 0f), ForceMode.Impulse);

                iconsAnimations.StartChangingIconOnLevel5();
            }
            else if (_currentLevel == 6)
            {
                _groupOfBlue.SetActive(!_groupOfBlue.activeSelf);
                _groupOfRed.SetActive(!_groupOfRed.activeSelf);

                iconsAnimations.StartChangingIconOnLevel6();
            }
        }
    }

    private IEnumerator SwitchParticles()
    {
        for (int i = 0; i < 4; i++)
        {
            _particlesGroupFirst[i].Stop();
            _particlesGroupSecond[i].Stop();
        }

        yield return new WaitForSeconds(1.5f);

        ParticleSystem[] currentParticlesGroup;

        if (Physics.gravity.y < 0)
            currentParticlesGroup = _particlesGroupFirst;
        else
            currentParticlesGroup = _particlesGroupSecond;

        for (int i = 0; i < 4; i++)
            currentParticlesGroup[i].Play();

        _canSwitchParticles = false;
    }
}
