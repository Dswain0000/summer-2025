using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float maxDistance = 1000f;
    public GameObject decalHitWall;
    public float floatInfrontOfWall;
    public GameObject bloodEffect;
    public LayerMask ignoreLayer;

    private RaycastHit hit;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
        {
            // Hit a wall
            if (hit.transform.CompareTag("LevelPart") && decalHitWall != null)
            {
                Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
                Destroy(gameObject);
                return;
            }

            // Hit a dummy/enemy
            if (hit.transform.CompareTag("Dummie"))
            {
                if (bloodEffect != null)
                {
                    Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }

                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(100f); // Apply damage, let the enemy handle dying and scoring
                }

                Destroy(gameObject);
                return;
            }

            // Hit something else
            Destroy(gameObject);
        }

        // Destroy after short time if no hit
        Destroy(gameObject, 0.1f);
    }
}
