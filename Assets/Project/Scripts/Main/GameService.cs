using UnityEngine;

/// <summary>
///  Game Service

/// </summary>

public class GameService : MonoBehaviour
{
    //Services

    private PlayerService playerService;
    //controller 
    private WeaponController weaponController;
    [Header("ScriptableObject")]
    //SO
    [SerializeField] private WeaponList weaponList;

    [Header("View")]
    //view
    [SerializeField] private WeaponView weaponView;
    //Perfabs
    [Header("Perfabs")]
    [SerializeField] private Transform pfBullet;


    private void Start()
    {
        weaponController = new WeaponController(weaponView, weaponList, pfBullet);
    }
}


