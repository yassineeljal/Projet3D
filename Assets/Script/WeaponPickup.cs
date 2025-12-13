using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public int weaponIndex;

    public void Pickup(InputManager manager)
    {
        manager.PickupWeapon(weaponIndex);

        if (weaponIndex == 0)
            QuestManager.Instance.CompleteQuest(0);
            QuestManager.Instance.CompleteQuest(1);


        Destroy(gameObject);
    }


    
}