using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SphereCollider sphereCollider;
    [SerializeField] public int enemyHealth;
    [SerializeField] public int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        enemyHealth = 1;
        enemyDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDeath();
    }

    void EnemyDeath()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy Died!");
        }
    }
}
