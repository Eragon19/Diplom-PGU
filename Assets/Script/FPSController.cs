using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpSpeed;
    public float gravity;

    public CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;

    private void Start()
    {
        //GameEvents.OnPlayerMove += OnPlayerMove;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //if (GameEvents.isPaused)
        //{
        //    return;
        //}

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Remove vertical influence from movement but keep original direction
        forward.y = 0;
        right.y = 0;

        // If forward becomes zero (looking straight up/down), retain last direction
        if (forward.sqrMagnitude < 0.001f)
        {
            forward = transform.forward; // Use player's last valid forward direction
        }
        forward.Normalize();
        right.Normalize();

        //Debug.Log($"Forward: {forward}; Right: {right}");
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        // Debug.Log($"curSpeedX: {curSpeedX}; curSpeedY: {curSpeedY}; movementDirectionY: {movementDirectionY}");
        // Maintain movement magnitude
        Vector3 moveDirectionXZ = (forward * curSpeedX) + (right * curSpeedY);
        if (moveDirectionXZ.sqrMagnitude > 1)
        {
            moveDirectionXZ.Normalize(); // Prevent diagonal movement from being too fast
            moveDirectionXZ *= (isRunning ? runningSpeed : walkingSpeed);
        }

        // Preserve existing vertical movement (gravity, jumping)
        float movementDirectionY = moveDirection.y;
        moveDirection = moveDirectionXZ;
        moveDirection.y = movementDirectionY;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void OnDisable()
    {
        //GameEvents.OnPlayerMove -= OnPlayerMove;
    }
}