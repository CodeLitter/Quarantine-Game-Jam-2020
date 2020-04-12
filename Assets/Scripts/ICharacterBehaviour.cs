using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterBehaviourBase
{
}

public interface ICharacterBehaviour<Type> : ICharacterBehaviourBase
{
    void OnBehaviour(Type value);
}

public interface ICharacterBehaviour
{
    void OnBehaviour();
}
