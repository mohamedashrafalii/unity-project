using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public scene ground;
    float timeRemaining = 15;
    public static bool flipped = false;
    Color [] playerColor={new Color(0,0,255/255,255/255),new Color(0,0,0,255/255),new Color(33/255f,212/255f,31/255f,255/255),new Color(255/255,255/255,0,255/255)};
    void Start()
    {
         System.Random rnd = new System.Random();
                  int randColor  = rnd.Next(0,4); 
                gameObject.GetComponent<Renderer>().material.color = playerColor[randColor];
    }

    // Update is called once per frame
    void Update()
    {
                if(Input.GetKeyDown(KeyCode.R))
                { System.Random rnd = new System.Random();
                  int randColor  = rnd.Next(0,4); 
                gameObject.GetComponent<Renderer>().material.color = playerColor[randColor];}
        if(!ground.pause&&ground.gameStarted&&!ground.gameOver)
        {
          
         float h =Input.GetAxis("Horizontal");
         if(GameObject.Find("player").transform.position.x<5.2&&GameObject.Find("player").transform.position.x>-5.2)
         {transform.Translate(h*Time.deltaTime*8,0,0);
         transform.Rotate(0,h*Time.deltaTime*3,0);
         if(GameObject.Find("player").transform.position.x>5.1)
           { transform.Translate(-0.3f,0,0);
         }
         if(GameObject.Find("player").transform.position.x<-5.1)
          {  transform.Translate(0.3f,0,0);
         }
         }
        transform.Translate(Input.acceleration.x,0,0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
           if(GameObject.Find("player").transform.position.y>4)
            transform.Translate(0,-4.42f,0);
            else
            transform.Translate(0,4.42f,0);
          flipped=!flipped;
            GameObject.FindGameObjectsWithTag("changeMoodAud")[0].GetComponent<AudioSource>().Play();
           
          }
       
         if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                
                timeRemaining = 15;
                System.Random rnd = new System.Random();
                  int randColor  = rnd.Next(0,4); 
                gameObject.GetComponent<Renderer>().material.color = playerColor[randColor];
                 GameObject.FindGameObjectsWithTag("ballChange")[0].GetComponent<AudioSource>().Play();
           
               // Debug.Log(gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            }}
    }

   
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("obs"))
         {
             GameObject.FindGameObjectsWithTag("obsAud")[0].GetComponent<AudioSource>().Play();
            
            collider.gameObject.SetActive(false);
            ground.health--;
         }
          if(collider.gameObject.CompareTag("col"))
         {
           // Debug.Log(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            if(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color")==gameObject.GetComponent<Renderer>().material.GetColor("_Color")&&!flipped)
            { GameObject.FindGameObjectsWithTag("colAud")[0].GetComponent<AudioSource>().Play();
            ground.score+=10;
            }
             else if(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color")==gameObject.GetComponent<Renderer>().material.GetColor("_Color")&&flipped)
             {GameObject.FindGameObjectsWithTag("obsAud")[0].GetComponent<AudioSource>().Play();
             ground.score-=5;
             }
              else if(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color")!=gameObject.GetComponent<Renderer>().material.GetColor("_Color")&&flipped)
            { GameObject.FindGameObjectsWithTag("colAud")[0].GetComponent<AudioSource>().Play();
            ground.score+=10;
            }
             else if(collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color")!=gameObject.GetComponent<Renderer>().material.GetColor("_Color")&&!flipped)
             {GameObject.FindGameObjectsWithTag("obsAud")[0].GetComponent<AudioSource>().Play();
             ground.score-=5;
             }
             collider.gameObject.SetActive(false);
        
            
         }
         if(collider.gameObject.CompareTag("hp"))
         {
            GameObject.FindGameObjectsWithTag("hpAud")[0].GetComponent<AudioSource>().Play();
           
            collider.gameObject.SetActive(false);
            ground.health=ground.health>=3?3:ground.health+1;
         }
    }

    public void onClick2()
    {
       if(!ground.pause&&ground.gameStarted&&!ground.gameOver)
        {
       if(GameObject.Find("player").transform.position.y>4)
            transform.Translate(0,-4.42f,0);
            else
            transform.Translate(0,4.42f,0);
          flipped=!flipped;
            GameObject.FindGameObjectsWithTag("changeMoodAud")[0].GetComponent<AudioSource>().Play();
    }}
}
