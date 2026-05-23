using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Hiz = 2f;
    public float DurmaMesafe = 1f;
    public Transform Hedef;
    private Animator anim;

   
    private float sonHasarZamani;
    public float hasarAraligi = 1f; 

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) Hedef = p.transform;
    }

    void Update()
    {
        if (Hedef == null) return;

        float mesafe = Vector2.Distance(transform.position, Hedef.position);

      
        if (mesafe > DurmaMesafe)
        {
            transform.position = Vector2.MoveTowards(transform.position, Hedef.position, Hiz * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);

           
            if (Time.time - sonHasarZamani > hasarAraligi)
            {
                PlayerHealth player = Hedef.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.OyuncuHasarAl(1);
                    sonHasarZamani = Time.time; 
                }
            }
        }

        
        Vector3 yeniScale = transform.localScale;
        if (Hedef.position.x > transform.position.x)
            yeniScale.x = -Mathf.Abs(yeniScale.x);
        else if (Hedef.position.x < transform.position.x)
            yeniScale.x = Mathf.Abs(yeniScale.x);

        transform.localScale = yeniScale;
    }
}