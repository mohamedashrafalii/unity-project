using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    static bool cam=true;

    public int movingSpeed = 10;
    public int score = 0;
    public int health = 3;
    public bool gameOver = false;
    public bool gameStarted = false;
    public bool pause = false;
    public bool mute=false;
    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(cam);
        cam2.gameObject.SetActive(!cam);
         gameStarted = true;
                     GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Play();
                     GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.Q))
        {score+=10;}
        if(Input.GetKeyDown(KeyCode.E))
        {health=health>2?3:health+1;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
          cam=!cam;
           cam1.gameObject.SetActive(cam);
           cam2.gameObject.SetActive(!cam);

        }
        //  if(Input.GetKeyDown(KeyCode.Escape))
        // {
        // //   pause=!pause;
        // }
        if(Input.GetKeyDown(KeyCode.M))
       mute1();
       
    }
    public void mute1() {
         mute=!mute;
        if (mute)
             AudioListener.volume = 1f;
 
         else
             AudioListener.volume = 0f;
    }
     void OnGUI()
    {
       
            // if (!gameStarted)
            // {
            //     GUI.color = Color.red;
            //     GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Press 'S' to start");
            // }
      

        GUI.color = Color.white;
        GUI.Label(new Rect(5, 5, 200, 25), "score: " + ((int)score));
        GUI.color = Color.red;
        GUI.Label(new Rect(20, 20, 200,200), "health: " + health);
    }
    public void onClick2()
    {
        cam=!cam;
           cam1.gameObject.SetActive(cam);
           cam2.gameObject.SetActive(!cam);
    }
    
}
