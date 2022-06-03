using UnityEngine;

public class PortalToFinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.tag == "Player")
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().finishLevel();
    }
}
