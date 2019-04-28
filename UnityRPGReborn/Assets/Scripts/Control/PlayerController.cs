using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Mover mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToClickedCursorPosition();
        }
    }

    private void MoveToClickedCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasRaycastHit = Physics.Raycast(ray, out RaycastHit raycastHit);

        if (hasRaycastHit)
        {
            mover.MoveTo(raycastHit.point);
        }

    }
}
