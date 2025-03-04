using System;
using Blade.Test;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        playerInput.OnMovementChange += HandleMovementChange;
    }

    private void OnDestroy()
    {
        playerInput.OnMovementChange -= HandleMovementChange;
    }

    private void HandleMovementChange(Vector2 movementInput)
    {
        movement.SetMovementDirection(movementInput);
    }
}
