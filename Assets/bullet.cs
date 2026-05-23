using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector2 Vec;
    Rigidbody2D rb;
    public int MermiHiz = 20;
    public float lifetime = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 yon = (Vec - (Vector2)transform.position).normalized;

        if (rb != null)
        {
            rb.linearVelocity = yon * MermiHiz;
        }

        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth zombiCan = collision.gameObject.GetComponent<EnemyHealth>();

            if (zombiCan != null)
            {
                zombiCan.HasarAl(1);
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}