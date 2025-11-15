using System.Collections;
using System.Collections.Generic;
using UGG.Move;
using UnityEngine;
[CreateAssetMenu(fileName = "ToCombatCondition", menuName = "StateMachine/Condition/ToCombatCondition")]
public class ToCombatCondition : ConditionSO
{
    protected AICombatSystem _combatSystem;
    
    public override bool ConditionSetUp()
    {
        return _combatSystem.GetCurTarget() != null;    
    }
}
