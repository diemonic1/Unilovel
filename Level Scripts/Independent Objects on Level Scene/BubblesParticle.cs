using System.Collections;
using UnityEngine;

public class BubblesParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _particleSystem.Stop();
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        float _delayBeforePlay = Random.Range(3f, 4.5f);
        float _delayBeforeStop = Random.Range(1.5f, 3f);

        yield return new WaitForSeconds(_delayBeforePlay);
        _particleSystem.Play();

        yield return new WaitForSeconds(_delayBeforeStop);
        _particleSystem.Stop();

        StartCoroutine(loop());
    }

    private void FixedUpdate() 
    {
        transform.position = _player.position;
    }
}
