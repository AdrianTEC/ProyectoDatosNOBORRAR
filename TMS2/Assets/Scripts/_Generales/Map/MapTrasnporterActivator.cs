using System;

using UnityEngine;

public class MapTrasnporterActivator : MonoBehaviour
{
    public twoWayTransporterDirection Direction;
    private MapTransporter _mapTransporter;
    void Start()
    {
        _mapTransporter = transform.parent.GetComponent<MapTransporter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            _mapTransporter.Transport(other.gameObject,Direction);
    }




    private void OnDrawGizmos()
    {
        BoxCollider bc=GetComponent<BoxCollider>();
        var size = bc.size;
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, size.z));
    }
}
