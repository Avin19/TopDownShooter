using UnityEngine;

/// <summary>
///  
/// </summary>

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;

    public Transform GetFiringPointOfGun() => firingPoint;
}


