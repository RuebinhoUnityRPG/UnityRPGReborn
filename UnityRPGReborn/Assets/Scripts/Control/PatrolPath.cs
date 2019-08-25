using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        const float waypointGizmoRadius = 0.3f;

        private void OnDrawGizmos()
        {
            for (int i=0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypointPosition(i), waypointGizmoRadius);
                Gizmos.DrawLine(GetWaypointPosition(i), GetWaypointPosition(j));
            }
        }

        private int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;
            }

            return i + 1;
        }

        private Vector3 GetWaypointPosition(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
