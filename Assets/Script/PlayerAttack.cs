using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public int damage = 25; 
    public float range = 100f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Touch� : " + hit.transform.name); 

            MonsterHealth monster = hit.transform.GetComponent<MonsterHealth>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }
        }
    }
}