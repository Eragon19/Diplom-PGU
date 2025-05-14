using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePaper : MonoBehaviour
{

    private bool isPlayerNear = false;
    public FPSController playerController;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (QuestTracker.Instance.currentIndex == 6|| QuestTracker.Instance.currentIndex == 13)
            {
                QuestTracker.Instance.AdvanceQuest();
            }

            GameObject.Find("Canvas Overlays").transform.GetChild(3).gameObject.SetActive(false);

            if (QuestTracker.Instance.currentIndex == 14)
            GameObject.Find("Canvas Overlays").transform.GetChild(4).gameObject.SetActive(false);

            gameObject.SetActive(false);
        }

       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
}
