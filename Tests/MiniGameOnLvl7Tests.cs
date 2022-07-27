using MiniGameOnLvl7;
using NUnit.Framework;
using UnityEngine;

public class MiniGameOnLvl7Tests
{
    private readonly int _countOfRepetitions = 100;

    private GameObject _localizationManager;
    private GameObject _scriptsLvl7;

    private MiniGameOnLvl7Logic miniGameOnLvl7Logic;
    private TaskCreator taskCreator;

    [SetUp]
    public void Setup()
    {
        _localizationManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LocalizationManager"));
        _scriptsLvl7 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ScriptsLvl7"));

        miniGameOnLvl7Logic = _scriptsLvl7.GetComponent<MiniGameOnLvl7Logic>();
        taskCreator = _scriptsLvl7.GetComponent<TaskCreator>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(_localizationManager);
        Object.Destroy(_scriptsLvl7);
        Object.Destroy(miniGameOnLvl7Logic);
        Object.Destroy(taskCreator);
    }

    [Test]
    public void CompareNewTargetWithNotExistTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.CreateNewTask(i);

                if (taskCreator.CurrentTarget == -1 && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void CompareNewTargetWithCurrentTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.CreateNewTask(i);

                if (taskCreator.CurrentTarget == i && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void CompareNewTargetWithImpossibleTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.CreateNewTask(i);

                if (taskCreator.CurrentTarget == 5 - i && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void SolvingTaskAndWin()
    {
        for (int i = 0; i < _countOfRepetitions; i++)
        {
            miniGameOnLvl7Logic.TriggerActivate(0);
            miniGameOnLvl7Logic.TriggerActivate(0);
            for (int j = 0; j < 16; j++)
            {
                int currentTarget;

                if (taskCreator.NotMode)
                    currentTarget = taskCreator.CurrentTarget + 1;
                else if (taskCreator.AnyColorMode)
                    currentTarget = 0;
                else
                    currentTarget = taskCreator.CurrentTarget;

                miniGameOnLvl7Logic.TriggerActivate(currentTarget);
            }

            Assert.True(miniGameOnLvl7Logic.IsWin);

            DestroyObjects();
        }
    }

    [Test]
    public void FailingTask()
    {
        for (int i = 0; i < _countOfRepetitions; i++)
        {
            miniGameOnLvl7Logic.TriggerActivate(0);
            miniGameOnLvl7Logic.TriggerActivate(0);

            Assert.True(miniGameOnLvl7Logic.IsGameRunning);

            int oldTarget = taskCreator.CurrentTarget;

            int wrongTarget = 0;
            bool wasAnyColorMode = false;

            if (taskCreator.NotMode)
                wrongTarget = oldTarget;
            else if (taskCreator.AnyColorMode)
                wasAnyColorMode = true;
            else
                wrongTarget = oldTarget + 1;

            miniGameOnLvl7Logic.TriggerActivate(wrongTarget);

            bool isTestFailed = false;

            if (miniGameOnLvl7Logic.IsGameRunning && !wasAnyColorMode)
                isTestFailed = true;

            Assert.False(isTestFailed);

            DestroyObjects();
        }
    }

    private void DestroyObjects()
    {
        Object.Destroy(_localizationManager);
        Object.Destroy(_scriptsLvl7);
        Object.Destroy(miniGameOnLvl7Logic);
        Object.Destroy(taskCreator);

        _localizationManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LocalizationManager"));
        _scriptsLvl7 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ScriptsLvl7"));

        miniGameOnLvl7Logic = _scriptsLvl7.GetComponent<MiniGameOnLvl7Logic>();
        taskCreator = _scriptsLvl7.GetComponent<TaskCreator>();
    }
}