using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NinjaController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvicible = 2.0f;

    int currentHealth;
    public Text staticText;

    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    public AudioSource musicSource;
    public AudioClip musicClipOne;

    public bool gameOver = false;

    bool isInvincible;
    float invincibleTimer;

    public int kunais;
    public Text kunaisText;
    public int currentKunais = 0;

    public Text GameOverText;

    public Text countText; 

   
    private HpScript HpScript;
    

    public Text scoreText;
    public int score;
    public int currentScore;

    Rigidbody2D rigidbody2d;
    public int count ;
    public float horizontal;
    public float vertical;

    private Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        score = 0; 
        
        GameOverText.text = "";
        currentKunais = 0;
        kunaisText.text = currentKunais.ToString();
        staticText.text = "";
        count = 0;
       audioSource= GetComponent<AudioSource>();
        musicSource.clip = musicClipOne;
          musicSource.Play();
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
         horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);

        

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;

                
        }

        

        

        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        if (horizontal > 0.1f)
        {

        }

        rigidbody2d.MovePosition(position);

        if (Input.GetKey("escape"))
    {
        Application.Quit();
    }
    }
        

        void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Pickup"))
        {
            currentKunais += 1;
            kunaisText.text = currentKunais.ToString();
            other.gameObject.SetActive (false);
            Destroy(other.gameObject);

            if (currentKunais >= 1)
        {
            GameOverText.text = "You Win! Game created by Azaan Daniel";
            speed = 0f;
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            
            
        }
            HpScript hpScript= HpScript.GetComponent<HpScript>();
            
            if (HpScript.hpValue <= 0)
           {
               GameOverText.text = "You Lose! Game created by Azaan Daniel";
            speed = 0f;
           }
        
            }
        }

       


    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvicible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

     
    
    }

    


