using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1)* Time.deltaTime * speed);
        if (this.transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
