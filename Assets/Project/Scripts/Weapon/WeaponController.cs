
using UnityEngine;
using UnityEngine.Animations.Rigging;
/// <summary>
///  
/// </summary>


public class WeaponController
{
    private WeaponView weaponView;
    private WeaponList weaponList;
    private Transform[] weapons;
    private Animator animator;
    private Transform activateWeapon;
    private Transform pfBullet;
    private int activateWeaponCount = 0;

    public WeaponController(WeaponView _weaponView, WeaponList _weaponList, Transform _pfBullet)
    {
        this.weaponView = _weaponView;
        weaponView.SetWeaponController(this);
        this.weaponList = _weaponList;
        this.pfBullet = _pfBullet;

    }

    public void DisableAllWeapons(Transform[] weapons)
    {
        this.weapons = weapons;
        foreach (Transform weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }
    private void SetActiveWeapon()
    {
        activateWeapon.gameObject.SetActive(true);
        weaponView.SetLeftHandIK(weapons[activateWeaponCount].GetComponentInChildren<LeftHandIKscript>().transform);
        SetAnimationLayer();
    }

    public void ChangeWeapon()
    {

        DisableAllWeapons(weapons);
        if (activateWeaponCount == weapons.Length - 1)
        {
            activateWeaponCount = 0;
            activateWeapon = weapons[activateWeaponCount];
            SetActiveWeapon();
            return;
        }
        activateWeaponCount++;
        activateWeapon = weapons[activateWeaponCount];
        SetActiveWeapon();
    }
    public void SetAnimationLayer()
    {
        animator.SetBool("busyGrabbing", true);
        for (int i = 1; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        if (activateWeaponCount <= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
        else if (activateWeaponCount == 3)
        {
            animator.SetLayerWeight(2, 1);
        }
        else
        {
            animator.SetLayerWeight(3, 1);
        }

        // weapontype grab is remaining 

    }

    public void Shoot()
    {
        animator.SetTrigger("Fire");
        Transform gunAimPoint = activateWeapon.GetComponent<Weapon>().GetFiringPointOfGun();
        GameObject bullet = GameObject.Instantiate(pfBullet, gunAimPoint.position, Quaternion.LookRotation(gunAimPoint.forward)).gameObject;
        bullet.GetComponent<Rigidbody>().velocity = activateWeapon.GetComponent<Weapon>().GetFiringPointOfGun().forward * 20f;
        GameObject.Destroy(bullet, 5f);
    }
    public void ReloadWeapon()
    {
        animator.SetTrigger("Reload");

    }


    public void SetAnimator(Animator _animator)
    {
        animator = weaponView.GetAnimator();
    }

    public void SetPistol()
    {
        activateWeapon = weapons[activateWeaponCount];
        SetActiveWeapon();

    }
}


