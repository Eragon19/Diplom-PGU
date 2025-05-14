using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentPlacement : MonoBehaviour
{
    public GameObject tableDocument; // Справка, которая появится на столе
    public TextMeshProUGUI placeHint; // Подсказка "Нажмите Ё, чтобы положить"

    private bool isNear = false;

    void Start()
    {
        placeHint.alpha = 0;
        tableDocument.SetActive(false); // Изначально скрываем справку на столе
    }

    void Update()
    {
        if (isNear && PlayerInventory.HasDocument && Input.GetKeyDown(KeyCode.BackQuote))
        {
            PlaceDocument();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerInventory.HasDocument)
        {
            placeHint.alpha = 1; // Показываем подсказку
            isNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeHint.alpha = 0;
            isNear = false;
        }
    }

    void PlaceDocument()
    {
        placeHint.alpha = 0;
        PlayerInventory.HasDocument = false; // Игрок больше не держит справку
        tableDocument.SetActive(true); // Показываем справку на столе
        FindObjectOfType<TaskManager>().SetTask("Задача выполнена!");
    }
}
