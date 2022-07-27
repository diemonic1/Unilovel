using UnityEngine;

public class LockRotateOnCamera : MonoBehaviour
{
    private GameObject _camera;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position, Vector3.up);
    }
}
