using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupCaseCover : MonoBehaviour
{
    public GameObject secondCaseCover; // ������ ������ �������
    public GameObject monitor; // �������, ������� �������� ����� ��������� ������
    public GameObject modelToDisappear; // �������������� ������, ������� ��������
    public GameObject modelToAppear; // �������������� ������, ������� ����������

    public TMP_Text interactText; // ����� ��������������
    public TMP_Text taskText; // ����� �������

    private bool isPlayerNearby = false; // ��������, ����� �� �����

    void Start()
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false); // �������� ����� ��� ������
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        gameObject.SetActive(false); // �������� ������ ������ �������

        if (secondCaseCover != null)
        {
            secondCaseCover.SetActive(true); // ���������� ������ ������ �������
        }

        if (monitor != null)
        {
            monitor.SetActive(true); // ���������� �������
        }

        if (modelToDisappear != null)
        {
            modelToDisappear.SetActive(false); // �������� �������������� ������
        }

        if (modelToAppear != null)
        {
            modelToAppear.SetActive(true); // ���������� ����� ����� ������
        }

        if (taskText != null)
        {
            taskText.text = "������ ���������! ������� �� ������� ����� ��������� ����"; // ��������� �������
        }

        if (interactText != null)
        {
            interactText.gameObject.SetActive(false); // �������� �����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactText != null)
            {
                interactText.text = "������� �, ����� �������";
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
