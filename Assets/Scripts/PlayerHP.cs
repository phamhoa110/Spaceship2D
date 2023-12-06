using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public void TakeDmg(int Damage)
    {
        currentHealth -= Damage;
        healthBar.ChangeHP(currentHealth, playerHealth);
    }

    public void BonusHP()
    {
        currentHealth = playerHealth;
        healthBar.ChangeHP(currentHealth, playerHealth);
    }


    private void Start()
    {
        currentHealth = playerHealth;
        healthBar.ChangeHP(currentHealth, playerHealth);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("HPBonus"))
    //    {
    //        BonusHP();
    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDmg(5);
        }

        //if (collision.gameObject.CompareTag("Boss_Bullet"))
        //{
        //    Destroy(collision.gameObject);
        //    TakeDmg(10);
        //}
    }
}
