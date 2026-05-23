using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public int can = 10;
    public Animator anim; // Inspector'dan el ile sürükleyip bırakacağın yer
    private List<SpriteRenderer> spriteList = new List<SpriteRenderer>();
    private bool isAttacking = false;

    void Start()
    {
        spriteList.AddRange(GetComponentsInChildren<SpriteRenderer>());
    }

    public void HasarAl(int miktar)
    {
        can -= miktar;
        if (can <= 0)
        {
            if (anim != null) anim.Play("Die");
            StartCoroutine(OlmeSuresi());
        }
        else
        {
            if (anim != null) anim.Play("Hurt");
            StartCoroutine(KirmiziYap());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isAttacking)
        {
            StartCoroutine(Saldir(collision));
        }
    }

    IEnumerator Saldir(Collision2D collision)
    {
        isAttacking = true;

        if (anim != null)
        {
            anim.Play("Attack");
        }
        else
        {
            Debug.LogError("ANIMATOR EKSİK: Zombi Inspector'ındaki 'Anim' kutusuna Animator'ı sürükle!");
        }

        yield return new WaitForSeconds(0.5f);

        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.OyuncuHasarAl(1);
        }

        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

    IEnumerator OlmeSuresi()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    IEnumerator KirmiziYap()
    {
        foreach (SpriteRenderer sr in spriteList) if (sr != null) sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        foreach (SpriteRenderer sr in spriteList) if (sr != null) sr.color = Color.white;
    }
}