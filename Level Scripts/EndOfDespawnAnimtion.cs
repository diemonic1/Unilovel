using UnityEngine;

public class EndOfDespawnAnimtion : MonoBehaviour
{
    [Header("Links to instances")]
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    public void animationEvent_endOfDespawnAnimation()
    {
        playerSpawnAndRespawn.endOfDespawnAnimation();
    }
}
