using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    private int booksCollected = 0;
    private int totalBooks = 3; // ����� ���������� ����
    private bool canPickDocument = false;
    private bool allTasksCompleted = false; // ����, ��� ������� ���������

    void Start()
    {
        UpdateTaskText();
    }

    public void CollectBook()
    {
        booksCollected++;
        UpdateTaskText(); // ��������� ������

        if (booksCollected >= totalBooks)
        {
            canPickDocument = true; // ������ ����� ����� �������
        }
    }

    public bool CanPickDocument()
    {
        return canPickDocument;
    }

    public void PickDocument()
    {
        SetTask("�������� ������� �� ����!");
    }

    public void PlaceDocument()
    {
        if (!allTasksCompleted)
        {
            allTasksCompleted = true;
            SetTask("������ ���������!");
            StartCoroutine(ShowNextTaskAfterDelay());
        }
    }

    private void UpdateTaskText()
    {
        if (booksCollected < totalBooks)
        {
            SetTask("������� ��� " + (totalBooks - booksCollected) + " �����");
        }
        else if (!canPickDocument)
        {
            SetTask("������� �������");
        }
    }

    public void SetTask(string newTask)
    {
        taskText.text = "������: " + newTask;
    }

    private IEnumerator ShowNextTaskAfterDelay()
    {
        yield return new WaitForSeconds(2); // ��� 2 �������
        SetTask("�������� � ����� ����, ����� ������ ������");
    }
    public bool AllTasksCompleted()
    {
        return allTasksCompleted;
    }

}
