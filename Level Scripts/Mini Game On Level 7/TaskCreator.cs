using UnityEngine;

namespace MiniGameOnLvl7
{
    public class TaskCreator : MonoBehaviour
    {
        public bool AnyColorMode { get; private set; }
        public bool NotMode { get; private set; }

        public int CurrentTarget { get; private set; } = -1;

        [Header("Links to instances")]
        [SerializeField] private VisualLvl7 visualLvl7;

        public void createNewTask(int numberActivated)
        {
            AnyColorMode = false;
            NotMode = false;
            
            float probabilityOfAnyColorMode = Random.Range(0f, 1f);

            if (probabilityOfAnyColorMode > 0.84f) // probability about 16%
            {
                AnyColorMode = true;
                visualLvl7.writeOnAnyColor();
            }
            else
            {
                generateNumberOfNewTask(numberActivated);
                updateVisualisation();
            }
        }

        private void generateNumberOfNewTask(int numberActivated) 
        {
            float probabilityOfNotMode = Random.Range(0f, 1f);

            if (probabilityOfNotMode > 0.72f) // probability about 28%
                NotMode = true; 

            if (numberActivated == 0 || numberActivated == 5)
                CurrentTarget = Random.Range(1, 5);
            else if (numberActivated == 1 || numberActivated == 4)
            {
                int[] poolOfTargets = new int[] { 0, 2, 3, 5};

                CurrentTarget = poolOfTargets[Random.Range(0, 4)];
            }
            else if (numberActivated == 2 || numberActivated == 3)
            {
                int[] poolOfTargets = new int[] { 0, 1, 4, 5 };

                CurrentTarget = poolOfTargets[Random.Range(0, 4)];
            }
        }

        private void updateVisualisation()
        {
            if (NotMode == true) 
                visualLvl7.writeOnTopInscription("lvl_7_upperText_2");
            else
                visualLvl7.writeOnTopInscription("lvl_7_upperText_3");

            visualLvl7.writeOnLowerText((CurrentTarget).ToString());

            int probabilityOfMatchingColor = Random.Range(1, 3); // the color of the inscription may not match - probability 50 on 50

            switch (probabilityOfMatchingColor)
            {
                case 1:
                    visualLvl7.changeTextColor(CurrentTarget);
                    break;
                case 2:
                    int anotherСolor = Random.Range(0, 6);

                    while (anotherСolor == CurrentTarget) 
                        anotherСolor = Random.Range(0, 6);

                    visualLvl7.changeTextColor(anotherСolor);
                    break;
            }
        }
    }
}
