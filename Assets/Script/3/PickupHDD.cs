using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupHDD : MonoBehaviour
{
    public GameObject secondHardDrive; // ������ ������ ������� �����, ������� ��������
    public GameObject extraModel; // �������������� ������, ������� ��������
    public GameObject extraModelCopy; // ����� ������ ������, ������� ��������

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
        gameObject.SetActive(false); // �������� ������ ����

        if (extraModel != null)
        {
            extraModel.SetActive(false); // �������� �������������� ������
        }

        if (secondHardDrive != null)
        {
            secondHardDrive.SetActive(true); // ���������� ������ ������ ������� �����
        }

        if (extraModelCopy != null)
        {
            extraModelCopy.SetActive(true); // ���������� ����� ������ ������
        }

        if (taskText != null)
        {
            taskText.text = "������� ������ SATA ��� SSD"; // ��������� �������
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
