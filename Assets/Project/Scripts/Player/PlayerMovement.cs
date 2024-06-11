using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///  PlayerMovement Controller 
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    private Camera mCamer;
    private Animator animator;
    private PlayerController inputControls;
    private bool isRunning;
    [Header(" Movement Info")]
    private Vector3 moveDir;
    private Vector2 moveInput;
    private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runspeed;

    [Header(" Aim Info")]
    private Vector2 aimInput;
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
        //Running 
        inputControls.Character.Run.performed += context =>
        {
            if (moveDir.magnitude > 0)
            {
                speed = runspeed;
                isRunning = true;
            }

        };
        inputControls.Character.Run.canceled += context =>
        {
            speed = walkSpeed;
            isRunning = false;
        };
        mCamer = Camera.main;
        animator = GetComponentInChildren<Animator>();


    }
    private void Start()
    {
        speed = walkSpeed;
    }

    private void Update()
    {
        ApplyMovement();
        AimAt();
        AnimationControllerForPlayer();


    }

    private void AnimationControllerForPlayer()
    {
        float xVelocity = Vector3.Dot(moveDir.normalized, transform.right);
        float zVelocity = Vector3.Dot(moveDir.normalized, transform.forward);


        animator.SetFloat("xvelocity", xVelocity, 0.1f, Time.deltaTime);
        animator.SetFloat("zvelocity", zVelocity, 0.1f, Time.deltaTime);
        animator.SetBool("IsRunning", isRunning);
    }

    private void AimAt()
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
            transform.position += moveDir * Time.deltaTime * speed;
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


