using UnityEngine;



[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapon")]
public class WeaponModel : ScriptableObject
{

    public Transform pfWeapon;
    public int damage;

    public int maxAmmo;

    public Weapontype weapontype;



}


