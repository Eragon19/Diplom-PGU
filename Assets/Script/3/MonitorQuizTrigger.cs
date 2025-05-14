using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorQuizTrigger : MonoBehaviour
{
    public GameObject quizCanvas; // ������ � ������
    public GameObject player; // �����
    public TextMeshProUGUI interactText; // ������� "������� �, ����� ��������� ����"
    public GameObject fadePanel; // ������ ����������

    private bool isPlayerNear = false;
    private bool isTestStarted = false;

    void Start()
    {
        quizCanvas.SetActive(false);
        interactText.gameObject.SetActive(false);
        fadePanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && !isTestStarted && Input.GetKeyDown(KeyCode.F)) // "�" �� ������� ���������
        {
            StartCoroutine(StartTest());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactText.gameObject.SetActive(false);
        }
    }

    IEnumerator StartTest()
    {
        isTestStarted = true;
        interactText.gameObject.SetActive(false);
        fadePanel.SetActive(true);
        yield return new WaitForSeconds(1f); // ���� ������ ����������

        fadePanel.SetActive(false);
        quizCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (player.TryGetComponent(out FPSController playerMovement))
        {
            playerMovement.enabled = false; // ��������� �������� ���������
        }
    }
}
