using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject arrowPrefab;  // Prefabs klasöründeki Arrow'u sürükle
    public Transform firePoint;     // Düşmanın elindeki FirePoint objesini sürükle
    public Transform targetPlayer;  // Sahnendeki Player objesini sürükle

    public float fireRate = 2f;     // Kaç saniyede bir atacak?
    private float nextFireTime;

    void Update()
    {
        if (targetPlayer == null) return;

        // Okçunun sana bakması için:
        Vector2 direction = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Ateş etme zamanı geldiyse:
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Zamanlayıcıyı sıfırla
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        // Okun hızını ver (RigidBody2D'nin linearVelocity değerini kullanıyoruz)
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * 15f;
    }
}