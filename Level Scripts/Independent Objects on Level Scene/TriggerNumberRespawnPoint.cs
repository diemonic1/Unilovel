using UnityEngine;

public class TriggerNumberRespawnPoint : MonoBehaviour
{
    [SerializeField] private int countWallPortal;

    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.CompareTag("Player"))
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().PortalCounter = countWallPortal;
    }
}