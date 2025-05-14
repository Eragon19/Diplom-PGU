using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskInitializer : MonoBehaviour
{
    public TMP_Text taskText; // UI-������� ��� �������

    void Start()
    {
        if (taskText != null)
        {
            taskText.text = "������� ����������"; // ������������� ������ �������
        }
        else
        {
            Debug.LogWarning("UI-����� ������� �� ��������!");
        }
    }
}
