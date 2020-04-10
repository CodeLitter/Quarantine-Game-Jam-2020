using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector2 _direction;

    public void OnLook(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(_direction.x, Vector3.up) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
