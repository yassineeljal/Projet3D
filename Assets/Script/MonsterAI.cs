using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Header("R�glages")]
    public Transform player;
    public float chaseDistance = 15f;
    public float attackRange = 2.0f;
    public float attackCooldown = 2f;
    public int damageAmount = 20;

    private NavMeshAgent agent;
    private Animator anim;
    private float nextAttackTime = 0f;
    private PlayerHealth playerHealth; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseDistance && distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
        }

        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        if (distance <= attackRange)
        {
            FaceTarget();

            if (Time.time >= nextAttackTime)
            {
                anim.SetTrigger("Attack");

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}