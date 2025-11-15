using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGG.Combat
{
    public class PlayerCombatSystem : CharacterCombatSystemBase
    {

        //Speed
        [SerializeField, Header("攻击移动速度倍率"), Range(.1f, 10f)]
        private float attackMoveMult;

        //检测
        [SerializeField, Header("检测敌人")] private Transform detectionCenter;
        [SerializeField] private float detectionRang;

        //缓存
        public Collider[] detectionedTarget = new Collider[1];
        public Transform curTarget;
        private void Update()
        {
            PlayerAttackAction();
            DetectionTarget();
            ActionMotion();
            UpdateCurTarget();
        }
        void LateUpdate()
        {
            OnAttackActionAutoLockOn();
        }
        private void PlayerAttackAction()
        {
            if (_characterInputSystem.playerRAtk)
            {
                if (_characterInputSystem.playerLAtk)
                {
                    _animator.SetTrigger(lAtkID);
                }
            }
            else
            {
                if (_characterInputSystem.playerLAtk)
                {
                    _animator.SetTrigger(lAtkID);
                }
            }
            _animator.SetBool(sWeaponID, _characterInputSystem.playerRAtk);
        }
        void OnAttackActionAutoLockOn()
        {
            if (CanAttackLockOn() && curTarget != null)
            {
                if (_animator.CheckAnimationTag("Attack") || _animator.CheckAnimationTag("GSAttack"))
                {
                    transform.root.rotation = transform.LockYOnTarget(curTarget, transform.root, 50f);
                }
            }

        }





        private void ActionMotion()
        {
            if (_animator.CheckAnimationTag("Attack") || _animator.CheckAnimationTag("GSAttack"))
            {
                _characterMovementBase.CharacterMoveInterface(transform.forward, _animator.GetFloat(animationMoveID) * attackMoveMult, true);
            }
        }

        #region 动作检测

        /// <summary>
        /// 攻击状态是否允许自动锁定敌人
        /// </summary>
        /// <returns></returns>
        private bool CanAttackLockOn()
        {
            if (_animator.CheckAnimationTag("Attack"))
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75f)
                {
                    return true;
                }
            }
            return false;
        }


        private void DetectionTarget()
        {
            int targetCount = Physics.OverlapSphereNonAlloc(detectionCenter.position, detectionRang, detectionedTarget,
                enemyLayer);

            //后续功能补充
            if (targetCount > 0)
            {
                SetCurTarget(detectionedTarget[0].transform);
            }
        }
        void SetCurTarget(Transform target)
        {
            if (curTarget != target)
                curTarget = target;
        }
        void UpdateCurTarget()
        {
            if (_animator.CheckAnimationTag("Motion"))
            {
                if (_characterInputSystem.playerMovement.sqrMagnitude > 0)
                {
                    curTarget = null;
                }
            }
        }
        #endregion
    }
}

