using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibleLocations : MonoBehaviour
{
    [SerializeField] private LayerMask _invisibleRayMask;
    [SerializeField] private float _visionRadius = 4f; 
    private Vector3 _posOffset = new(0, 1f, 0); 
    private bool _isNear;

    private void Update()
    {
        _isNear = IsNear();
        if (_isNear)
        {
            Debug.Log("Hay algo invisible cerca");
        }
        else
        {
            Debug.Log("No hay algo invisible cerca");
        }
    }

    private bool IsNear()
    {
        Vector3 sphereCenter = transform.position + _posOffset;
        return Physics.CheckSphere(sphereCenter, _visionRadius, _invisibleRayMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isNear ? Color.green : Color.yellow;
        Vector3 sphereCenter = transform.position + _posOffset;
        Gizmos.DrawWireSphere(sphereCenter, _visionRadius);
    }
}
