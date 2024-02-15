using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPopups : MonoBehaviour
{
    public GameObject popUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("do");
            popUp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }

}