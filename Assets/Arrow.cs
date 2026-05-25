using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer çarptığımız şey oyuncuysa hasar ver
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject); // Ok oyuncuya değince yok olur
        }
        // Eğer çarptığımız şey "Ground" ise veya başka bir engel
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Yere değince yok olur
        }
    }
}