using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport2 : MonoBehaviour
{
    private TaskManager taskManager;

    void Start()
    {
        taskManager = FindObjectOfType<TaskManager>(); // ���� TaskManager �� �����
    }

    private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.CompareTag("Player") && taskManager != null && taskManager.AllTasksCompleted())
        {
            SceneManager.LoadScene("Level_3");
        }
    }
}
