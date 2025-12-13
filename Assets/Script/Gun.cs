using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [Header("Stats")]
    public float damage = 10f;
    public float range = 100f;
    
    public float timeBetweenShots = 0.1f; 
    
    public bool allowButtonHold; 
    
    [Header("References")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public void AttemptShoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + timeBetweenShots;
            Shoot();
        }
    }

   void Shoot()
    {
        if (muzzleFlash != null) 
        {
            muzzleFlash.gameObject.SetActive(false);
            
            muzzleFlash.gameObject.SetActive(true);
            
            muzzleFlash.Play();
        }

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            MonsterHealth monster = hit.transform.GetComponent<MonsterHealth>();
            if (monster != null) monster.TakeDamage((int)damage);
             
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) target.TakeDamage(damage);

            if (impactEffect != null)
            {
                 GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                 Destroy(impactGO, 2f);
            }
        }
    }
}