using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum twoWayTransporterDirection
{
    toA,
    toB
}
public class MapTransporter : MonoBehaviour
{
    public Transform A;
    public Transform B;
    private Animator transition;

    private void Start()
    {
        transition = GameObject.FindWithTag("MapTransition").GetComponent<Animator>();
    }

    public void Transport(GameObject other, twoWayTransporterDirection direction)
    {
        transition.Play("RoomTransition");
        CharacterController controller= other.GetComponent<CharacterController>();
        controller.enabled = false;
        if(direction==twoWayTransporterDirection.toA)
            other.transform.position = A.position;
        if(direction==twoWayTransporterDirection.toB)
            other.transform.position = B.position;
        controller.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(A.position,B.position);
    }
}
