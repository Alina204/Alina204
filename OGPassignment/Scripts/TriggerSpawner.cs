using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public GameObject prefab;
    private bool hasEnteredOnce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasEnteredOnce)
            {
                hasEnteredOnce = true;
                Instantiate(prefab, Vector3.up, Quaternion.identity);
            }
            else if (hasEnteredOnce)
            {
                hasEnteredOnce = false;
                GameObject objectToDelete = GameObject.FindGameObjectWithTag("Ball");
                Destroy(objectToDelete);
            }

        }

    }
}
