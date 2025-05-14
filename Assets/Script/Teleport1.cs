using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider myColleder)
    {
        if (myColleder.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level_2");
        }
    }

}
