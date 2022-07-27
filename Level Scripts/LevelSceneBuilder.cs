using System.Collections;
using UnityEngine;

public class LevelSceneBuilder : MonoBehaviour
{
    [SerializeField] private Debug _testLevel;

    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject[] _musicPlaylist;

    [SerializeField] private GameObject _staticObjectsOnLevel5, _level7UI;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    private enum Debug
    {
        None = 0,
        L1_7floors = 1,
        L2_NoWallsManyObjects = 2,
        L3_heroGOsAndWall = 3,
        L4_gravity = 4,
        L5_aqwarium = 5,
        L6_changeWalls = 6,
        L7_notNot = 7,
        L8_cubeWithWalls = 8,
    }

    public int CurrentLevel { get; private set; }

    public void SetTestLevel(int numberOfLevel)
    {
        _testLevel = (Debug)numberOfLevel;
        CurrentLevel = numberOfLevel;
    }

    private void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt("lvl");

        if (_testLevel != 0)
            CurrentLevel = (int)_testLevel;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _levels[CurrentLevel - 1].SetActive(true);
        _musicPlaylist[CurrentLevel - 1].SetActive(true);

        if (CurrentLevel == 5)
        {
            Physics.gravity = new Vector3(0, -5f, 0);
            _staticObjectsOnLevel5.SetActive(true);
        }

        if (CurrentLevel == 7)
            _level7UI.SetActive(true);

        StartCoroutine(SpawnPlayerDelay());
    }

    private IEnumerator SpawnPlayerDelay()
    {
        yield return new WaitForSeconds(2.3f);

        playerSpawnAndRespawn.SpawnPlayer();

        yield return new WaitForSeconds(1f);

        if (CurrentLevel == 1)
            pauseMenu.ShowHelpWindow();
    }
}
