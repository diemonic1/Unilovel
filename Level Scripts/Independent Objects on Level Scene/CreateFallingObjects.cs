using System.Collections;
using UnityEngine;

public class CreateFallingObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _fallingObjects;
    [SerializeField] private GameObject _portal;
    [SerializeField] private float _delayBeforeSpawn;

    private int _countOfItems;

    private void Start()
    {
        _countOfItems = _fallingObjects.Length;
        StartCoroutine(loop());
    }

    private IEnumerator loop()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-17f, 5f);
        float z = Random.Range(-10f, 10f);

        while (x > -8 && x < 8)
            x = Random.Range(-10f, 10f);

        while (z > -8 && z < 8)
            z = Random.Range(-10f, 10f);

        Vector3 dropPosition = new Vector3(x, y, z);

        Instantiate(_portal, dropPosition, Quaternion.identity);

        yield return new WaitForSeconds(0.4f);

        int selectedItemNumber = Random.Range(0, _countOfItems);

        Instantiate(_fallingObjects[selectedItemNumber], dropPosition, Quaternion.identity);

        yield return new WaitForSeconds(_delayBeforeSpawn);
        StartCoroutine(loop());
    }
}
