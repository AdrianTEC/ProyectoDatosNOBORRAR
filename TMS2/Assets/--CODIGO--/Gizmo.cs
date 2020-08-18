using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    // Start is called before the first frame update
 public float gizmoSize = 0.75f;
  public Color gizmoColor = Color.yellow;

 void OnDrawGizmos() {
  Gizmos.color = gizmoColor;
  Gizmos.DrawWireSphere(transform.position, gizmoSize);
}}
