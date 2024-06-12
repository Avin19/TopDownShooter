using UnityEngine;

/// <summary>
///  Wweapon MVC View 

/// </summary>
public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform[] weaponsTransfrom;


    private void Start()
    {
        foreach (Transform weapon in weaponsTransfrom)
        {
            weapon.gameObject.SetActive(false);
        }
    }
}


