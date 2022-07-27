using System.Collections;
using UnityEngine;

public class BubblesParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _particleSystem.Stop();
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        float delayBeforePlay = Random.Range(3f, 4.5f);
        float delayBeforeStop = Random.Range(1.5f, 3f);

        yield return new WaitForSeconds(delayBeforePlay);
        _particleSystem.Play();

        yield return new WaitForSeconds(delayBeforeStop);
        _particleSystem.Stop();

        StartCoroutine(Loop());
    }

    private void FixedUpdate()
    {
        transform.position = _player.position;
    }
}
