using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpG : MonoBehaviour
{
    public GameObject Ball;
    public Paddle p;
    public int BallSpeed = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
         
            float angleIncrement = 15f;
            SpawnBallAtAngle(p.transform.position, angleIncrement * -1);
            SpawnBallAtAngle(p.transform.position, 0); 
            SpawnBallAtAngle(p.transform.position, angleIncrement);
        }
    }

    private void SpawnBallAtAngle(Vector2 spawnPosition, float angle)
    {
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;
        GameObject ball = Instantiate(Ball, spawnPosition, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = direction * BallSpeed;
    }
}