using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Vector3 moveDirection;
    private GameControls playerInput;

    private void Awake()
    {
        playerInput = new GameControls();
        playerInput.Enable();
        SetupInputs();
    }

    private void Update()
    {
        transform.Translate(moveDirection * velocity * Time.deltaTime);
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 InputDirectionon = context.ReadValue<Vector2>();

        moveDirection.x = InputDirectionon.x;
        moveDirection.y = 0f;
        moveDirection.z = InputDirectionon.y;
    }

    private void SetupInputs()
    {
        playerInput.Player.Move.started += MovePlayer;
        playerInput.Player.Move.performed += MovePlayer;
        playerInput.Player.Move.canceled += MovePlayer;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.started -= MovePlayer;
        playerInput.Player.Move.performed -= MovePlayer;
        playerInput.Player.Move.canceled -= MovePlayer;
        playerInput.Disable();
    }
}
