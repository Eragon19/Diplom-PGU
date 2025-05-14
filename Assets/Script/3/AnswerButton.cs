using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public TMP_Text answerText; // Поле для текста ответа
    public QuizManager quizManager;
    public int answerIndex;

    public void SetAnswer(string text, int index)
    {
        if (answerText == null) // Проверяем, не пустой ли объект
        {
            Debug.LogError("❌ Ошибка: answerText не задан в " + gameObject.name);
            return;
        }

        answerText.text = text;  // Устанавливаем текст на кнопке
        answerIndex = index;
    }

    public void SelectAnswer()
    {
        if (quizManager == null) // Проверяем, есть ли ссылка на QuizManager
        {
            Debug.LogError("❌ Ошибка: quizManager не задан в " + gameObject.name);
            return;
        }

        quizManager.SelectAnswer(answerIndex);
    }
}
