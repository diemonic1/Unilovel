using UnityEngine;

public class KillingObjectHereChecker : MonoBehaviour
{
    public bool IsKillingObjectHere { get; private set; }

    private void OnTriggerStay(Collider touchedObject)
    {
        if (touchedObject.tag == "KillingObject")
            IsKillingObjectHere = true;
    }

    private void OnTriggerExit(Collider touchedObject)
    {
        if (touchedObject.tag == "KillingObject")
            IsKillingObjectHere = false;
    }
}
