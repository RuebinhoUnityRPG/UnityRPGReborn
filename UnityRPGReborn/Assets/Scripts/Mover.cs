using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [SerializeField] public Transform target;
    public NavMeshAgent navMeshAgentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgentPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToClickedCursorPosition();
        }

        
        //navMeshAgentPlayer.destination = target.position;
    }

    private void MoveToClickedCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasRaycastHit = Physics.Raycast(ray, out RaycastHit raycastHit);

        if (hasRaycastHit)
        {
            navMeshAgentPlayer.destination = raycastHit.point;
        }


    }


}
