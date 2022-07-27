using UnityEngine;

public class TriggerNumberRespawnPoint : MonoBehaviour
{
    [SerializeField] private int _countWallPortal;

    private void OnTriggerEnter(Collider touchedObject)
    {
        if (touchedObject.CompareTag("Player"))
            touchedObject.GetComponent<PlayerSpawnAndRespawn>().UpdatePlayerSpawnPoint(_countWallPortal);

        Destroy(gameObject);
    }
}