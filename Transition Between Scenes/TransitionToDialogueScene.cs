using System.Collections;
using UnityEngine;

public class TransitionToDialogueScene : TransitionToNextScene
{
    protected override IEnumerator StartDelay()
    {
        IsTransitionNow = true;
        yield return new WaitForSeconds(0.5f);
        OutBlackFade();
        yield return new WaitForSeconds(1.8f);
        IsTransitionNow = false;
    }
}
