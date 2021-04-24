using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.SeresVivos.Player;
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
        Movement movementController = other.GetComponent<Movement>();
        
        controller.enabled = false;
        movementController.enabled = false;
        if(direction==twoWayTransporterDirection.toA)
            other.transform.position = A.position;
        if(direction==twoWayTransporterDirection.toB)
            other.transform.position = B.position;
        controller.enabled = true;
        StartCoroutine(activeWalkAgain(movementController, .5f));
    }
    IEnumerator activeWalkAgain(Movement controller,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // Now do your thing here
        controller.enabled = true;
        controller.isometricMove(Vector3.forward, 0.01f);

    }
 
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(A.position,B.position);
    }
}
