using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public GunBase gunbase;

        [Header("Attack Settings")]
        public float attackRange = 15f;

        [Range(-1f, 1f)]
        public float viewDot = 0.7f;

        private bool _isShooting;

        public override void Update()
        {
            base.Update();

            if (_player == null) return;

            Vector3 direction = (_player.transform.position - transform.position).normalized;
            float sqrDistance = (_player.transform.position - transform.position).sqrMagnitude;
            float dot = Vector3.Dot(transform.forward, direction);

            if (dot > viewDot && sqrDistance <= attackRange * attackRange)
            {
                if (!_isShooting)
                {
                    _isShooting = true;
                    gunbase.StartShoot();
                }
            }
            else
            {
                if (_isShooting)
                {
                    _isShooting = false;
                    gunbase.StopShoot();
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}