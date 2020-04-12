using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour, ICharacterBehaviour<Vector2>
{
    public float speed = 100.0f;
    public Transform target;
    private Vector2 _direction;

    public void OnBehaviour(Vector2 value)
    {
        _direction = value;
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(_direction.x, Vector3.up) * target.rotation;
        target.rotation = Quaternion.RotateTowards(target.rotation, rotation, speed * Time.deltaTime);
    }
}
