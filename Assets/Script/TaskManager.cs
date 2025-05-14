using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI taskText;
    private int booksCollected = 0;
    private int totalBooks = 3; // Общее количество книг
    private bool canPickDocument = false;
    private bool allTasksCompleted = false; // Флаг, что задания выполнены

    void Start()
    {
        UpdateTaskText();
    }

    public void CollectBook()
    {
        booksCollected++;
        UpdateTaskText(); // Обновляем задачу

        if (booksCollected >= totalBooks)
        {
            canPickDocument = true; // Теперь можно брать справку
        }
    }

    public bool CanPickDocument()
    {
        return canPickDocument;
    }

    public void PickDocument()
    {
        SetTask("Отнесите справку на стол!");
    }

    public void PlaceDocument()
    {
        if (!allTasksCompleted)
        {
            allTasksCompleted = true;
            SetTask("Задача выполнена!");
            StartCoroutine(ShowNextTaskAfterDelay());
        }
    }

    private void UpdateTaskText()
    {
        if (booksCollected < totalBooks)
        {
            SetTask("Найдите ещё " + (totalBooks - booksCollected) + " книги");
        }
        else if (!canPickDocument)
        {
            SetTask("Найдите справку");
        }
    }

    public void SetTask(string newTask)
    {
        taskText.text = "Задача: " + newTask;
    }

    private IEnumerator ShowNextTaskAfterDelay()
    {
        yield return new WaitForSeconds(2); // Ждём 2 секунды
        SetTask("Пройдите в конец зала, чтобы пройти дальше");
    }
    public bool AllTasksCompleted()
    {
        return allTasksCompleted;
    }

}
