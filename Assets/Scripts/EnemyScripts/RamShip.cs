using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public Direction direction;
    public SpriteRenderer shiprendered;
    private float speed = 0.2f;
    private float heal = 50;
    private float halfwidth;
    private float halfheight;
    void Start()
    {
        halfwidth = shiprendered.sprite.bounds.size.x / 2;
        halfheight = shiprendered.sprite.bounds.size.y / 2;
    }

    public void FixedUpdate()
    {
        switch(direction)
        {
            case Direction.left:
                MovingLeft();
            break;
            case Direction.right:
                MovingRight();
            break;
            case Direction.up:
                MovingUp();
            break;
            case Direction.down:
                MovingDown();
            break;
        }
    }

    private void MovingLeft()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= speed;
        Vector3 checkposition = newPosition;
        checkposition.x -= halfwidth;
        if (Helpers.IsPositionOnScreen(checkposition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.y > 0)
            {
                direction = Direction.down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }else
            {
                direction = Direction.up;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    private void MovingRight()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += speed;
        Vector3 checkposition = newPosition;
        checkposition.x += halfwidth;
        if (Helpers.IsPositionOnScreen(checkposition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.y > 0)
            {
                direction = Direction.down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }else
            {
                direction = Direction.up;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    private void MovingUp()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += speed;
        Vector3 checkposition = newPosition;
        checkposition.y += halfheight;
        if (Helpers.IsPositionOnScreen(checkposition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.x > 0)
            {
                direction = Direction.left;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }else
            {
                direction = Direction.right;
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
    }
    private void MovingDown()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed;
        Vector3 checkposition = newPosition;
        checkposition.y -= halfheight;
        if (Helpers.IsPositionOnScreen(checkposition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.x > 0)
            {
                direction = Direction.left;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }else
            {
                direction = Direction.right;
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
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
                Destroy(gameObject);
            }
        }
    }
}
