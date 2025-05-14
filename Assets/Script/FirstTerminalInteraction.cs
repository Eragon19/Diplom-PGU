using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FirstTerminalInteraction : MonoBehaviour
{

    public Transform terminals;
    public Transform firstTerminal;
    public Transform informationPanels;
    public Transform personalAccountInformation;

    void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey(KeyCode.E))
        {
            GameEvents.isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // buttonsPanel.gameObject.SetActive(true);
            terminals.gameObject.SetActive(true);
            personalAccountInformation.gameObject.SetActive(true);
            firstTerminal.gameObject.SetActive(true);

            Time.timeScale = 0f;

            terminals.gameObject.GetComponent<FirstTerminal>().PersonalAccountButton();

            if (QuestTracker.Instance.currentIndex == 0 || QuestTracker.Instance.currentIndex == 7)
            {
                QuestTracker.Instance.AdvanceQuest();
            }

          
        }
      
    }

    void OnTriggerExit(Collider collider)
    {
        HandleTriggerExit();
    }

    public void HandleTriggerExit()
    {
        Time.timeScale = 1f;
        GameEvents.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // buttonsPanel.gameObject.SetActive(false);
        personalAccountInformation = informationPanels.Find("PersonalAccountInformation");
        terminals.gameObject.SetActive(false);
        personalAccountInformation.gameObject.SetActive(false);
        firstTerminal.gameObject.SetActive(false);

    }
}
