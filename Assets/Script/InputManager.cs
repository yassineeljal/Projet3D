using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    private WeaponManager weaponManager; 
    private PlayerInteract playerInteract; 

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        weaponManager = GetComponent<WeaponManager>(); 
        playerInteract = GetComponent<PlayerInteract>();

        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Shoot.started += ctx => weaponManager.StartFiring();
        onFoot.Shoot.canceled += ctx => weaponManager.StopFiring();

        onFoot.Interact.performed += ctx => playerInteract.ProcessInteract();

        onFoot.Slot1.performed += ctx => weaponManager.SwitchToWeapon(0);
        onFoot.Slot2.performed += ctx => weaponManager.SwitchToWeapon(1);
    }

    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() => onFoot.Enable();
    private void OnDisable() => onFoot.Disable();

    public void PickupWeapon(int index)
    {
        if(weaponManager != null)
        {
            weaponManager.PickupWeapon(index);
        }
    }
}