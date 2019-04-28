using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent navMeshAgentPlayer;
    private Animator charAnimator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgentPlayer = GetComponent<NavMeshAgent>();
        charAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    MoveToClickedCursorPosition();
        //}

        UpdateAnimator();

    }

    public void MoveTo(Vector3 destination)
    {
        navMeshAgentPlayer.destination = destination;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgentPlayer.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;

        charAnimator.SetFloat("forwardSpeed", speed);
    }


}
