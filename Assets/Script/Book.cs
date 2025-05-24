using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Book : MonoBehaviour
{

    public GameObject bookUI;    // UI � ������� �����
    public GameObject paperGameObject;
    public GameObject NPCDialogue;
    public GameObject PlayerDialogue;

    public FPSController playerController;  // ������ �� ������ ���������� �������

    private bool isPlayerNear = false;

    void Start()
    {

        bookUI.SetActive(false);    // �������� ����� �����
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // ������� "�"
        {
            PlayerDialogue.SetActive(true);
            NPCDialogue.SetActive(false);
            OpenBook();
        }

        if (bookUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseBook();
        }
    }

    public void ShowPaperObj()
    {
        paperGameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestTracker.Instance.currentIndex == 2 || QuestTracker.Instance.currentIndex == 11)
            {
                QuestTracker.Instance.AdvanceQuest();
            }
            isPlayerNear = true;
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;

        }
    }

    public void SelectStudyPaper()
    {
        PlayerDialogue.SetActive(false);
        NPCDialogue.SetActive(true);

        if (QuestTracker.Instance.currentIndex == 5 )
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Ваша справка готова, вы можете забрать её на столе.";
            QuestTracker.Instance.AdvanceQuest();
        }else if (QuestTracker.Instance.currentIndex < 5)
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Запросите справку в терминале";
        }
        else if (QuestTracker.Instance.currentIndex > 5)
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "У вас уже есть справка";
        }

        paperGameObject.SetActive(true);
        //GameObject.Find("Canvas Overlays").transform.GetChild(2).gameObject.SetActive(true);
    }

    public void SelectArmyPaper()
    {
        PlayerDialogue.SetActive(false);
        NPCDialogue.SetActive(true);
        NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Справку для военкомата вы можете получить на 2 втором этаже, в кабинете А1/1";
    

        if (QuestTracker.Instance.currentIndex == 12)
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Ваша справка готова, вы можете забрать её на столе.";
            QuestTracker.Instance.AdvanceQuest();
        }
        else if (QuestTracker.Instance.currentIndex > 5 && QuestTracker.Instance.currentIndex < 10)
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Запросите справку в терминале";
        }
        else if (QuestTracker.Instance.currentIndex > 10)
        {
            NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "У вас уже есть справка";
        }

        paperGameObject.SetActive(true);
    }

    public void SelectExit()
    {
        PlayerDialogue.SetActive(false);
        NPCDialogue.SetActive(true);
        NPCDialogue.GetComponentInChildren<TextMeshProUGUI>().text = "Досвидания!";
    }

    public void ExitDialogue()
    {
        CloseBook();
    }

    void OpenBook()
    {
        if (QuestTracker.Instance.currentIndex == 4)
        {
            QuestTracker.Instance.AdvanceQuest();
        }

        bookUI.SetActive(true);
        Cursor.visible = true;   // ���������� ������
        Cursor.lockState = CursorLockMode.None;  // ������������ ������

        if (playerController != null)
        {
            playerController.enabled = false;  // ��������� ��������

            playerController.gameObject.GetComponent<CharacterController>().enabled = false;
            playerController.gameObject.GetComponentInChildren<MouseLookAround>().enabled = false;
            playerController.gameObject.GetComponent<FPSController>().canMove = false;
        }
    }

    void CloseBook()
    {
        bookUI.SetActive(false);
        Cursor.visible = false;  // �������� ������
        Cursor.lockState = CursorLockMode.Locked;  // ���������� ����������

        if (playerController != null)
        {
            playerController.enabled = true;  // �������� ��������

            playerController.gameObject.GetComponent<CharacterController>().enabled = true;
            playerController.gameObject.GetComponentInChildren<MouseLookAround>().enabled = true;
            playerController.gameObject.GetComponent<FPSController>().canMove = true;

        }
    }
}
