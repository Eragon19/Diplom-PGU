using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public GameObject hintText; // UI-текст "Нажмите E"
    private bool isPlayerNear = false;

    void Start()
    {
        hintText.SetActive(false); // Скрываем текст при старте
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.BackQuote))
        {
            FindObjectOfType<GameManager>().OpenTerminal(); // Открываем терминал
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что это игрок
        {
            isPlayerNear = true;
            hintText.SetActive(true); // Показываем текст
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            hintText.SetActive(false); // Скрываем текст
        }
    }
}
