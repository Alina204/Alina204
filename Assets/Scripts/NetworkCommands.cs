using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class NetworkCommands : MonoBehaviour
{
    public Button startButton;
    public Button startHostButton;
    public Button startClientButton;
    public Button disconnectButton;

#if UNITY_SERVER && !UNITY_EDITOR
    private void Start()
    {
        NetworkManager.Singleton.StartServer();
    }
#else
    private void Start()
    {
        disconnectButton.gameObject.SetActive(false);
    }
    public void ConnectToServer()
    {
        NetworkManager.Singleton.StartServer();
        disconnectButton.gameObject.SetActive(true);
        startHostButton.gameObject.SetActive(false);
        startClientButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

    }

    public void StartServerAsHost()
    {
        NetworkManager.Singleton.StartHost();
        disconnectButton.gameObject.SetActive(true);
        startHostButton.gameObject.SetActive(false);
        startClientButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void JoinServer()
    {
        NetworkManager.Singleton.StartClient();
        disconnectButton.gameObject.SetActive(true);
        startHostButton.gameObject.SetActive(false);
        startClientButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void DisconnectFromServer()
    {
        NetworkManager.Singleton.Shutdown();
        disconnectButton.gameObject.SetActive(false);
        startHostButton.gameObject.SetActive(true);
        startClientButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
    }
#endif
}

