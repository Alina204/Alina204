using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;


    public GameObject[] cornerArray = new GameObject[4];
    private Vector3 currenrCorner;
    private int connectNumber; 



    void Start()
    {
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
       
    }

    private void OnServerStarted()
    {
        connectNumber = 0; 
        if (NetworkManager.Singleton.IsServer)
        {
            if (NetworkManager.Singleton.IsHost)
            {
                currenrCorner = cornerArray[connectNumber].transform.position;

                GameObject go = Instantiate(playerPrefab, currenrCorner, Quaternion.identity);

                NetworkObject no = go.GetComponent<NetworkObject>();

                no.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
                connectNumber += 1;
                if (connectNumber > 3)
                {
                    connectNumber = 0; 
                }
            }
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectedCallback;
        }
    }

    private void OnClientConnectedCallback(ulong clientID)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            currenrCorner = cornerArray[connectNumber].transform.position;

            GameObject go = Instantiate(playerPrefab, currenrCorner, Quaternion.identity);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.SpawnAsPlayerObject(clientID);
            connectNumber += 1;
            if (connectNumber > 3)
            {
                connectNumber = 0;
            }
        }
    }
    private void OnClientDisconnectedCallback(ulong clientId)
    {
        connectNumber -= 1; 
    }
}
