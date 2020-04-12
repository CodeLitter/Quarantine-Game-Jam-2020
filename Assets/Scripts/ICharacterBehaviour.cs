using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterBehaviour<Type>
{
    void OnBehaviour(Type value);
}
