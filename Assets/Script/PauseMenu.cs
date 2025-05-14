using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform terminals;
    public Transform firstTerminalInteraction;
    public GameObject pauseMenuObj;
    public GameObject authorsMenuObj;
    public GameObject levelSelectMenuObj;

    public GameObject player;
    public GameObject[] levelsPos;

    public void Awake()
    {
        PauseGame(); 
        BackToMenu();

        GameEvents.OnPause += OnPause;
        GameEvents.OnLevelSelect += OnLevelSelect;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void SelectLevel(int level)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FPSController>().enabled = false;
        switch (level)
        {
            case 1:
                player.transform.position = levelsPos[0].transform.position;
                break;
            case 2:
                player.transform.position = levelsPos[1].transform.position;
                break;
            case 3:
                if (QuestTracker.Instance.currentIndex == 14)
                {
                    QuestTracker.Instance.AdvanceQuest();
                }
                player.transform.position = levelsPos[2].transform.position;
                break;
            default:
                break;
        }
        CloseLevelSelect();
    }

    public void OnLevelSelect()
    {
        levelSelectMenuObj.SetActive(true);
        Time.timeScale = 0f;
        GameEvents.isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseLevelSelect()
    {
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<FPSController>().enabled = true;
        levelSelectMenuObj.SetActive(false);
        Time.timeScale = 1f;
        GameEvents.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnPause()
    {
        if (terminals.gameObject.activeSelf)
        {
            if (firstTerminalInteraction.TryGetComponent<FirstTerminalInteraction>(out var interactionScript))
            {
                interactionScript.HandleTriggerExit();
                return;
            }
        }

        //Debug.Log("Escape is pressed, OnPause is called");
        if (GameEvents.isPaused)
        {
            //Debug.Log("OnPause is called, Paused");
            ResumeGame();
        }
        else
        {
            //Debug.Log("OnPause is called, Resumed");
            PauseGame();
        }
    }

    public void Authors()
    {
        authorsMenuObj.SetActive(true);
        pauseMenuObj.transform.GetChild(0).gameObject.SetActive(false);

    }
    public void BackToMenu()
    {
        authorsMenuObj.SetActive(false);
        pauseMenuObj.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        //Debug.Log("Game is paused");
        pauseMenuObj.SetActive(true);
        Time.timeScale = 0f;

        GameEvents.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        //Debug.Log("Game is resumed");
        pauseMenuObj.SetActive(false);
        Time.timeScale = 1f;
        GameEvents.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
