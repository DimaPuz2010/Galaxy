using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGroup : MonoBehaviour
{
    public bool isAlive = true;
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private float speed = 0.02f;
    private int derection = -1;

    private System.Random gener = new System.Random();

    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        
        ship1.DeathEvent += OnDeathShip;
        ship2.DeathEvent += OnDeathShip;
        ship3.DeathEvent += OnDeathShip;

        InvokeRepeating("ShootGroup", 0.0f, 0.5f);
    }

    void Update()
    {
        ships.RemoveAll(item => item == null);
        if(ships.Count == 0)
        {
            CancelInvoke("ShootGroup");
            isAlive = false;
            return;
        }

        if(derection == -1)
        {
            Vector3 leftPosition = ships[0].transform.position;
            leftPosition.x -= speed;

            bool onScreen = Helpers.IsPositionOnScreen(leftPosition);
            if(onScreen)
            {
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            }else
            {
                derection *= -1;
            }
        }else if(derection == 1)
        {
            Vector3 rightPosition = ships[ships.Count - 1].transform.position;
            rightPosition.x += speed;

            bool onScreen = Helpers.IsPositionOnScreen(rightPosition);
            if(onScreen)
            {
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            }else
            {
                derection *= -1;
            }
        }
    
        
        
    }

    void OnDeathShip(EnemyShip deathShip)
    {
        //ships.Remove(deathShip);
    }

    void ShootGroup()
    {
        int randomIndex = gener.Next(0, ships.Count);
        ships[randomIndex].Shoot();
    }
}
