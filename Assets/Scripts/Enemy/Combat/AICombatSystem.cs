using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UGG.Combat;
public class AICombatSystem :CharacterCombatSystemBase
{
    [SerializeField, Header("检测范围")] Transform detectionCenter;
    [SerializeField] float detectionRang;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisObstacle;
    Collider[] detectionedTarget = new Collider[1];
    [SerializeField,Header("当前检测到的目标")]public Transform curTarget;
    int lockOnID=Animator.StringToHash("LockOn");
    private void Update()
    {
        AIView();
        LockOnTarget(); 
    }
    public void AIView()
    {
        int targetCount=Physics.OverlapSphereNonAlloc(detectionCenter.position,detectionRang,
            detectionedTarget,whatisEnemy);
        if(targetCount>0)
        {
            if(!Physics.Raycast(transform.root.position+transform.root.up*0.5f,
                detectionedTarget[0].transform.position - transform.root.position,
                whatisObstacle))
            {
                if(Vector3.Dot((detectionedTarget[0].transform.position - transform.root.position).normalized,
                    transform.root.forward) > 0.15f)
                {
                    curTarget = detectionedTarget[0].transform;
                }
            }
        }
        
    }
    public Transform GetCurTarget()
    {
        return curTarget;
    }
    public float GetCurTargetDistance()
    {
        return Vector3.Distance(transform.root.position,curTarget.position);
    }
    void LockOnTarget()
    {
        if (_animator.CheckAnimationTag("Motion") && curTarget != null)
        {
            _animator.SetFloat(lockOnID, 1f);
            transform.root.rotation= transform.LockYOnTarget(curTarget, transform.root, 50f);
        }
        else
        {
            _animator.SetFloat(lockOnID, 0f);
        }
    }
    void UpdateAnimationMove()
    {
        if (_animator.CheckAnimationTag("Roll"))
        {
            _characterMovementBase.CharacterMoveInterface(transform.root.forward,_animator.GetFloat(animationMoveID),true);
        }
    }
}
