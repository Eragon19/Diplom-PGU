using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public TMP_Text resultText;
    public Button checkButton;
    public GameObject testUI;
    public GameObject player;

    private int score = 0;
    private bool[] correctAnswers = new bool[5];

    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswers);
    }

    public void SelectAnswer(int questionIndex, bool isCorrect)
    {
        correctAnswers[questionIndex] = isCorrect;
    }

    void CheckAnswers()
    {
        score = 0;
        foreach (bool answer in correctAnswers)
        {
            if (answer) score++;
        }
        resultText.text = "�� �������� ��������� �� " + score + " �� 5 ��������.";

        // **����� 3 ������� ���� ���������**
        Invoke("CloseTest", 3f);
    }

    void CloseTest()
    {
        testUI.SetActive(false);

        // **�������� ���������� ����������**
        if (player.TryGetComponent(out CharacterController controller))
        {
            controller.enabled = true;
        }
        if (player.TryGetComponent(out FPSController movement))
        {
            movement.enabled = true;
        }

        // **������ ������**
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
