using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public TMP_Text questionText;
    public AnswerButton[] answerButtons;
    public TMP_Text resultText;  // Для вывода результата
    public Button exitButton;    // Кнопка для выхода из теста

    private List<Question> questions;
    private int currentQuestionIndex = 0;
    private int correctAnswersCount = 0; // Счетчик правильных ответов

    void Start()
    {
        LoadQuestions();
        ShowQuestion();
        exitButton.gameObject.SetActive(false); // Изначально кнопка скрыта
    }

    void LoadQuestions()
    {
        questions = new List<Question>
        {
            new Question { questionText = "Как называется самая большая плата в ПК?",
                           answers = new string[] { "Видеокарта", "Материнская плата", "Процессор", "Жесткий диск" },
                           correctAnswerIndex = 1 },

            new Question { questionText = "Какой компонент отвечает за обработку графики?",
                           answers = new string[] { "Оперативная память", "Жесткий диск", "Процессор", "Видеокарта" },
                           correctAnswerIndex = 3 },

            new Question { questionText = "Что измеряется в ГГц?",
                           answers = new string[] { "Скорость процессора", "Объем памяти", "Частота обновления экрана", "Напряжение блока питания" },
                           correctAnswerIndex = 0 },

            new Question { questionText = "Какая деталь используется для хранения данных?",
                           answers = new string[] { "ОЗУ", "SSD", "Видеокарта", "Сетевой адаптер" },
                           correctAnswerIndex = 1 },

            new Question { questionText = "Как называется блок, подающий питание на все компоненты?",
                           answers = new string[] { "Блок питания", "Материнская плата", "Охлаждение", "Разъем USB" },
                           correctAnswerIndex = 0 }
        };
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= questions.Count)
        {
            Debug.Log("⚠️ Все вопросы пройдены!");
            ShowResult(); // Показываем результат после последнего вопроса
            return;
        }

        Question q = questions[currentQuestionIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < q.answers.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].SetAnswer(q.answers[i], (i == q.correctAnswerIndex) ? 1 : 0);
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }

        Debug.Log($"📢 Показан вопрос {currentQuestionIndex + 1}: {q.questionText}");
    }

    public void SelectAnswer(int index)
    {
        if (currentQuestionIndex >= questions.Count)
        {
            Debug.LogError("❌ Ошибка: currentQuestionIndex за пределами списка!");
            return;
        }

        // Проверяем, правильный ли ответ
        if (index == questions[currentQuestionIndex].correctAnswerIndex)
        {
            correctAnswersCount++; // Увеличиваем счетчик правильных ответов
        }

        Debug.Log($"✅ Вопрос {currentQuestionIndex + 1}/{questions.Count} | Выбран ответ {index}");

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            Debug.Log("✅ Викторина завершена!");
            ShowResult(); // Показываем результат по окончании викторины
        }
    }

    void ShowResult()
    {
        // Выводим количество правильных ответов
        resultText.text = $"Вы правильно ответили на {correctAnswersCount} из {questions.Count} вопросов!";
        Debug.Log(resultText.text); // Также выводим в консоль

        // Показываем кнопку выхода
        exitButton.gameObject.SetActive(true);
        exitButton.onClick.AddListener(ExitQuiz); // Добавляем обработчик нажатия
    }

    void ExitQuiz()
    {
        // Здесь можно добавить поведение для выхода, например:
        // Если вы хотите выйти из приложения:
        Application.Quit();

        // Или если хотите вернуться на главный экран:
        // SceneManager.LoadScene("MainMenu");

        Debug.Log("Викторина завершена. Выход...");
    }
}
