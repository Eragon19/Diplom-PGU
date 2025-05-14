using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnPlayerMove;
    public static event Action OnPause;
    public static event Action OnLevelSelect;
    public static event Action OnLookAround;
    public static bool isPaused;

    public void Update()
    {
        if (!isPaused)
        {
            OnLookAround?.Invoke();
            OnPlayerMove?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (QuestTracker.Instance.currentIndex == 3 || QuestTracker.Instance.currentIndex == 10)
            {
                QuestTracker.Instance.AdvanceQuest();
            }
            OnPause?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Tab))
        {
            OnLevelSelect?.Invoke();
        }
    }
}
