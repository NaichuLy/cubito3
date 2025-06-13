using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private NormalCubeHole cubeHole;
    [SerializeField] private Transform door;
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float openSpeed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool opening = false;

    void Start()
    {
        closedPos = door.position;
        openPos = closedPos + openOffset;
    }

    void Update()
    {
        if (!opening && cubeHole != null && cubeHole.IsSlotOccupied())
        {
            opening = true;
        }

        if (opening)
        {
            door.position = Vector3.MoveTowards(door.position, openPos, openSpeed * Time.deltaTime);
        }
    }
}
