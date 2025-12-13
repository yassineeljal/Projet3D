using UnityEngine;
using UnityEngine.AI;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; 

        currentHealth -= damage;
        anim.SetTrigger("GetHit"); 

        Debug.Log("Le monstre a mal ! PV restants : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        QuestZombieCounter.Instance.ZombieKilled();

        anim.SetTrigger("Die");

        

        GetComponent<MonsterAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Collider>().enabled = false;

        Destroy(gameObject, 5f);
    }
}