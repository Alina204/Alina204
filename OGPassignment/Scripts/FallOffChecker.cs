using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.Netcode;

public class FallOffChecker : MonoBehaviour
{
    private int fallOffCounter = 0;
    [SerializeField] private TMP_Text counterText;
    

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallOffCounter += 1;
            UpdateText();
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(0, 3, 0);
            other.gameObject.GetComponent<CharacterController>().enabled = true;

        }
    }

    private void UpdateText()
    {
        counterText.text = "Ass dude fall: " + fallOffCounter;
    }
}
