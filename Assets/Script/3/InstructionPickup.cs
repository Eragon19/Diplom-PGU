using TMPro;
using UnityEngine;

public class InstructionPickup : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public TMP_Text interactText; // ����� ���������
    public TMP_Text taskText; // ����� �������

    void Start()
    {
        interactText.gameObject.SetActive(false); // �������� ����� ��� ������
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            PickupInstruction();
        }
    }

    private void PickupInstruction()
    {
        gameObject.SetActive(false); // ������� ����������
        interactText.gameObject.SetActive(false); // �������� �����

        if (taskText != null)
        {
            taskText.text = "������� ������"; // ��������� �������
        }
        else
        {
            Debug.LogWarning("UI-����� ������� �� ��������!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactText.text = "������� �, ����� �������";
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactText.gameObject.SetActive(false);
        }
    }
}
