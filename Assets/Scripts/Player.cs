using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        foreach (var behaviour in GetComponentsInChildren<ICharacterBehaviour<Vector3>>())
        {
            if ((behaviour as MonoBehaviour).enabled)
            {
                behaviour.OnBehaviour(context.ReadValue<Vector2>());
            }
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        foreach (var behaviour in GetComponentsInChildren<ICharacterBehaviour<Vector2>>())
        {
            if ((behaviour as MonoBehaviour).enabled)
            {
                behaviour.OnBehaviour(context.ReadValue<Vector2>());
            }
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            foreach (var behaviour in GetComponentsInChildren<ICharacterBehaviour>())
            {
                if ((behaviour as MonoBehaviour).enabled)
                {
                    behaviour.OnBehaviour();
                }
            }
        }
    }
}
