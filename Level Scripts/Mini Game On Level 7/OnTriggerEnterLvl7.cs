using UnityEngine;

namespace MiniGameOnLvl7
{
    public class OnTriggerEnterLvl7 : MonoBehaviour
    {
        [SerializeField] private int _number;

        [Header("Links to instances")]
        [SerializeField] private MiniGameOnLvl7Logic miniGameOnLvl7Logic;

        private void OnTriggerEnter(Collider touchedObject)
        {
            if (touchedObject.gameObject.CompareTag("Player"))
                miniGameOnLvl7Logic.TriggerActivate(_number);
        }
    }
}
