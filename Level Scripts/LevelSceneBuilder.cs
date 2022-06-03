using System.Collections;
using UnityEngine;

public class LevelSceneBuilder : MonoBehaviour
{
    public debug TestLevel;

    public enum debug
    {
        none = 0,
        l1_7floors = 1,
        l2_NoWallsManyObjects = 2,
        l3_heroGOsAndWall = 3,
        l4_gravity = 4,
        l5_aqwarium = 5,
        l6_changeWalls = 6,
        l7_notNot = 7,
        l8_cubeWithWalls = 8,
    }

    public int CurrentLevel { get; private set; }

    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject[] _musicPlaylist;

    [SerializeField] private GameObject _staticObjectsOnLevel5, _level7UI;

    [Header("Links to instances")]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;

    private void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt("lvl");

        if (TestLevel != 0)
            CurrentLevel = (int)TestLevel;
    }

    private void Start() 
    {
        Screen.lockCursor = true;

        _levels[CurrentLevel - 1].SetActive(true);
        _musicPlaylist[CurrentLevel - 1].SetActive(true);

        if (CurrentLevel == 5)
        {
            Physics.gravity = new Vector3(0, -5f, 0);
            _staticObjectsOnLevel5.SetActive(true);
        }

        if (CurrentLevel == 7)
            _level7UI.SetActive(true);

        StartCoroutine(spawnPlayerDelay());
    }

    public void setTestLevel(int numberOfLevel)
    {
        TestLevel = (debug)numberOfLevel;
        CurrentLevel = numberOfLevel;
    }

    private IEnumerator spawnPlayerDelay()
    {
        yield return new WaitForSeconds(2.3f);

        playerSpawnAndRespawn.spawnPlayer();

        yield return new WaitForSeconds(1f);

        if (CurrentLevel == 1)
            pauseMenu.showHelpWindow();
    }
}
