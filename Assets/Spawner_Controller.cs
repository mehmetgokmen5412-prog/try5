using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ZombieBoyPrefab;
    public Transform spawnPoint;

    // Minimum ve maksimum süreleri Inspector'dan seçebileceksin
    public float minSure = 1.0f;
    public float maxSure = 4.0f;

    void Start()
    {
        // İlk doğumu başlat
        DöngüyüBaslat();
    }

    void DöngüyüBaslat()
    {
        // Rastgele bir süre belirle
        float rastgeleSure = Random.Range(minSure, maxSure);

        // Bu süreyi bekle ve doğur
        Invoke("ZombiDogur", rastgeleSure);
    }

    void ZombiDogur()
    {
        if (spawnPoint != null)
        {
            Instantiate(ZombieBoyPrefab, spawnPoint.position, Quaternion.identity);
        }

        // Doğumdan sonra tekrar rastgele bir süre belirle ve kendini çağır
        DöngüyüBaslat();
    }
}