using UnityEngine;

public class FallingItem : MonoBehaviour
{
    private float _randomStepAxisX, _randomStepAxisY, _randomStepAxisZ;
    private float _currentTimeOfLife;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _randomStepAxisX = Random.Range(-1.5f, 1.5f);
        _randomStepAxisY = Random.Range(-1.5f, 1.5f);
        _randomStepAxisZ = Random.Range(-1.5f, 1.5f);
    }

    private void FixedUpdate()
    {
        _currentTimeOfLife += Time.deltaTime;

        _rigidbody.velocity += new Vector3(0, -1 * Mathf.Sign(Physics.gravity.y) * 0.025f, 0);
        
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + _randomStepAxisX, transform.localEulerAngles.y + _randomStepAxisY, transform.localEulerAngles.z + _randomStepAxisZ);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y) > 100f || _currentTimeOfLife > 20f)
            Destroy(gameObject);
    }
}
