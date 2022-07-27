using UnityEngine;

public class MenuBackground : BackgroundAnimation
{
    [SerializeField] private GameObject _portalSpriteInMainMenu, _girlSpriteInMainMenu;
    [SerializeField] private float _portalParallaxRatio, _girlParallaxRatio;

    protected override void FixedUpdate()
    {
        transform.localPosition = new Vector3(_xAxisParallax, _yAxisParallax, transform.localPosition.z);

        _backgroundSprites[0].color = new Color(0.8f + (_mainClamp1 / 50000), 0.8f + (_mainClamp2 / 50000), 0.8f + (_mainClamp3 / 50000));

        _portalSpriteInMainMenu.transform.localPosition = new Vector3(_portalParallaxRatio * _xAxisParallax, _portalParallaxRatio * _yAxisParallax, _portalSpriteInMainMenu.transform.localPosition.z);
        _girlSpriteInMainMenu.transform.localPosition = new Vector3(_girlParallaxRatio * _xAxisParallax, _girlParallaxRatio * _yAxisParallax, _girlSpriteInMainMenu.transform.localPosition.z);
    }
}
