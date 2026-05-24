using UnityEngine;
using System.Collections;

public class SwordCombat : MonoBehaviour
{
    [Header("Saldırı Ayarları")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackCooldown = 1.5f;

    [Header("Animasyon Ayarları")]
    public Animator anim;

    private bool isAttacking = false;

    void Update()
    {
        // Karakterin yönünü al (Scale X değeri 1 ise sağ, -1 ise sol)
        float horizontal = transform.localScale.x;

        // AttackPoint'in Y ve Z'sini sabit tut, X'i yönle çarp
        // 0.5f değerini kılıcın uzaklığına göre 0.7f veya 0.8f yapabilirsin
        attackPoint.localPosition = new Vector3(0.5f * (horizontal > 0 ? 1 : -1), 0, 0);

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
            Debug.Log("Vurulan: " + enemy.name);
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}