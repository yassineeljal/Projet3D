using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    [Header("Liste des armes")]
    public List<Gun> weapons; 
    
    private Gun currentGun;
    private int currentWeaponIndex = -1;
    
    private List<bool> hasWeapon = new List<bool>();

    private bool isFiring = false;

    void Start()
    {
        foreach(var gun in weapons)
        {
            if(gun != null) gun.gameObject.SetActive(false); 
            hasWeapon.Add(false); 
        }
    }

    void Update()
    {
        if (currentGun != null && currentGun.allowButtonHold && isFiring)
        {
            currentGun.AttemptShoot();
        }
    }

    public void StartFiring() 
    {
        isFiring = true;
        
        if (currentGun != null && currentGun.allowButtonHold == false)
        {
            currentGun.AttemptShoot();
        }
    }
    public void StopFiring() => isFiring = false;

       public void SwitchToWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return;

    
        if (hasWeapon[index] == false) 
        {
            return;
        }

        if (currentGun != null)
            currentGun.gameObject.SetActive(false);

        currentWeaponIndex = index;
        currentGun = weapons[index];
        currentGun.gameObject.SetActive(true);

    }

    public void PickupWeapon(int index)
    {
        if (index >= weapons.Count) return;

        hasWeapon[index] = true;
        
        SwitchToWeapon(index);
    }
}