using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject terminalUI;
    public TMP_Text taskText;
    public TMP_InputField codeInputField;
    public TMP_Text feedbackText;
    public TMP_Text missionText; // Текст задания
    private bool isTerminalOpen = false;
    private int currentMission = 1; // Текущая миссия
    private int currentComputer = 0; // Компьютер, у которого стоит игрок
    private bool missionCompleted = false; // Все задания выполнены?

    void Start()
    {
        terminalUI.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        //UpdateMissionText(); // Показываем первое задание
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    QuestTracker.Instance.AdvanceQuest();
        //    //// or using the static helper
        //    //QuestTracker.Advance();

        //}
        // Открываем терминал только если игрок у нужного компьютера
        if (Input.GetKeyDown(KeyCode.BackQuote) && !isTerminalOpen && currentComputer == currentMission)
        {
            OpenTerminal();
        }
    }

    public void OpenTerminal()
    {
        isTerminalOpen = true;
        terminalUI.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //ShowTask();
    }

    public void CloseTerminal()
    {
        isTerminalOpen = false;
        terminalUI.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CheckCode()
    {
        string userCode = codeInputField.text.Trim().ToLower();
        bool correct = false;

        if (currentMission == 1 && userCode.Contains("console.writeline(\"hello, world!\")"))
        {
            correct = true;
        }
        else if (currentMission == 2 && (userCode.Contains("int a = 5;") &&
                                         userCode.Contains("int b = 3;") &&
                                         userCode.Contains("int c = a + b;") &&
                                         userCode.Contains("console.writeline(c);")))
        {
            correct = true;
        }
        else if (currentMission == 3 && (userCode.Contains("for i in range(1,6):") ||
                                         userCode.Contains("for (int i = 1; i <= 5; i++)")))
        {
            correct = true;
        }

        if (correct)
        {
            feedbackText.text = "✅ Верно! Продолжай дальше.";
            Invoke("CompleteMission", 2f); // После 2 секунд переходим к следующему заданию
        }
        else
        {
            feedbackText.text = "❌ Ошибка! Попробуй еще раз.";
        }
    }

    //void ShowTask()
    //{
    //    if (currentMission == 1)
    //    {
    //        taskText.text = "Задание 1: Напишите код, который выводит 'Hello, World!'";
    //    }
    //    else if (currentMission == 2)
    //    {
    //        taskText.text = "Задание 2: Напишите код, который решит данный пример: 5 + 3 = ?";
    //    }
    //    else if (currentMission == 3)
    //    {
    //        taskText.text = "Задание 3: Напишите код цикла, который выводит числа от 1 до 5.";
    //    }

    //    feedbackText.text = "";
    //    codeInputField.text = "";
    //}

    //void CompleteMission()
    //{
    //    CloseTerminal();

    //    if (currentMission < 3)
    //    {
    //        currentMission++;
    //    }
    //    else
    //    {
    //        missionCompleted = true;
    //        missionText.text = "🚪 Пройдите в конец коридора и войдите в дверь на лестницу, чтобы пройти дальше.";
    //        return;
    //    }

    //    UpdateMissionText();
    //}

    //void UpdateMissionText()
    //{
    //    if (currentMission == 1)
    //    {
    //        missionText.text = "Найдите 410 кабинет и выполните задание.";
    //    }
    //    else if (currentMission == 2)
    //    {
    //        missionText.text = "Задание выполнено! Теперь найдите 406 кабинет.";
    //    }
    //    else if (currentMission == 3)
    //    {
    //        missionText.text = "Задание выполнено! Теперь найдите 402 кабинет.";
    //    }
    //}

    // Вызывается, когда игрок входит в зону компьютера
    public void EnterComputerZone(int computerID)
    {
        currentComputer = computerID;
    }

    // Вызывается, когда игрок выходит из зоны компьютера
    public void ExitComputerZone()
    {
        currentComputer = 0;
    }

    // Метод для выхода через дверь (вызывается, когда игрок входит в триггер двери)
    public void EnterStairZone()
    {
        if (missionCompleted)
        {
            missionText.text = "🎉 Вы успешно прошли уровень!";
        }
    }

}
