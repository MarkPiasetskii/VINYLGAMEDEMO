using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float walkingSpeed = 3.0f;
    public float runningSpeed = 6.0f;
    public float rotationSpeed = 700.0f;
    public float jumpForce = 8.0f;
    public float gravity = 30.0f;
    public float stamina = 100.0f;
    public float staminaDepletionRate = 20.0f;
    public float crouchHeight = 0.5f;
    public float standingHeight = 2.0f;

    private CharacterController characterController;
    private float originalStepOffset;
    private bool isSprinting;
    private bool isCrouching;
    private Vector3 playerVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleSprint();
        HandleCrouch();
        ApplyFinalMovements();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        Vector3 moveDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction;

        float speed = isSprinting ? runningSpeed : walkingSpeed;
        float finalSpeed = isCrouching ? speed / 2 : speed;

        if (characterController.isGrounded)
        {
            playerVelocity.y = -0.5f; // Grounded reset
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            }
        }

        playerVelocity.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * finalSpeed * Time.deltaTime);
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        Camera.main.transform.Rotate(Vector3.right * mouseY);
    }

    private void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching && stamina > 0)
        {
            isSprinting = true;
            stamina -= staminaDepletionRate * Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            if (stamina < 100)
            {
                stamina += (staminaDepletionRate / 2) * Time.deltaTime; // Stamina regeneration
            }
        }

        stamina = Mathf.Clamp(stamina, 0, 100);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                characterController.height = crouchHeight;
                characterController.center = new Vector3(0, crouchHeight / 2, 0);
                characterController.stepOffset = 0;
            }
            else
            {
                characterController.height = standingHeight;
                characterController.center = new Vector3(0, standingHeight / 2, 0);
                characterController.stepOffset = originalStepOffset;
            }
        }
    }

    private void ApplyFinalMovements()
    {
        // You can add any final movements or adjustments here
    }
}
