
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Wweapon MVC View 

/// </summary>
public class WeaponView : MonoBehaviour
{
    private WeaponController controller;
    [SerializeField] private Transform[] weaponsTransfrom;
    [SerializeField] private Transform leftHand_IK;
    private Player player;
    private PlayerController inputActions;
    private Animator animator;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponentInParent<Animator>();
        inputActions = player.GetPlayerController();
    }
    private void Start()
    {

        WeaponsTransfromList();

        controller.SetAnimator(animator);
        controller.SetPistol();
        inputActions.Character.ChangeWeapon.performed += context =>
        {

            controller.ChangeWeapon();

        };
        inputActions.Character.Fire.performed += context => controller.Shoot();
    }

    public void SetWeaponController(WeaponController _controller) => this.controller = _controller;
    public void WeaponsTransfromList() => controller.DisableAllWeapons(weaponsTransfrom);
    public void SetLeftHandIK(Transform _leftHand_IK)
    {
        this.leftHand_IK.localPosition = _leftHand_IK.localPosition;
        this.leftHand_IK.localRotation = _leftHand_IK.localRotation;
    }
    public Animator GetAnimator() => animator;
}


