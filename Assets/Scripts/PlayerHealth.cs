using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    public int health {  get { return currentHealth; }}
    int currentHealth;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;


    public ExterminatorController playerController;

    public Animator anim, GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
         if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth <=0)
        {
            return;
        }

        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        Debug.Log(currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Dead");
            GameOverMenu.SetTrigger("Game Over");
            playerController.ded = true;
            GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
            Timer timeWriter = timerObject.GetComponent<Timer>();

            timeWriter.WriteTime();
        }
    }


}
