using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Orbit Settings")]
    public float distance = 10f;
    public float zoomedDistance = 5f;
    public float rotationSpeed = 5.0f;

    [Header("Pitch Settings")]
    public bool clampPitch = true;
    public float minPitch = -45f;
    public float maxPitch = 45f;

    [Header("Follow Smoothing")]
    public float followSpeed = 5f;

    private float yaw;
    private float pitch;
    private Vector3 currentVelocity;
    private bool isZoomedIn = false;


    private Camera cameraComponent;
    public float normalFOV = 60f;
    public float zoomedFOV = 40f;

    void Start()
    {

        cameraComponent = GetComponentInChildren<Camera>();

        if (cameraComponent == null)
        {
            Debug.LogError("No Camera component found in children of CameraRig.");
            enabled = false;
            return;
        }

        if (target == null)
        {
            Debug.LogError("CenteredCameraFollowAndRotate: No target assigned.");
            enabled = false;
            return;
        }

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        cameraComponent.fieldOfView = normalFOV;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            HandleRotation();

            if (Input.GetKeyDown(KeyCode.K))
            {
                isZoomedIn = !isZoomedIn;
                cameraComponent.fieldOfView = isZoomedIn ? zoomedFOV : normalFOV;
                distance = isZoomedIn ? zoomedDistance : 15f;
            }


            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);


            Vector3 offset = rotation * new Vector3(0, 0, -distance);
            Vector3 desiredPosition = target.position + offset;


            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, Time.deltaTime * followSpeed);


            transform.LookAt(target.position);

        }
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(1))
        {

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * rotationSpeed;

            pitch -= mouseY * rotationSpeed;
            if (clampPitch)
            {
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            }
        }
    }
}
