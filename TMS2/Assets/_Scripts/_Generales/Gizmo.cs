using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GizmoType
{
    cube,
    sphere,
    Wcube,
    Wsphere

}
public class Gizmo : MonoBehaviour
{
    public GizmoType myType = GizmoType.sphere;
    public float gizmoSize = 0.75f;
    public Color gizmoColor = Color.yellow;

    void OnDrawGizmos() 
    {
     Gizmos.color = gizmoColor;
     if(myType==GizmoType.Wsphere)
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
     if(myType==GizmoType.Wcube)
        Gizmos.DrawWireCube(transform.position, new Vector3(gizmoSize,gizmoSize,gizmoSize ));

    }
     
}
