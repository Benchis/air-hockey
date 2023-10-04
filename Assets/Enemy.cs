using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform ball;
    public Transform defensePoint;

    public float attackSpeed = 10;
    public float defenseSpeed = 5;

    public float moveInterval = 2;
    float moveCooldown = 2;
    private Vector3 defensePointOffset;

    private void Update()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0)
        {
            moveCooldown = moveInterval;
            defensePointOffset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-1, 1));
        }


        bool ballInRange = ball.position.x > 0;

        Vector3 targetPosition;
        float speed;

        if (ballInRange)
        {
            targetPosition = ball.position;
            speed = attackSpeed;
        }
        else
        {
            targetPosition = defensePoint.position + defensePointOffset;
            speed = defenseSpeed;
        }

        var finalPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }
}
