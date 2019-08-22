using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        private NavMeshAgent navMeshAgentPlayer;
        private Animator charAnimator;
        private ActionScheduler actionscheduler;
        private Health health;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgentPlayer = GetComponent<NavMeshAgent>();
            charAnimator = GetComponent<Animator>();
            actionscheduler = GetComponent<ActionScheduler>();
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            navMeshAgentPlayer.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            actionscheduler.StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgentPlayer.isStopped = false;
            navMeshAgentPlayer.destination = destination;
        }

        public void Cancel()
        {
            navMeshAgentPlayer.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgentPlayer.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            charAnimator.SetFloat("forwardSpeed", speed);
        }
    }
}

