using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Enemy enemy;
    CapsuleCollider capsuleCollider;
    [SerializeField] int playerDamage;
    [SerializeField] int playerHealth;
    [SerializeField] bool isEnemyInRange;

    // Start is called before the first frame update

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerDamage = 1;
        isEnemyInRange = false;
        playerHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        BasicAttack();
        PlayerDeath();
    }

    void BasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed LMB");
            if (isEnemyInRange)
            {
                enemy.enemyHealth -= playerDamage;
                Debug.Log("Enemy got hit!");
            }
        }
    }

    void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Player has Died!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
            Debug.Log("Enemy in range");
            isEnemyInRange = true;
            /*TEST FOR PLAYER DEATH BELOW*/
            Debug.Log("Here");
            //playerHealth -= enemy.enemyDamage;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        isEnemyInRange = false;
        Debug.Log("Enemy out of range");
    }

   
}
