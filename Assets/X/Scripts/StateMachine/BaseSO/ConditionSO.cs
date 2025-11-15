using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ConditionSO : ScriptableObject
{
    [SerializeField] protected int priority;//�������ȼ�
    
    public virtual void Init(StateMachineSystem stateSystem) { }
    
    public abstract bool ConditionSetUp();//�����Ƿ����

    /// <summary>
    /// ��ȡ��ǰ���������ȼ�
    /// </summary>
    /// <returns></returns>
    public int GetConditionPriority() => priority;
}
