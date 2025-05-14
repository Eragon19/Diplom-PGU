using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseLookAround : MonoBehaviour
{
    public Transform playerBody;

    public float rotationX = 0f;
    public float rotationY = 0f;
    public float mouseSensitivity = 3f;
    // public int lookDistance = 20;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        GameEvents.OnLookAround += LookAround;
    }

    public void LookAround()
    {
        if (playerBody.gameObject.GetComponent<FPSController>().enabled)
        {
            rotationY = Mathf.Clamp(rotationY - Input.GetAxis("Mouse Y") * mouseSensitivity, -90f, 90f);
            rotationX = (rotationX + Input.GetAxis("Mouse X") * mouseSensitivity) % 360;

            // Apply YAW (horizontal rotation) to the player
            playerBody.rotation = Quaternion.Euler(0f, rotationX, 0f);

            // Apply PITCH (vertical rotation) to the camera
            transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        }
        
    }
}
