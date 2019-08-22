using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;

        Vector3 startingPosition;
        Quaternion startingRotation;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            startingPosition = transform.position;
            startingRotation = Quaternion.identity;
        }

        private void Update()
        {
            if (health.IsDead()) { return; }
            ShouldAIChase();   
        }

        private void ShouldAIChase()
        {
            
            if (IsInAttackRange()  && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                mover.StartMoveAction(startingPosition);
            }
        }

        private bool IsInAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        //called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
