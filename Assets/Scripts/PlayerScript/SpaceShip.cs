using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    private float speed = 0.2f;
    private float heal = 100;
    public GameObject playerBullet;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        
    }

    void Update()
    {
        float halfWidth = spriteRenderer.bounds.size.x / 2;

        bool keyDownMovePlayer = Input.GetKey(KeyCode.LeftArrow);//||Input.GetKey(KeyCode.A);
        if(keyDownMovePlayer == true)
        {
            Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
            Vector3 checjPositio = new Vector3(
                newPosition.x - halfWidth,
                newPosition.y,
                0            
            );
            if(Helpers.IsPositionOnScreen(checjPositio))
            {
                transform.position = newPosition;
            }
        }

        keyDownMovePlayer = Input.GetKey(KeyCode.RightArrow);//||Input.GetKey(KeyCode.D);
        if(keyDownMovePlayer == true)
        {
            Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
            Vector3 checjPositio = new Vector3(
                newPosition.x + halfWidth,
                newPosition.y,
                0            
            );
            if(Helpers.IsPositionOnScreen(checjPositio))
            {
                transform.position = newPosition;
            }
        }

        keyDownMovePlayer = Input.GetKeyDown(KeyCode.Space);
        if(keyDownMovePlayer == true)
        {
            GameObject newBullet = Instantiate(playerBullet);
            newBullet.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject;
        EnemyBullet bullet = otherObject.GetComponent<EnemyBullet>();
        if(bullet != null)
        {
            heal -= bullet.damage;
            Destroy(otherObject);
            if(heal <= 0)
            {
                SceneManager.LoadScene(SceneIDS.loseSceneID);
                Destroy(gameObject);
            }
        }
    }
    
}
