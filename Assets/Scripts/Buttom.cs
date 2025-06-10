using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
   public bool _pressed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            _pressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
         if (gameObject.CompareTag("Player"))
        {
            _pressed = true;
        }
    }
}
