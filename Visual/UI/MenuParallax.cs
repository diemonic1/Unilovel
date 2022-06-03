using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    private float _xAxisParallax, _yAxisParallax, _parallaxRatio = 25;

    void Update()
    {
        _xAxisParallax = Mathf.Clamp(((Input.mousePosition.x - Screen.width/3) / Screen.width) * _parallaxRatio, -10, 10);
        _yAxisParallax = Mathf.Clamp(((Input.mousePosition.y - Screen.height/2) / Screen.height) * _parallaxRatio, -10, 10);
    }

    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(_yAxisParallax, -_xAxisParallax, transform.localRotation.z);
    }
}
