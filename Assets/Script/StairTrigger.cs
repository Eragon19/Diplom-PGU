using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTrigger : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EnterStairZone();
        }
    }
}
