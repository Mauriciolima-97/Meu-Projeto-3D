using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;
using System;

namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }

    public class BossBase : MonoBehaviour
    {
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;

        [Header("Attack")]
        public int attackAmount = 5;
        public float timeBetweenAttacks = .5f;


        public float speed = 5f;
        public List<Transform> wayPoints;
        public HealthBase healthBase;

        private StateMachine<BossAction> stateMachine;

        private void OnValidate()
        {
            if (healthBase == null) healthBase = GetComponent<HealthBase>();
        }

        private void Start()
        {
            transform.localScale = Vector3.zero;
        }


        private void Awake()
        {
            Init();
            OnValidate();
            healthBase.OnKill += OnBossKill;
        }

        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());

        }

        private void OnBossKill(HealthBase h)
        {
            SwitchState(BossAction.DEATH);
        }

        #region WALK 

        public void GoToRandomPoint(Action onArrive = null)
        {
            StartCoroutine(GotoPointCoroutine(
                wayPoints[UnityEngine.Random.Range(0, wayPoints.Count)],
                onArrive));
        }
        IEnumerator GotoPointCoroutine(Transform t, Action onArrive = null)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            {
                Vector3 direction = (t.position - transform.position).normalized;

                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        lookRotation,
                        Time.deltaTime * 5f
                    );
                }

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    t.position,
                    Time.deltaTime * speed
                );

                yield return null;
            }

            onArrive?.Invoke();
        }
        #endregion

        #region ATTACK
        public void StartAttack(Action endCallBack = null)
        {
            StartCoroutine(AttackCoroutine(endCallBack));
        }

        IEnumerator AttackCoroutine(Action endCallBack)
        {
            int attacks = 0;
            while(attacks < attackAmount)
            {
                attacks++;
                transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            endCallBack?.Invoke();
        }
        #endregion

        #region ANIMATION
        public void StartInitAnimation()
        {
            transform.DOKill(); // mata qualquer tween anterior

            transform.localScale = Vector3.zero; // garante que começa do zero

            transform.DOScale(1f, startAnimationDuration)
                     .SetEase(startAnimationEase);
        }
        #endregion

        #region DEBUG
        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            SwitchState(BossAction.INIT); ;
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            SwitchState(BossAction.WALK); ;
        }
        [NaughtyAttributes.Button]
        private void SwitchAttack()
        {
            SwitchState(BossAction.ATTACK);
        }
        #endregion


        #region STATE MACHINE
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }
        #endregion
    }
}
