using UnityEngine;

public class EndOfDespawnAnimtion : MonoBehaviour
{
    [Header("Links to instances")]
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    public void AnimationEvent_endOfDespawnAnimation()
    {
        playerSpawnAndRespawn.EndOfDespawnAnimation();
    }
}
