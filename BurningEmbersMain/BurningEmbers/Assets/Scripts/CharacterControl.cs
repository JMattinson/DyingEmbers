using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{
    private PlayerInput playerInput;
    public CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 3.0f;
    private float gravityValue = -9.81f;
    private Transform cameraTransform;
    
    
    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

    }

    void Update()
    {
        

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        
        //use this if you ever want to have a more dynamic camera, corrects player movement.
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}