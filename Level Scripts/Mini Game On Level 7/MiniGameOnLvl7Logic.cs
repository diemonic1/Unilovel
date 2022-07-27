using System.Collections;
using UnityEngine;

namespace MiniGameOnLvl7
{
    public class MiniGameOnLvl7Logic : MonoBehaviour
    {
        [SerializeField] private GameObject _triggersGroup;

        private bool _nextTriggerStartGame, _firstActivateAfterDeath = true;

        [Header("Links to instances")]
        [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;
        [SerializeField] private TaskCreator taskCreator;
        [SerializeField] private VisualLvl7 visualLvl7;

        public bool IsWin { get; private set; }

        public bool IsGameRunning { get; private set; }

        public int CountBeforeWin { get; private set; } = 15;

        public float TimeBeforeDeath { get; private set; } = 1;

        public void TriggerActivate(int numberActivated)
        {
            if (!IsWin)
            {
                CheckNumberOfActivated(numberActivated);
            }
        }

        private void CheckNumberOfActivated(int numberActivated)
        {
            // after death does not react to the first interaction with the trigger, which occurs after the character falls on respawn
            if (!_nextTriggerStartGame)
            {
                _nextTriggerStartGame = true;
            }
            else if (((!taskCreator.NotMode && numberActivated == taskCreator.CurrentTarget) || (taskCreator.NotMode && numberActivated != taskCreator.CurrentTarget) || taskCreator.AnyColorMode) && !_firstActivateAfterDeath)
            {
                TaskSolved();
                if (!ThisLastTask()) taskCreator.CreateNewTask(numberActivated);
            }
            else if (_firstActivateAfterDeath)
            {
                _firstActivateAfterDeath = false;
                IsGameRunning = true;
                StartDeathTimer();
                taskCreator.CreateNewTask(numberActivated);
            }
            else
            {
                TaskFailed();
            }
        }

        private void StartDeathTimer()
        {
            StartCoroutine(TimerOfDeath());
        }

        private bool ThisLastTask()
        {
            if (CountBeforeWin <= 0)
            {
                Win();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TaskSolved()
        {
            CountBeforeWin -= 1;
            TimeBeforeDeath = 1;
        }

        private void TaskFailed()
        {
            _triggersGroup.SetActive(false);

            IsGameRunning = false;
            _nextTriggerStartGame = false;
            _firstActivateAfterDeath = true;

            visualLvl7.WriteOnAnyColor();

            CountBeforeWin = 15;
            TimeBeforeDeath = 1;

            playerSpawnAndRespawn.RespawnPlayer();

            StartCoroutine(TriggersSetActiveDelay());
        }

        private IEnumerator TriggersSetActiveDelay()
        {
            yield return new WaitForSeconds(1f);

            _triggersGroup.SetActive(true);
        }

        private void Win()
        {
            visualLvl7.WinVisulisation();

            IsGameRunning = false;
            _nextTriggerStartGame = false;
            IsWin = true;
        }

        private IEnumerator TimerOfDeath()
        {
            if (IsGameRunning)
            {
                if (TimeBeforeDeath > 0)
                {
                    TimeBeforeDeath -= 0.0021f;
                    yield return new WaitForSeconds(0.01f);
                    StartCoroutine(TimerOfDeath());
                }
                else
                {
                    TaskFailed();
                }
            }
        }
    }
}
