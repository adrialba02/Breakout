using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpR : MonoBehaviour
{
    public GameObject Ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject bola = Instantiate(Ball);
        }
    }
}
