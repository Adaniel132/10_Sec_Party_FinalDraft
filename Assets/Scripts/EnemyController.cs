using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    public Text GameOverText;

     public static int hpValue = 1;
    Text hp;


    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;

        hp = GetComponent<Text> ();
        GameOverText.text = "";

        
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;;
        }
        
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals ("Player"))
        {
           HpScript.hpValue -= 1; 

        }

         if (hpValue <= 0)
         {
             GameOverText.text = "You Lose! Game created by Azaan Daniel";
         }


    }
}