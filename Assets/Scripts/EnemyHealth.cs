using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public bool dead = false;
    public Animator anim;

    public MosquitoController enemyController;

    public void ChangeHealth(float damage)
    {
        if (health <= 0)
        {
            return;
        }
        Debug.Log(damage);
        health += damage;
        health = Mathf.Max(health, 0);

        if (health <= 0)
        {
            anim.SetTrigger("Dead");
            enemyController.ded = true;
            StartCoroutine(AwaitDemise());
            GameObject KillNum = GameObject.FindGameObjectWithTag("Kills");
            EnemyDeathCounter DeathCount = KillNum.GetComponent<EnemyDeathCounter>();
            DeathCount.AddToTotal();
        }
    }

    IEnumerator AwaitDemise()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
