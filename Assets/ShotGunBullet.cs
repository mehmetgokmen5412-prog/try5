using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    public float hız = 25f;
    public int hasar = 5; // Shotgun mermisi az hasar verir ama 6 tane gider

    void Update()
    {
        transform.Translate(Vector3.forward * hız * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Sadece Enemy'ye çarpınca hasar ver
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().HasarAl(hasar);
           
        }
        // Duvara çarpınca yok olsun
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        Destroy(gameObject, 1f);
    }
}