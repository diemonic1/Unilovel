using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MiniGameOnLvl7;

public class MiniGameLvl7Tests
{
    private int _countOfRepetitions = 100;

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
    public void compareNewTargetWithNotExistTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.createNewTask(i);

                if (taskCreator.CurrentTarget == -1 && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void compareNewTargetWithCurrentTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.createNewTask(i);

                if (taskCreator.CurrentTarget == i && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void compareNewTargetWithImpossibleTarget()
    {
        bool isTestFailed = false;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < _countOfRepetitions; j++)
            {
                taskCreator.createNewTask(i);

                if (taskCreator.CurrentTarget == 5 - i && !taskCreator.AnyColorMode)
                    isTestFailed = true;

                Assert.False(isTestFailed);
            }
        }
    }

    [Test]
    public void solvingTaskAndWin()
    {
        for (int i = 0; i < _countOfRepetitions; i++)
        {
            miniGameOnLvl7Logic.triggerActivate(0);
            miniGameOnLvl7Logic.triggerActivate(0);

            int currentTarget = 0;

            for (int j = 0; j < 16; j++)
            {
                if (taskCreator.NotMode)
                    currentTarget = taskCreator.CurrentTarget + 1;
                else if (taskCreator.AnyColorMode)
                    currentTarget = 0;
                else
                    currentTarget = taskCreator.CurrentTarget;

                miniGameOnLvl7Logic.triggerActivate(currentTarget);
            }

            Assert.True(miniGameOnLvl7Logic.IsWin);

            destroyObjects();
        }
    }

    [Test]
    public void failingTask()
    {
        for (int i = 0; i < _countOfRepetitions; i++)
        {
            miniGameOnLvl7Logic.triggerActivate(0);
            miniGameOnLvl7Logic.triggerActivate(0);

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

            miniGameOnLvl7Logic.triggerActivate(wrongTarget);

            bool isTestFailed = false;

            if (miniGameOnLvl7Logic.IsGameRunning && !wasAnyColorMode)
                isTestFailed = true;

            Assert.False(isTestFailed);

            destroyObjects();
        }
    }

    private void destroyObjects()
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