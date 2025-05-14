using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickupCase : MonoBehaviour
{
    public GameObject secondCase; // ������ ������, ������� �������� ����� ��������
    public GameObject additionalModel; // �������������� ������, ������� ���� ��������

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
        gameObject.SetActive(false); // �������� ������ ������

        if (secondCase != null)
        {
            secondCase.SetActive(true); // ���������� ������ ������
        }

        if (additionalModel != null)
        {
            additionalModel.SetActive(true); // ���������� �������������� ������
        }

        if (taskText != null)
        {
            taskText.text = "������� ����������� �����"; // ��������� �������
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
