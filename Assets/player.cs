using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private float moveSpeed = 8f;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            Vector2 Vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           
            Transform firePoint = this.gameObject.transform.Find("FirePoint");

            if (firePoint != null && bullet != null)
            {
               
                GameObject EdilenMermi = Instantiate(bullet, firePoint.position, firePoint.rotation);

               
                EdilenMermi.GetComponent<bullet>().Vec = Vec;
            }
            else
            {
                Debug.LogError("FirePoint objesi veya bullet prefab'i eksik!");
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}