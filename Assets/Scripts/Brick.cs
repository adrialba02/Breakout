using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health;
    public int points;
    public bool unbreakable;

    public Transform powerUpR;
    public Transform powerUpG;
    public Transform powerUpB;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        this.gameObject.SetActive(true);
    }

    
    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }

        this.health--;

        if (this.health <= 0)
        {
            int randChance = Random.Range(1, 101);
            if (randChance < 10)
            {
                if(randChance == 1 || randChance == 2 || randChance == 3)
                    Instantiate(powerUpG, gameObject.transform.position, gameObject.transform.rotation);
                else if(randChance == 4 || randChance == 5 || randChance == 6)
                    Instantiate(powerUpB, gameObject.transform.position, gameObject.transform.rotation);
                else if(randChance == 7 || randChance == 8 || randChance == 9 || randChance == 10)
                    Instantiate(powerUpR, gameObject.transform.position, gameObject.transform.rotation);
            }

            this.gameObject.SetActive(false);
        }

        FindObjectOfType<GameManager>().Hit(this);
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hit();
        }
    }

}