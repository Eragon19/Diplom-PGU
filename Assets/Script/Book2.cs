using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Book2 : MonoBehaviour
{
    public TextMeshProUGUI pickupHint;
    private bool isNear = false;

    void Start()
    {
        pickupHint.alpha = 0;
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.BackQuote))
        {
            PickUpBook();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupHint.alpha = 1;
            isNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupHint.alpha = 0;
            isNear = false;
        }
    }

    void PickUpBook()
    {
        pickupHint.alpha = 0;
        gameObject.SetActive(false);
        FindObjectOfType<TaskManager>().CollectBook();
    }
}
