using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, ICharacterBehaviour<Vector3>
{
    public float speed = 1.0f;
    public Camera camera;
    public CharacterController characterController;
    private Vector3 _direction;

    public void OnBehaviour(Vector3 value)
    {
        _direction = value;
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
        Vector3 position = characterController.transform.position;
        position.y = 0.0f;
        characterController.transform.position = position;
    }
}
