using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bottomPressed : MonoBehaviour
{
    [SerializeField] private LayerMask allowedLayer;
    [SerializeField]protected bool pressed = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == allowedLayer)
        {
            pressed = true;
        }
        else  pressed = false;
    }

    private void OnTriggerExit(Collider other)
    {
            pressed = false;
    }

}
