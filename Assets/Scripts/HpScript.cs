using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    public Text GameOverText;

    public bool gameOver = false;
    
    public static int hpValue = 1;
    Text hp;
    // Start is called before the first frame update
    void Start()
    {
       hp = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
          hp.text = "Hp: " + hpValue;

          if (hpValue <= 0)
         {
             GameOverText.text = "You Lose! Game created by Azaan Daniel";
           
         }
         
          
          
    }
    }

