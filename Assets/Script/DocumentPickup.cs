using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentPickup : MonoBehaviour
{
    public TextMeshProUGUI pickupHint;
    private bool isNear = false;

    void Start()
    {
        pickupHint.alpha = 0;
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.F))
        {
            if (FindObjectOfType<TaskManager>().CanPickDocument())
            {
                PickUpDocument();
            }
            else
            {
                Debug.Log("������� ������� ��� �����!");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (FindObjectOfType<TaskManager>().CanPickDocument())
            {
                pickupHint.alpha = 1;
                isNear = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupHint.alpha = 0;
            isNear = false;
        }
    }

    void PickUpDocument()
    {
        pickupHint.alpha = 0;
        gameObject.SetActive(false);
        PlayerInventory.HasDocument = true; // ������ ����� ������������� ������ �������
        FindObjectOfType<TaskManager>().SetTask("�������� ������� �� ����!");
    }
}
