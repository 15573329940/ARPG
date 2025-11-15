using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGG.Health
{
    public class AIHealthSystem : CharacterHealthSystemBase
    {
        void LateUpdate()
        {
            OnHitLockTarget();
        }
        public override void TakeDamager(float damage, string hitAnimationName, Transform attacker)
        {
            SetAttacker(attacker);
            _animator.Play(hitAnimationName, 0, 0f);
            GameAssets.Instance.PlaySoundEffect(_audioSource, SoundAssetsType.hit);
            
        }

        void OnHitLockTarget()
        {
            if (_animator.CheckAnimationTag("Hit") && currentAttacker != null)
            {
                transform.rotation = transform.LockOnTarget(currentAttacker, transform, 50f);
            }
        }
    }
}