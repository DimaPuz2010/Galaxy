using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public Direction direction;
    public SpriteRenderer shiprendered;
    private float speed = 0.2f;
    private float halfwidth;
    private float halfheight;
    void Start()
    {
        halfheight = shiprendered.sprite.bounds.size.x / 2;
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
            }else
            {
                direction = Direction.up;
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
            }else
            {
                direction = Direction.up;
            }
        }
    }
    private void MovingUp()
    {
        Vector3 newPosition = transform.position;
        newPosition.y += speed;
        if (Helpers.IsPositionOnScreen(newPosition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.x > 0)
            {
                direction = Direction.left;
            }else
            {
                direction = Direction.right;
            }
        }
    }
    private void MovingDown()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed;
        if (Helpers.IsPositionOnScreen(newPosition) == true)
        {
            transform.position = newPosition;
        }else
        {
            if(transform.position.x > 0)
            {
                direction = Direction.left;
            }else
            {
                direction = Direction.right;
            }
        }
    }
}
