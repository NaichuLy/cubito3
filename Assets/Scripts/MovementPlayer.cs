using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Header("<color=green>Physics</color>")]
    [SerializeField] private LayerMask _groundRayMask;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _grounRayDistance = 0.25f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private bool _isGrounded = true;

    private Rigidbody _rb;
    private Vector3 _dir = new(), _posOffset = new();
    private Ray _groundRay;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        _isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        if (_dir.sqrMagnitude == 0f) return;

        Vector3 cameraForward = _cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = _cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * _dir.z + cameraRight * _dir.x;
        Vector3 targetPosition = _rb.position + moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime;

        _rb.MovePosition(targetPosition);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private bool IsGrounded()
    {
        _posOffset = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        _groundRay = new Ray(_posOffset, -transform.up);

        return Physics.Raycast(_groundRay, _grounRayDistance, _groundRayMask);
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_groundRay);
    }

}

