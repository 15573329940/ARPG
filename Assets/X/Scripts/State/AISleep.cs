using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "AISleep", menuName = "StateMachine/State/AISleep")]
public class AISleep : StateActionSO
{
    override public void OnUpdate()
    {
        Debug.Log("AI is sleeping...");
    }
}
