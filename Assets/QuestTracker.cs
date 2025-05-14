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
        "��������� � ��������� ��������", //0
        "������� � �������",//1
        "�������� ������� �� �������� ������ ������� ���",//2
        "�������� �������� ����� ESC � �������� � ������� ���",//3
        "�������� � ��� ��� ��������� �������",//4
        "��������� ���� ���������� � ��� ��� ��������� �������",//5

        "�������� ������� �� �����",//6
        "��������� � ��������� � �������� ������� ��� ����������",//7


        "������� � �������",//8
        "�������� ������� ��� ����������",//9
        "�������� �������� ����� ESC � �������� � ������� �1/1",//10

        "�������� � ������� �1/1 ��� ��������� �������",//11
        "��������� ���� ���������� ��� ��������� �������",//12
        "�������� ������� �� �����",//13


        "���������� ���������",//14
        "��� ������� ���������!" //15
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

        questText.text = "������� ���������!!";
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
