using UnityEngine;

public class TriggerNumberRespawnPoint : MonoBehaviour
{
    [SerializeField] private int countWallPortal;

    void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.tag == "Player")
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().PortalCounter = countWallPortal;
    }
}