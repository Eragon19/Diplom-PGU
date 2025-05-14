using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
public static GameManager2 Instance; // Синглтон для удобства
    public TextMeshProUGUI taskText; // Текст задания

    private int booksCollected = 0;
    private int totalBooks = 3; // Количество книг

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateTask();
    }

    public void CollectBook()
    {
        booksCollected++;
        if (booksCollected < totalBooks)
        {
            UpdateTask();
        }
        else
        {
            SetTask("Найдите справку");
        }
    }

    void UpdateTask()
    {
        int remaining = totalBooks - booksCollected;
        SetTask($"Найдите {remaining} книг(и)");
    }

    public void SetTask(string task)
    {
        taskText.text = task;
    }
}
