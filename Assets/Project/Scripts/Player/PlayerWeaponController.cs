using System;
using UnityEngine;

/// <summary>
///  This can be change to MVC . Where view is attached to player , controller with login , SO of Weapons (Model)
/// </summary>

public class PlayerWeaponController : MonoBehaviour
{
    private Player player;
    private PlayerController inputActions;
    private Animator animator;
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Start()
    {
        inputActions = player.GetPlayerController();
        animator = GetComponent<Animator>();
        AssignControllers();
    }

    private void AssignControllers()
    {
        inputActions.Character.Fire.performed += context => Shoot();
    }

    private void Shoot()
    {

    }
}


