using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentPlacement : MonoBehaviour
{
    public GameObject tableDocument; // �������, ������� �������� �� �����
    public TextMeshProUGUI placeHint; // ��������� "������� �, ����� ��������"

    private bool isNear = false;

    void Start()
    {
        placeHint.alpha = 0;
        tableDocument.SetActive(false); // ���������� �������� ������� �� �����
    }

    void Update()
    {
        if (isNear && PlayerInventory.HasDocument && Input.GetKeyDown(KeyCode.BackQuote))
        {
            PlaceDocument();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerInventory.HasDocument)
        {
            placeHint.alpha = 1; // ���������� ���������
            isNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            placeHint.alpha = 0;
            isNear = false;
        }
    }

    void PlaceDocument()
    {
        placeHint.alpha = 0;
        PlayerInventory.HasDocument = false; // ����� ������ �� ������ �������
        tableDocument.SetActive(true); // ���������� ������� �� �����
        FindObjectOfType<TaskManager>().SetTask("������ ���������!");
    }
}
