using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CornetTrigger : MonoBehaviour
{
    public GameObject collectablePrefab;
    GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if (go != null && go.transform.parent.CompareTag("Player"))
            {
                go.GetComponent<NetworkObject>().Despawn(destroy: true);

            }

            go = Instantiate(collectablePrefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
            go.GetComponent<NetworkObject>().Spawn();
        }

    }

}
