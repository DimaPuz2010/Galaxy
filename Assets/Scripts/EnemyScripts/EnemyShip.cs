using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float heal = 100;
    public delegate void OnDeath(EnemyShip deathShip);
    public event OnDeath DeathEvent;
    public GameObject EnemyBullet;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject ;
        PlayerBullet bulletObject = otherObject.GetComponent<PlayerBullet>();
        if(bulletObject != null)
        {
            heal -= bulletObject.damage;
            Destroy(otherObject);
            if(heal <= 0)
            {
                DeathEvent.Invoke(this);
                Destroy(gameObject);
            }
        }
    }

    public void Shoot()
    {
        GameObject newEnemyBullet = Instantiate(EnemyBullet);
        newEnemyBullet.transform.position = transform.position;
    }
}
