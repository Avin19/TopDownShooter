using UnityEngine;

/// <summary>
///  This GenericSingletonMono

/// </summary>

public class GenericSingletonMonobehaviour<T> : MonoBehaviour where T : GenericSingletonMonobehaviour<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


