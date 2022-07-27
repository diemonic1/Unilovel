using UnityEngine;

namespace MiniGameOnLvl7
{
    public class TaskCreator : MonoBehaviour
    {
        [Header("Links to instances")]
        [SerializeField] private VisualLvl7 visualLvl7;

        public bool AnyColorMode { get; private set; }

        public bool NotMode { get; private set; }

        public int CurrentTarget { get; private set; } = -1;

        public void CreateNewTask(int numberActivated)
        {
            AnyColorMode = false;
            NotMode = false;

            float probabilityOfAnyColorMode = Random.Range(0f, 1f);

            // probability about 16%
            if (probabilityOfAnyColorMode > 0.84f)
            {
                AnyColorMode = true;
                visualLvl7.WriteOnAnyColor();
            }
            else
            {
                GenerateNumberOfNewTask(numberActivated);
                UpdateVisualisation();
            }
        }

        private void GenerateNumberOfNewTask(int numberActivated)
        {
            float probabilityOfNotMode = Random.Range(0f, 1f);

            if (probabilityOfNotMode > 0.72f) // probability about 28%
                NotMode = true;

            if (numberActivated == 0 || numberActivated == 5)
            {
                CurrentTarget = Random.Range(1, 5);
            }
            else if (numberActivated == 1 || numberActivated == 4)
            {
                int[] poolOfTargets = new int[] { 0, 2, 3, 5 };

                CurrentTarget = poolOfTargets[Random.Range(0, 4)];
            }
            else if (numberActivated == 2 || numberActivated == 3)
            {
                int[] poolOfTargets = new int[] { 0, 1, 4, 5 };

                CurrentTarget = poolOfTargets[Random.Range(0, 4)];
            }
        }

        private void UpdateVisualisation()
        {
            if (NotMode == true)
                visualLvl7.WriteOnTopInscription("lvl_7_upperText_2");
            else
                visualLvl7.WriteOnTopInscription("lvl_7_upperText_3");

            visualLvl7.WriteOnLowerText(CurrentTarget.ToString());

            int probabilityOfMatchingColor = Random.Range(1, 3); // the color of the inscription may not match - probability 50 on 50

            switch (probabilityOfMatchingColor)
            {
                case 1:
                    visualLvl7.ChangeTextColor(CurrentTarget);
                    break;
                case 2:
                    int anotherСolor = Random.Range(0, 6);

                    while (anotherСolor == CurrentTarget)
                        anotherСolor = Random.Range(0, 6);

                    visualLvl7.ChangeTextColor(anotherСolor);
                    break;
            }
        }
    }
}
