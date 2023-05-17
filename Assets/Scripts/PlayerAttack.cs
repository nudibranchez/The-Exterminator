
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public float attackWait;
    private bool canAttack = true;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canAttack)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Attack();
                animator.SetTrigger("Attack");
                StartCoroutine (WaitTime ());
            }

        }
    }

    IEnumerator WaitTime()
    {
        canAttack = false;
        yield return new WaitForSeconds (attackWait);
        canAttack = true;
    }

    public void Attack()
    {

        Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies );

        for (int i = 0; i < damage.Length; i++)
        {
            EnemyHealth enemyhealth = damage[i].gameObject.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                enemyhealth.ChangeHealth(-1);
            }
            //Destroy( damage[i].gameObject );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}