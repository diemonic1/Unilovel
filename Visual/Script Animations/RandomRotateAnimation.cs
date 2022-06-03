using UnityEngine;

public class RandomRotateAnimation : MonoBehaviour
{
    private float _zRotationRatio;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(-350, 350));

        if (Random.Range(0, 2) == 0)
            _zRotationRatio = Random.Range(-4.5f, -2f);
        else
            _zRotationRatio = Random.Range(2f, 4.5f);
    }

    private void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + _zRotationRatio);
    }
}
