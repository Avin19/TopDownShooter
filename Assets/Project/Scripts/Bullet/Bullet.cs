using Unity.Mathematics;
using UnityEngine;

/// <summary>
///  
/// </summary>

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletImpact;
    private void OnCollisionEnter(Collision other)
    {
        if (other.contacts.Length > 0)
        {
            ContactPoint contact = other.contacts[0];
            Destroy(Instantiate(bulletImpact, contact.point, Quaternion.LookRotation(contact.normal)), 1f);
        }
        Destroy(gameObject);
    }

}


