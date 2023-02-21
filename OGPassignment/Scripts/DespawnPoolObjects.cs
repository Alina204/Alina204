using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class DespawnPoolObjects : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            StartCoroutine("Despawn");
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3f);
        NetworkObject no = gameObject.GetComponent<NetworkObject>();
        no.Despawn();
    }
}
