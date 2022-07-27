using UnityEngine;

public class KillingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.CompareTag("Player"))
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().RespawnPlayer();
    }
}
