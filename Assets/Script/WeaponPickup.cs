using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public int weaponIndex;

    public void Pickup(InputManager manager)
    {
        manager.PickupWeapon(weaponIndex);
        Destroy(gameObject);
    }
}