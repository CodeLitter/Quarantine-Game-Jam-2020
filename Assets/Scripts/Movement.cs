using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public CharacterController2D characterController2D;
    private Vector2 _direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        characterController2D = GetComponentInParent<CharacterController2D>();
    }

    private void FixedUpdate()
    {
        Vector2 motion = new Vector2
        {
            x = _direction.x * speed,
            y = _direction.y * speed
        };
        characterController2D.Move(motion);
    }
}
