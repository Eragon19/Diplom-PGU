using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupCoolingSystem : MonoBehaviour
{
    public GameObject secondCoolingSystem; // ������ ������� ����������, ������� �������� ����� ��������
    public GameObject cooler1; // ������ �������������� �����
    public GameObject cooler2; // ������ �������������� �����
    public GameObject newCooler1; // ����� ������� ������
    public GameObject newCooler2; // ����� ������� ������

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
        // ��������� ������ �������
        gameObject.SetActive(false);
        if (cooler1 != null) cooler1.SetActive(false);
        if (cooler2 != null) cooler2.SetActive(false);

        // �������� ����� ����� �������
        if (secondCoolingSystem != null) secondCoolingSystem.SetActive(true);
        if (newCooler1 != null) newCooler1.SetActive(true);
        if (newCooler2 != null) newCooler2.SetActive(true);

        // ��������� �������
        if (taskText != null)
        {
            taskText.text = "������� ����������� ������";
        }

        // �������� ����� ��������������
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
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
