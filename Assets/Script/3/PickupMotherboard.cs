using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupMotherboard : MonoBehaviour
{
    public GameObject secondMotherboard; // ������ ����������� �����, ������� �������� ����� ��������
    public GameObject extraModel1; // ������ �������������� ������, ������� ��������
    public GameObject extraModel2; // ������ �������������� ������, ������� ��������

    public GameObject copyExtraModel1; // ����� ������ �������������� ������, ������� ��������
    public GameObject copyExtraModel2; // ����� ������ �������������� ������, ������� ��������

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
        gameObject.SetActive(false); // �������� ������ ����������� �����

        if (copyExtraModel1 != null)
        {
            copyExtraModel1.SetActive(false); // �������� ����� ������ �������������� ������
        }

        if (copyExtraModel2 != null)
        {
            copyExtraModel2.SetActive(false); // �������� ����� ������ �������������� ������
        }

        if (secondMotherboard != null)
        {
            secondMotherboard.SetActive(true); // ���������� ������ ����������� �����
        }

        if (extraModel1 != null)
        {
            extraModel1.SetActive(true); // ���������� ������ �������������� ������
        }

        if (extraModel2 != null)
        {
            extraModel2.SetActive(true); // ���������� ������ �������������� ������
        }

        if (taskText != null)
        {
            taskText.text = "������� ���������"; // ��������� �������
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
