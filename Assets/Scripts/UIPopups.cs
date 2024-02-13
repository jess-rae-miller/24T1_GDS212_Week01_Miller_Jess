using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPopups : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIPopup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

}
