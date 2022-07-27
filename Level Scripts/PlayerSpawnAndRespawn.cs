using UnityEngine;

public class PlayerSpawnAndRespawn : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _portalSpawnAnimator, _portalDespawnAnimator;
    [SerializeField] private GameObject _portalSpawn, _portalDespawn;

    [SerializeField] private Transform[] _playerSpawnPoints;
    [SerializeField] private Transform[] _playerSpawnPointsOnLevel3;
    [SerializeField] private Transform[] _playerSpawnPointsOnLevel6;

    private bool _isDeath = false;
    private string _workTarget = string.Empty;

    [Header("Links to instances")]
    [SerializeField] private LevelSceneBuilder levelSceneBuilder;
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private KillingObjectHereChecker[] killingObjectHereCheckers;

    public void UpdatePlayerSpawnPoint(int numberOfNewSpawnPoint)
    {
        if (levelSceneBuilder.CurrentLevel == 6)
            _playerSpawnPoints[levelSceneBuilder.CurrentLevel - 1] = _playerSpawnPointsOnLevel6[numberOfNewSpawnPoint];
    }

    public void RespawnPlayer()
    {
        _workTarget = "respawn";
        PlayDespawnAnimation();
    }

    public void FinishLevel()
    {
        _workTarget = "TransitionOnNextScene";
        PlayDespawnAnimation();
    }

    public void EndOfDespawnAnimation()
    {
        switch (_workTarget)
        {
            case "respawn":
                SpawnPlayer();
                break;
            case "TransitionOnNextScene":
                transitionToNextScene.TurnOnDialogue();
                break;
        }
    }

    public void SpawnPlayer()
    {
        _playerTransform.localScale = new Vector3(0, 0, 0);

        _playerTransform.position = GetSpawnPoint();

        _portalSpawn.transform.position = _playerTransform.position;

        _portalSpawnAnimator.Play("openPortal");
        _playerAnimator.Play("increaseHero");

        _playerRigidbody.isKinematic = false;
        _isDeath = false;
    }

    private void PlayDespawnAnimation()
    {
        if (_isDeath == false)
        {
            _isDeath = true;

            _playerRigidbody.isKinematic = true;
            _portalDespawn.transform.position = _playerTransform.position;

            _playerAnimator.Play("reduceHero");
            _portalDespawnAnimator.Play("portalDespawnAnimation");
        }
    }

    private Vector3 GetSpawnPoint()
    {
        if (levelSceneBuilder.CurrentLevel == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                if (killingObjectHereCheckers[i].IsKillingObjectHere == false)
                    return _playerSpawnPointsOnLevel3[i].position;
            }

            return _playerSpawnPointsOnLevel3[0].position;
        }

        return _playerSpawnPoints[levelSceneBuilder.CurrentLevel - 1].position;
    }
}
