using UnityEngine;

public class DialogueBackground : BackgroundAnimation
{
    protected override void FixedUpdate()
    {
        transform.localPosition = new Vector3(_xAxisParallax, _yAxisParallax, transform.localPosition.z);

        _backgroundSprites[0].color = new Color(0.8f + (_mainClamp1 / 50000), 0.8f + (_mainClamp2 / 50000), 0.8f + (_mainClamp3 / 50000));

        _backgroundSprites[1].color = new Color(0.95f + (_mainClamp1 / 50000), 0.81f + (_mainClamp2 / 100000), 0.81f + (_mainClamp3 / 100000));
        _backgroundSprites[2].color = new Color(0.94f + (_mainClamp1 / 500000), 0.94f + (_mainClamp2 / 500000), 0.94f + (_mainClamp3 / 500000));

        _backgroundSprites[4].color = new Color(0.8f + (_mainClamp1 / 50000), 0.8f + (_mainClamp2 / 50000), 0.8f + (_mainClamp3 / 50000));

        _backgroundSprites[5].color = new Color(0.94f + (_mainClamp1 / 500000), 0.94f + (_mainClamp2 / 500000), 0.94f + (_mainClamp3 / 500000));

        _backgroundSprites[6].color = new Color(0.96f + (_mainClamp1 / 250000), 0.96f + (_mainClamp2 / 250000), 0.96f + (_mainClamp3 / 250000));
    }
}
