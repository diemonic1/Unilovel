using UnityEngine;
using UnityEngine.UI;

public class MenuBackground : BackgroundAnimation
{
    [SerializeField] private GameObject _portalSpriteInMainMenu, _girlSpriteInMainMenu;
    [SerializeField] private float _portalParallaxRatio, _girlParallaxRatio;

    protected override void UpdateBackground(Image[] backgroundSprites, float xAxisParallax, float yAxisParallax, float mainClamp1, float mainClamp2, float mainClamp3)
    {
        transform.localPosition = new Vector3(xAxisParallax, yAxisParallax, transform.localPosition.z);

        backgroundSprites[0].color = new Color(0.8f + (mainClamp1 / 50000), 0.8f + (mainClamp2 / 50000), 0.8f + (mainClamp3 / 50000));

        _portalSpriteInMainMenu.transform.localPosition = new Vector3(_portalParallaxRatio * xAxisParallax, _portalParallaxRatio * yAxisParallax, _portalSpriteInMainMenu.transform.localPosition.z);
        _girlSpriteInMainMenu.transform.localPosition = new Vector3(_girlParallaxRatio * xAxisParallax, _girlParallaxRatio * yAxisParallax, _girlSpriteInMainMenu.transform.localPosition.z);
    }
}
