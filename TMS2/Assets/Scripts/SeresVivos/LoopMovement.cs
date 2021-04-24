using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
public enum LoopPatrons
{
    XSin,
    YSin,
    Circular,
    Square,
    triangle
}
public class LoopMovement : MonoBehaviour
{
    public float speed;
    public LoopPatrons patron;
    public float maxDistance;  //for squares this number is the diagonal, for circles the ratio, for sens the limits 

    private Transform _target;
    private float _time;
    
    
    
    private List<Vector3> _directions=new List<Vector3>();
    private int _currentDirection;



    public void Start()
    {
        _target = transform.GetChild(0);
        
        
        switch (patron)
        {
            case LoopPatrons.Circular:
                return;
            case  LoopPatrons.Square:
                CalculateVectorsForBox();
                break;
            case  LoopPatrons.XSin:
                CalculateVectorsForSin(maxDistance,0);
                break;
            case  LoopPatrons.YSin:
                CalculateVectorsForSin(0,maxDistance);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
           
        
        _target.position  = _directions[0];
        _currentDirection = 1;       
        
    }

    void Update() {
        _time += Time.deltaTime;
        if(patron!=LoopPatrons.Circular) PatrolMovement();
        else CircleMovement();
    }

    private void PatrolMovement()
    {
        _target.position = Vector3.MoveTowards(_target.position, _directions[_currentDirection],speed*Time.deltaTime);
        
        if (Vector3.Distance(_target.position, _directions[_currentDirection]) > 0.2f) return;
        
        _currentDirection++;
        if (_currentDirection >= _directions.Count) _currentDirection = 0;
    }

    private void CircleMovement()
    {
        float posx =maxDistance* Mathf.Cos(_time*speed);
        float posy =maxDistance* Mathf.Sin(_time*speed);
        _target.localPosition = new Vector3(posx, posy, 0);
    }

    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        switch (patron)
        {
            case LoopPatrons.Square:
                float side = 0.7071f* maxDistance;
                
                Vector3 p1, p2, p3, p4;
                p1 =center+ new Vector3(side, -side);
                p2 =center+ new Vector3(side, side);
                p3 =center+ new Vector3(-side, side);
                p4 =center+ new Vector3(-side ,- side);
                
                Gizmos.DrawLine(p1,p2);
                Gizmos.DrawLine(p2,p3);
                Gizmos.DrawLine(p3,p4);
                Gizmos.DrawLine(p4,p1);
               
                
                foreach (var dot in _directions)
                {
                    Gizmos.DrawSphere(dot,1);
                }
                break;
            
            case  LoopPatrons.Circular :
                var transform1 = transform;
                Handles.DrawWireDisc(center,transform1.forward,maxDistance);
                break;
            
            case  LoopPatrons.XSin:
                Gizmos.DrawLine(new Vector3(center.x - maxDistance ,center.y,center.z), center+transform.right*maxDistance);
                break;
            case  LoopPatrons.YSin:
                Gizmos.DrawLine(new Vector3(center.x  ,center.y- maxDistance,center.z), center+transform.up*maxDistance);
                break;
        }
        
        
    }

    private void CalculateVectorsForBox()
    {
        Vector3 center = transform.position;
        float side = 0.7071f* maxDistance;
                
        Vector3 p1, p2, p3, p4;
        p1 =center+ new Vector3(side, -side);
        p2 =center+ new Vector3(side, side);
        p3 =center+ new Vector3(-side, side);
        p4 =center+ new Vector3(-side ,- side);
        _directions.Add(p1);
        _directions.Add(p2);
        _directions.Add(p3);
        _directions.Add(p4);
        
    }

    private void CalculateVectorsForSin(float x, float y)
    {
        Vector3 centre = transform.position;
        _directions.Add( centre+ new Vector3(x,y,0));
        _directions.Add( centre- new Vector3(x,y,0));

    }
    
}
