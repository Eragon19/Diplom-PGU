using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupRAM : MonoBehaviour
{
    public GameObject secondRAM; // Вторая оперативная память, которая появится после поднятия
    public TMP_Text interactText; // Текст взаимодействия
    public TMP_Text taskText; // Текст задания

    private bool isPlayerNearby = false; // Проверка, рядом ли игрок

    void Start()
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false); // Скрываем текст при старте
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.BackQuote))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        gameObject.SetActive(false); // Исчезает первая оперативная память
        if (secondRAM != null)
        {
            secondRAM.SetActive(true); // Появляется вторая оперативная память
        }

        if (taskText != null)
        {
            taskText.text = "Найдите видеокарту"; // Обновляем задание
        }

        if (interactText != null)
        {
            interactText.gameObject.SetActive(false); // Скрываем текст
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactText != null)
            {
                interactText.text = "Нажмите Ё, чтобы поднять";
                interactText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactText != null)
            {
                interactText.gameObject.SetActive(false);
            }
        }
    }
}
