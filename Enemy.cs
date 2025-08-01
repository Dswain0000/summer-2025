using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float health = 1f;
    public int pointsOnKill = 100;
    public float damage = 10f;
    public float attackRange = 2f;
    public float attackInterval = 1f;

    private NavMeshAgent nav;
    private float lastAttackTime = 0f;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null && nav.isActiveAndEnabled && nav.isOnNavMesh)
        {
            nav.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) <= attackRange &&
                Time.time - lastAttackTime >= attackInterval)
            {
                lastAttackTime = Time.time;
                // Deal attack damage to player here
            }
        }
    }

    public void TakeDamage(float amt)
    {
        health -= amt;
        if (health <= 0f) Die();
    }

    void Die()
    {
        ScoreManager.Instance.AddPoints(pointsOnKill);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>()?.GameOver();
        }
    }

    // Added method for instant kill and scoring
    public void OnHit()
    {
        ScoreManager.Instance.AddPoints(pointsOnKill);
        Destroy(gameObject);
    }
}
