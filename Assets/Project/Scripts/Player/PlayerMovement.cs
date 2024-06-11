using System;
using UnityEngine;

/// <summary>
///  PlayerMovement Controller 
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    private PlayerController inputControls;
    [Header(" Movement Info")]
    private Vector3 moveDir;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float movementSpeed;
    private Vector2 moveInput;
    [Header(" Aim Info")]
    private Vector2 aimInput;
    private Camera mCamer;
    [SerializeField] private LayerMask airLayerMark;
    private Vector3 lookInDirection;
    [SerializeField] private float rotationSpeed;
    private void Awake()
    {
        inputControls = new PlayerController();
        //Movement 
        inputControls.Character.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        inputControls.Character.Movement.canceled += context => moveInput = Vector2.zero;
        //Aim 
        inputControls.Character.Aim.performed += context => aimInput = context.ReadValue<Vector2>();
        inputControls.Character.Aim.canceled += context => aimInput = Vector2.zero;
        mCamer = Camera.main;


    }

    private void Update()
    {
        ApplyMovement();
        ApplyMouseLookAt();

    }

    private void ApplyMouseLookAt()
    {
        Ray ray = mCamer.ScreenPointToRay(aimInput);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, airLayerMark))
        {
            lookInDirection = hitInfo.point - transform.position;
            lookInDirection.y = 0f;
            lookInDirection.Normalize();

            transform.forward = Vector3.Slerp(transform.forward, lookInDirection, rotationSpeed * Time.deltaTime);

        }
    }

    private void ApplyMovement()
    {
        moveDir = new Vector3(moveInput.x, 0f, moveInput.y);

        if (moveDir.magnitude > 0)
        {
            transform.position += moveDir * Time.deltaTime * movementSpeed;
        }
    }

    private void OnEnable()
    {
        inputControls.Enable();
    }
    private void OnDisable()
    {
        inputControls.Disable();
    }
}


