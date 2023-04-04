using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class ButtonRpcScript : NetworkBehaviour
{

    [SerializeField] GameObject playerPrefab;
    public GameObject[] spawnPoints = new GameObject[4];
    private Vector3 currentSpawnpoint;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    [ServerRpc(RequireOwnership = false)]
    public void SpawnClientPlayerServerRpc(ulong clientID, int spawnPosNumber)
    {
        GameObject go;
        currentSpawnpoint = spawnPoints[spawnPosNumber - 1].transform.position;
        go = SpawnPlayerClient(clientID);

        GameObject goNew = new GameObject("" + spawnPosNumber);
        goNew.transform.parent = go.transform;
    }

    private GameObject SpawnPlayerClient(ulong clientID)
    {
        GameObject go = Instantiate(playerPrefab, currentSpawnpoint, Quaternion.identity);
        NetworkObject no = go.GetComponent<NetworkObject>();
        no.SpawnAsPlayerObject(clientID);

        return go;
    }

    

}
