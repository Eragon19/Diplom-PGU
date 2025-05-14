using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
public static GameManager2 Instance; // �������� ��� ��������
    public TextMeshProUGUI taskText; // ����� �������

    private int booksCollected = 0;
    private int totalBooks = 3; // ���������� ����

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
            SetTask("������� �������");
        }
    }

    void UpdateTask()
    {
        int remaining = totalBooks - booksCollected;
        SetTask($"������� {remaining} ����(�)");
    }

    public void SetTask(string task)
    {
        taskText.text = task;
    }
}
