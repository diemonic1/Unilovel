using System.Collections;
using UnityEngine;

namespace MiniGameOnLvl7
{
    public class MiniGameOnLvl7Logic : MonoBehaviour
    {
        public bool IsWin { get; private set; }
        public bool IsGameRunning { get; private set; }
        public int CountBeforeWin { get; private set; } = 15;
        public float TimeBeforeDeath { get; private set; } = 1;

        [SerializeField] private GameObject _triggersGroup;

        private bool _nextTriggerStartGame, _firstActivateAfterDeath = true;

        [Header("Links to instances")]
        [SerializeField] private PlayerSpawnAndRespawn playerSpawnAndRespawn;
        [SerializeField] private TaskCreator taskCreator;
        [SerializeField] private VisualLvl7 visualLvl7;

        public void triggerActivate(int numberActivated)
        {
            if (!IsWin)
            {
                checkNumberOfActivated(numberActivated);
            }
        }

        private void checkNumberOfActivated(int numberActivated)
        {
            if (!_nextTriggerStartGame) // after death does not react to the first interaction with the trigger, which occurs after the character falls on respawn
                _nextTriggerStartGame = true;
            else if (((!taskCreator.NotMode && numberActivated == taskCreator.CurrentTarget) || (taskCreator.NotMode && numberActivated != taskCreator.CurrentTarget) || taskCreator.AnyColorMode) && !_firstActivateAfterDeath)
            {
                taskSolved();
                if (!thisLastTask()) taskCreator.createNewTask(numberActivated);
            }
            else if (_firstActivateAfterDeath)
            {
                _firstActivateAfterDeath = false;
                IsGameRunning = true;
                startDeathTimer();
                taskCreator.createNewTask(numberActivated);
            }
            else
                taskFailed();
        }

        private void startDeathTimer() 
        {
            StartCoroutine(timerOfDeath());
        }

        private bool thisLastTask() 
        {
            if (CountBeforeWin <= 0)
            {
                win();
                return true;
            }
            else return false;
        }

        private void taskSolved()
        {
            CountBeforeWin -= 1;
            TimeBeforeDeath = 1;
        }

        private void taskFailed()
        {
            _triggersGroup.SetActive(false);

            IsGameRunning = false;
            _nextTriggerStartGame = false;
            _firstActivateAfterDeath = true;

            visualLvl7.writeOnAnyColor();

            CountBeforeWin = 15;
            TimeBeforeDeath = 1;

            playerSpawnAndRespawn.respawnPlayer();

            StartCoroutine(triggersSetActiveDelay());
        }

        private IEnumerator triggersSetActiveDelay()
        {
            yield return new WaitForSeconds(1f);

            _triggersGroup.SetActive(true);
        }

        private void win()
        {
            visualLvl7.winVisulisation();

            IsGameRunning = false;
            _nextTriggerStartGame = false;
            IsWin = true;
        }

        private IEnumerator timerOfDeath()
        {
            if (IsGameRunning)
            {
                if (TimeBeforeDeath > 0)
                {
                    TimeBeforeDeath -= 0.0021f;
                    yield return new WaitForSeconds(0.01f);
                    StartCoroutine(timerOfDeath());
                }
                else 
                    taskFailed();
            }
        }
    }
}
