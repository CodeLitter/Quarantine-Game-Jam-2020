using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private List<ICharacterBehaviour<Vector3>> _vector3Behaviours = new List<ICharacterBehaviour<Vector3>>();
    private List<ICharacterBehaviour<Vector2>> _vector2Behaviours = new List<ICharacterBehaviour<Vector2>>();

    public void OnMove(InputAction.CallbackContext context)
    {
        foreach (var behaviour in _vector3Behaviours)
        {
            behaviour.OnBehaviour(context.ReadValue<Vector2>());
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        foreach (var behaviour in _vector2Behaviours)
        {
            behaviour.OnBehaviour(context.ReadValue<Vector2>());
        }
    }

    private void Awake()
    {
        _vector3Behaviours.AddRange(GetComponentsInChildren<ICharacterBehaviour<Vector3>>());
        _vector2Behaviours.AddRange(GetComponentsInChildren<ICharacterBehaviour<Vector2>>());
    }
}
