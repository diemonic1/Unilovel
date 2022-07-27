using UnityEngine;
using UnityEngine.UI;

public class DialogueBackground : BackgroundAnimation
{
    protected override void UpdateBackground(Image[] backgroundSprites, float xAxisParallax, float yAxisParallax, float mainClamp1, float mainClamp2, float mainClamp3)
    {
        transform.localPosition = new Vector3(xAxisParallax, yAxisParallax, transform.localPosition.z);

        backgroundSprites[0].color = new Color(0.8f + (mainClamp1 / 50000), 0.8f + (mainClamp2 / 50000), 0.8f + (mainClamp3 / 50000));

        backgroundSprites[1].color = new Color(0.95f + (mainClamp1 / 50000), 0.81f + (mainClamp2 / 100000), 0.81f + (mainClamp3 / 100000));
        backgroundSprites[2].color = new Color(0.94f + (mainClamp1 / 500000), 0.94f + (mainClamp2 / 500000), 0.94f + (mainClamp3 / 500000));

        backgroundSprites[4].color = new Color(0.8f + (mainClamp1 / 50000), 0.8f + (mainClamp2 / 50000), 0.8f + (mainClamp3 / 50000));

        backgroundSprites[5].color = new Color(0.94f + (mainClamp1 / 500000), 0.94f + (mainClamp2 / 500000), 0.94f + (mainClamp3 / 500000));

        backgroundSprites[6].color = new Color(0.96f + (mainClamp1 / 250000), 0.96f + (mainClamp2 / 250000), 0.96f + (mainClamp3 / 250000));
    }
}
