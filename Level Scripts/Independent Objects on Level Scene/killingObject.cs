using UnityEngine;

public class killingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.tag == "Player")
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().respawnPlayer();
    }
}
