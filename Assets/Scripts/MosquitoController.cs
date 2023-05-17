using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoController : MonoBehaviour
{
    Transform target; //drag and stop player object in the inspector
    public float backSpeed;
    public float moveSpeed = 5f;
    public float waitTime = 5f;

    public bool ded = false;

    bool canAttack = true;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ded)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        if (canAttack)
        {
            moveCharacter(movement * moveSpeed);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        if (ded)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (ded)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        PlayerHealth controller = other.GetComponent<PlayerHealth >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            StartCoroutine (attackWait ());
        }
    }

    IEnumerator attackWait()
    {
        canAttack = false;
        float accumulatedTime = 0;
        while (accumulatedTime < waitTime)
        {
            yield return null;
            accumulatedTime += Time.deltaTime;
            moveCharacter(-movement * backSpeed);
        }
        //yield return new WaitForSeconds (waitTime);
        canAttack = true;
    }
    
}
