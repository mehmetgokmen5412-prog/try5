using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ZombieBoyPrefab;
    public Transform spawnPoint;


    public float minSure = 1.0f;
    public float maxSure = 4.0f;

    void Start()
    {
       
        DöngüyüBaslat();
    }

    void DöngüyüBaslat()
    {
        
        float rastgeleSure = Random.Range(minSure, maxSure);

        
        Invoke("ZombiDogur", rastgeleSure);
    }

    void ZombiDogur()
    {
        if (spawnPoint != null)
        {
            Instantiate(ZombieBoyPrefab, spawnPoint.position, Quaternion.identity);
        }

      
        DöngüyüBaslat();
    }
}
