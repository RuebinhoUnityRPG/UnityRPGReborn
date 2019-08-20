using RPG.Core;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target = null;
        float timeSinceLastAttack;

        private Mover mover;
        private ActionScheduler actionscheduler;
        private Animator animator;

        private Health enemyTargetHealth;

        private void Start()
        {
            mover = GetComponent<Mover>();
            actionscheduler = GetComponent<ActionScheduler>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //this will trigger the Hit() Method
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
        }

        //this is an animation event
        void Hit()
        {
            enemyTargetHealth = target.GetComponent<Health>();
            enemyTargetHealth.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(this.transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionscheduler.StartAction(this);
            print("i fuck you up!");
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

    }

}
