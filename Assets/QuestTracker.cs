using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour
{
    public static QuestTracker Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private Toggle questToggle;
    [SerializeField] private CanvasGroup uiGroup;
    [SerializeField] private TextMeshProUGUI questText;

    [Header("Quest Settings")]
    [SerializeField] private float fadeDuration = 0.5f;
    public int currentIndex = 0;

    // Define your quest descriptions here
    public readonly List<string> questDescriptions = new List<string>
    {
        "Подойдите и запустите терминал", //0
        "Войдите в аккаунт",//1
        "Создайте справку об обучении открыв вкладку ЦОС",//2
        "Закройте терминал нажав ESC и пройдите в кабинет ЦОС",//3
        "Пройдите в ЦОС для получения справки",//4
        "Передайте свою информацию в ЦОС для получения справки",//5

        "Заберите справку со стола",//6
        "Вернитесь к терминалу и создайте справку для военкомата",//7


        "Войдите в аккаунт",//8
        "Создайте справку для военкомата",//9
        "Закройте терминал нажав ESC и пройдите в кабинет А1/1",//10

        "Пройдите в кабинет А1/1 для получения справки",//11
        "Передайте свою информацию для получения справки",//12
        "Заберите справку со стола",//13


        "Исследуйте коворкинг",//14
        "Все задания выполнены!" //15
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateQuestUI();
    }

    /// <summary>
    /// Advances to the next quest and triggers the notification animation.
    /// </summary>
    public void AdvanceQuest()
    {
        if (currentIndex >= questDescriptions.Count - 1)
        {
            Debug.Log("All quests completed!");
            return;
        }

        currentIndex++;
        StartCoroutine(PlayQuestAnimation());
    }

    private IEnumerator PlayQuestAnimation()
    {
        if (questToggle != null)
            questToggle.isOn = true;

        questText.text = "Задание выполнено!!";
        yield return FadeUI(1f, 0f);

        if (questToggle != null)
            questToggle.isOn = false;

        UpdateQuestUI();
        yield return FadeUI(0f, 1f);
    }

    private IEnumerator FadeUI(float fromAlpha, float toAlpha)
    {
        if (uiGroup == null)
            yield break;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            uiGroup.alpha = Mathf.Lerp(fromAlpha, toAlpha, elapsed / fadeDuration);
            yield return null;
        }
        uiGroup.alpha = toAlpha;
    }

    private void UpdateQuestUI()
    {
        if (questText == null) return;

        questText.text = questDescriptions[currentIndex];
    }

}
