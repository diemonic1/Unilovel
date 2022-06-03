using UnityEngine;

public class PlayerSpawnAndRespawn : MonoBehaviour
{
    public int PortalCounter;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _portalSpawnAnimator, _portalDespawnAnimator;
    [SerializeField] private GameObject _portalSpawn, _portalDespawn;

    [SerializeField] private Transform[] _playerSpawnPoints;
    [SerializeField] private Transform[] _playerSpawnPointsOnLevel3;
    [SerializeField] private Transform[] _playerSpawnPointsOnLevel6;

    private bool _isDeath = false;
    private string _workTarget = "";

    [Header("Links to instances")]
    [SerializeField] private LevelSceneBuilder levelSceneBuilder;
    [SerializeField] private TransitionToNextScene transitionToNextScene;
    [SerializeField] private KillingObjectHereChecker[] killingObjectHereCheckers;

    public void respawnPlayer() 
    {
        _workTarget = "respawn";
        playDespawnAnimation();
    }

    public void finishLevel()
    {
        _workTarget = "TransitionOnNextScene";
        playDespawnAnimation();
    }

    private void playDespawnAnimation() 
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

    public void endOfDespawnAnimation() 
    {
        switch (_workTarget)
        {
            case "respawn":
                spawnPlayer();
                break;
            case "TransitionOnNextScene":
                transitionToNextScene.turnOnDialogue();
                break;
        }
    }

    public void spawnPlayer()
    {
        _playerTransform.localScale = new Vector3(0, 0, 0);

        _playerTransform.position = getSpawnPoint();

        _portalSpawn.transform.position = _playerTransform.position;

        _portalSpawnAnimator.Play("openPortal");
        _playerAnimator.Play("increaseHero");

        _playerRigidbody.isKinematic = false;
        _isDeath = false;
    }

    private Vector3 getSpawnPoint() 
    {
        if (levelSceneBuilder.CurrentLevel == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                if (killingObjectHereCheckers[i].IsKillingObjectHere == false)
                {
                    return _playerSpawnPointsOnLevel3[i].position;
                    break;
                }

                return _playerSpawnPointsOnLevel3[0].position;
            }
        }
        else if (levelSceneBuilder.CurrentLevel == 6)
            return _playerSpawnPointsOnLevel6[PortalCounter].position;

        return _playerSpawnPoints[levelSceneBuilder.CurrentLevel - 1].position;
    }
}
