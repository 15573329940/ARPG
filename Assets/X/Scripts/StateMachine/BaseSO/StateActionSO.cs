using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateActionSO : ScriptableObject
{
    [SerializeField] protected int statePriority;//״̬���ȼ�
    public Animator _animator;
    public AICombatSystem _combatSystem;
    public virtual void OnEnter(StateMachineSystem stateMachineSystem) { }

    public abstract void OnUpdate();

    public virtual void OnExit() { }

    /// <summary>
    /// ��ȡ״̬���ȼ�
    /// </summary>
    /// <returns></returns>
    public int GetStatePriority() => statePriority;
}
