using UnityEngine;

public class ResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }
}

