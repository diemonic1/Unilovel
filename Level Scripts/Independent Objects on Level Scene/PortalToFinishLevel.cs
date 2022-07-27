using UnityEngine;

public class PortalToFinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.CompareTag("Player"))
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().FinishLevel();
    }
}
