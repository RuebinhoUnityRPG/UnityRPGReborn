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
        Transform target = null;
        private Mover mover;
        private ActionScheduler actionscheduler;
        private Animator animator;

        private void Start()
        {
            mover = GetComponent<Mover>();
            actionscheduler = GetComponent<ActionScheduler>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
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
            animator.SetTrigger("attack");
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

        //this is an animation event
        void Hit()
        {

        }
    }

}
