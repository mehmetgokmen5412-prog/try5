using UnityEngine;
using System.Collections;

public class SwordCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public Animator anim;

    private bool isAttacking = false;

    void Update()
    {
        // 1. FAREYE GÖRE DÖNME VE ATTACKPOINT HİZALAMA
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x)
        {
            // Fare sağda: Karakteri sağa bakacak şekilde ayarla
            transform.localScale = new Vector3(1, 1, 1);
            attackPoint.localPosition = new Vector3(Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, 0);
        }
        else
        {
            // Fare solda: Karakteri sola bakacak şekilde ayarla
            transform.localScale = new Vector3(-1, 1, 1);
            attackPoint.localPosition = new Vector3(-Mathf.Abs(attackPoint.localPosition.x), attackPoint.localPosition.y, 0);
        }

        // 2. SALDIRI
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        if (anim != null) anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Vuruldu: " + enemy.name);
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null) Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}