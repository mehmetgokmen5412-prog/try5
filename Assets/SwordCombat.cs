using UnityEngine;

public class SwordCombat : MonoBehaviour
{
    public Transform attackPoint; // Kılıcın sallandığı nokta (boş bir GameObject oluşturup karakterin eline koy)
    public float attackRange = 0.5f; // Kılıcın erişim mesafesi
    public LayerMask enemyLayers; // Düşmanların olduğu Layer (Inspector'dan "Enemy" katmanını seç)

    void Update()
    {
        // F tuşuna basınca saldır
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 1. Animasyonu oynat (Animator kullanıyorsan)
        // GetComponent<Animator>().SetTrigger("Attack");

        // 2. Saldırı noktasında çember oluştur ve içine giren düşmanları bul
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // 3. Yakalanan düşmanlara hasar ver
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " hasar aldı!");
            // enemy.GetComponent<EnemyHealth>().TakeDamage(10); // Düşman scriptindeki hasar alma fonksiyonunu çağır
        }
    }

    // Sahne görünümünde saldırı alanını görmek için
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}