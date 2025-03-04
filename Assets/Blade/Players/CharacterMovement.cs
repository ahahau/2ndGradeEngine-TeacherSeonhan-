using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f, gravity = -9.81f;
    [SerializeField] private CharacterController characterController;
    
    public bool IsGround => characterController.isGrounded;
    
    private Vector3 _velocity;
    public Vector3 velocity => _velocity;
    
    private float _verticalVelocity;
    private Vector3 _movementDirection;

    public void SetMovementDirection(Vector2 movementInput)
    {
        _movementDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        ApplyGravity();
        Move();
    }

    private void Move()
    {
        characterController.Move(_velocity);
    }

    private void ApplyGravity()
    {
        if (IsGround && _verticalVelocity < 0)
            _verticalVelocity = -0.03f; //살짝 아래로 당겨주는 힘
        else
            _verticalVelocity += gravity * Time.fixedDeltaTime;
        
        _velocity.y = _verticalVelocity;
    }

    private void CalculateMovement()
    {
        _velocity = Quaternion.Euler(0,-45f,0) * _movementDirection;
        _velocity *= moveSpeed * Time.fixedDeltaTime;
        if(_velocity.magnitude > 0)
            transform.rotation = Quaternion.LookRotation(_velocity);
    }
}
