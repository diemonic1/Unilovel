using UnityEngine;

public class AnimationEventDestroyThisObject : MonoBehaviour
{
    public void animationEvent_destroyObject() 
    {
        Destroy(gameObject);
    }
}
