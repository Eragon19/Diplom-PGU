using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskInitializer : MonoBehaviour
{
    public TMP_Text taskText; // UI-элемент для задания

    void Start()
    {
        if (taskText != null)
        {
            taskText.text = "Найдите инструкцию"; // Устанавливаем первое задание
        }
        else
        {
            Debug.LogWarning("UI-текст задания не назначен!");
        }
    }
}
