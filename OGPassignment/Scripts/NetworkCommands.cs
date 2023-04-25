using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkCommands : MonoBehaviour
{
    public Button startButton;
    public Button startHostButton;
    public Button startClientButton;
    public Button disconnectButton;

    private int winScore = 3;

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
    public void WinCheck(int p1Score, int p2Score, int p3Score, int p4Score, TMP_Text scoreText)
    {
        if (p1Score >= winScore)
        {
            scoreText.text = "Player 1 won:";
            Invoke(nameof(ReloadScene), 5f);
        }
        else if (p2Score >= winScore)
        {
            scoreText.text = "Player 2 won:";
            Invoke(nameof(ReloadScene), 5f);
        }
        else if (p3Score >= winScore)
        {
            scoreText.text = "Player 3 won:";
            Invoke(nameof(ReloadScene), 5f);
        }
        else if (p4Score >= winScore)
        {
            scoreText.text = "Player 4 won:";
            Invoke(nameof(ReloadScene), 5f);
        }
        else
            return;
    }
    private void ReloadScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        NetworkManager.Singleton.Shutdown();
        Destroy(this.gameObject);
    }
}


