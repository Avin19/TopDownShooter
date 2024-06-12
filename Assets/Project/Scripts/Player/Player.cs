using UnityEngine;

/// <summary>
///  
/// </summary>

public class Player : MonoBehaviour
{

    private PlayerController inputActions;

    private void Awake()
    {

        inputActions = new PlayerController();
    }
    public PlayerController GetPlayerController()
    {
        return inputActions;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

}


