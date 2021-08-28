using System;
using UnityEngine;


[RequireComponent(typeof (CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    protected float moveSpeed = 15;
    protected float jumpSpeed = 15;
    protected float gravityStrength = 4;

    public bool mouselookActive = true;
    public bool movementActive = true;

    protected const float STICK_TO_GROUND_FORCE = 10;

    protected Vector2 mouseSensitivity = new Vector2(2, 2);
    protected Vector2 currentEulerAngle = new Vector2(0, 90);

    protected bool jumpRequested = false;
    protected Vector3 movementVector = Vector3.zero;


    protected CharacterController characterController;
    protected Camera characterCamera;
    protected CollisionFlags lastCollisionFlags;

    private bool fixedUpdateMouseButtonDown = false;

    virtual protected void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    virtual protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            mouselookActive = !mouselookActive;

        if (!mouselookActive)
            return;

        Vector2 movement = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        movement *= mouseSensitivity;

        Func<float, float> clampDegrees = degrees =>
        {
            if (degrees > 360)
                degrees = degrees - 360;
            if (degrees < 0)
                degrees = 360 + degrees;

            return degrees;
        };

        currentEulerAngle += movement;
        currentEulerAngle.x = clampDegrees(currentEulerAngle.x);
        currentEulerAngle.y = clampDegrees(currentEulerAngle.y);
        currentEulerAngle.y = Math.Min(Math.Max(currentEulerAngle.y, 10), 170);

        characterCamera.transform.localRotation = Quaternion.Euler(currentEulerAngle.y - 90, currentEulerAngle.x, 0);

        if (!jumpRequested)
            jumpRequested = Input.GetKeyDown(KeyCode.Space);

        if (Input.GetMouseButtonDown(0))
            fixedUpdateMouseButtonDown = true;
    }

    protected virtual void FixedUpdate()
    {
       
        
        if (movementActive)
        {
            Vector2 movement = new Vector2();
            {
                if (Input.GetKey(KeyCode.A))
                    movement.x--;
                if (Input.GetKey(KeyCode.D))
                    movement.x++;
                if (Input.GetKey(KeyCode.W))
                    movement.y++;
                if (Input.GetKey(KeyCode.S))
                    movement.y--;

                movement.Normalize();
            }

            // always move along the camera forward as it is the direction that it being aimed at
            var cameraTransform = characterCamera.transform;
            Vector3 desiredMove = cameraTransform.forward * movement.y + cameraTransform.right * movement.x;

            movementVector.x = desiredMove.x * moveSpeed;
            movementVector.z = desiredMove.z * moveSpeed;

            if (characterController.isGrounded)
            {
                movementVector.y = -STICK_TO_GROUND_FORCE;

                if (jumpRequested)
                {
                    movementVector.y = jumpSpeed;
                    jumpRequested = false;
                }
            }
            else
            {
                movementVector += Physics.gravity * gravityStrength * Time.fixedDeltaTime;
            }

            lastCollisionFlags = characterController.Move(movementVector * Time.fixedDeltaTime);
        }

        if (fixedUpdateMouseButtonDown)
        {
            Ray ray = characterCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, 1000000))
                print("I'm looking at " + hit.transform.name);
            else
                print("I'm looking at nothing!");
        }
        fixedUpdateMouseButtonDown = false;
    }


    virtual protected void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // dont move the rigidbody if the character is on top of it
        if (lastCollisionFlags == CollisionFlags.Below)
            return;

        if (body == null || body.isKinematic)
            return;

        body.AddForceAtPosition(characterController.velocity, hit.point, ForceMode.Impulse);
    }
}
