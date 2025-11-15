using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AICombat", menuName = "StateMachine/State/AICombat")]
public class AICombat : StateActionSO
{
    public AIMovement _movement;
    override public void OnUpdate()
    {
        
    }
    void NoCombat()
    {
        if(_animator.CheckAnimationTag("Motion") )
        {
            if (_combatSystem.GetCurTargetDistance() < 4.2f)
            {
                _movement.CharacterMoveInterface(-_movement.transform.forward, 1.5,true);
                _animator.SetFloat(verticalID, 1.5f, 0.1f, Time.deltaTime);
                _animator.SetFloat(horizontalID, 0f, 0.1f, Time.deltaTime);
                if (_combatSystem.GetCurTargetDistance() < 1.8f)
                {
                    _animator.Play("Roll_B",0,0);
                }
            }
            else
            {
                _movement.CharacterMoveInterface(_movement.transform.forward, 1.5,true);
                _animator.SetFloat(verticalID, 1.5f, 0.1f, Time.deltaTime);
                _animator.SetFloat(horizontalID, 0f, 0.1f, Time.deltaTime);
            }
        }
    }
}
