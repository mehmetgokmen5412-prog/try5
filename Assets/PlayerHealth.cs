using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int can = 5;

    public void OyuncuHasarAl(int miktar)
    {
        can -= miktar;
        Debug.Log("Oyuncunun canı: " + can);

        if (can <= 0)
        {
           
            OyuncuOldu();
        }
    }

    void OyuncuOldu()
    {
        Debug.Log("Oyun Bitti! Oyuncu öldü.");
        print("öldün");
Destroy (gameObject);
    }
}