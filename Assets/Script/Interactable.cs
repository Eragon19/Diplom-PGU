using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public GameObject hintText; // UI-����� "������� E"
    private bool isPlayerNear = false;

    void Start()
    {
        hintText.SetActive(false); // �������� ����� ��� ������
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.BackQuote))
        {
            FindObjectOfType<GameManager>().OpenTerminal(); // ��������� ��������
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� ��� �����
        {
            isPlayerNear = true;
            hintText.SetActive(true); // ���������� �����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            hintText.SetActive(false); // �������� �����
        }
    }
}
