using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* To handle collisions we can either use OnCollisionEnter2D or OnTriggerEnter2D (2D needs to be used if
     * the colliders are 2D). OnTriggerEnter2D needs to be used if at least one of the colliders is a 
     * trigger collider (has is trigger ticked).
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We are retrieving the damage dealer of the current laser which hit the enemy since different
        //lasers CAN have different damage values
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage(); // health = health - damagedDealer.GetDamage();
        // A -= B; => A = A - B;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
