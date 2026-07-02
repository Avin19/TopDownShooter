using UnityEngine;

/// <summary>
///  
/// </summary>

public class FirePoint : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;

    public Transform GetFiringPointOfGun() => firingPoint;
}


