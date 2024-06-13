
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

/// <summary>
///  Wweapon MVC View 

/// </summary>
public class WeaponView : MonoBehaviour
{
    private WeaponController controller;
    [SerializeField] private Transform[] weaponsTransfrom;

    [SerializeField] private Transform leftHand_IK;
    [SerializeField] private Transform rig;
    private Player player;
    private PlayerController inputActions;
    private Animator animator;
    private bool resetRig = false;
    private bool resetGrabRig = false;
    private Rig rigWright;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponentInParent<Animator>();
        inputActions = player.GetPlayerController();
    }
    private void Start()
    {

        WeaponsTransfromList();
        rigWright = rig.GetComponent<Rig>();
        controller.SetAnimator(animator);
        controller.SetPistol();
        inputActions.Character.ChangeWeapon.performed += context =>
        {
            rigWright.weight = 0f;
            resetGrabRig = true;
            controller.ChangeWeapon();
        };
        inputActions.Character.Fire.performed += context => controller.Shoot();
        inputActions.Character.Reload.performed += context =>
        {
            rigWright.weight = 0f;
            resetRig = true;
            controller.ReloadWeapon();
        };
    }

    public void SetWeaponController(WeaponController _controller) => this.controller = _controller;
    public void WeaponsTransfromList() => controller.DisableAllWeapons(weaponsTransfrom);
    public void SetLeftHandIK(Transform _leftHand_IK)
    {
        this.leftHand_IK.localPosition = _leftHand_IK.localPosition;
        this.leftHand_IK.localRotation = _leftHand_IK.localRotation;
    }
    private void Update()
    {
        if (resetRig && rigWright.weight < 1)
        {
            rigWright.weight += 0.05f * Time.deltaTime;
        }
        if (resetGrabRig && rigWright.weight < 1)
        {
            rigWright.weight += 1f * Time.deltaTime;
        }
        if (rigWright.weight == 1)
        {
            resetRig = false;
            resetGrabRig = false;
            animator.SetBool("busyGrabbing", false);
        }
    }
    public Animator GetAnimator() => animator;

}


