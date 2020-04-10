using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 100.0f;
    public Camera camera;
    public CharacterController characterController;
    private Vector3 _direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        Vector3 motion = _direction;
        if (camera != null)
        {
            Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            motion = Quaternion.LookRotation(Vector3.down, forward) * _direction;
        }

        characterController.Move(motion * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
        characterController.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
