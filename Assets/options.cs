using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] optionObjects;
    public scene scene;
    public bool mute=false;
    void Start()
    {
       // if(!scene.mute)
        GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Play();
        optionObjects = GameObject.FindGameObjectsWithTag("options");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(){
		Application.LoadLevel("startMenue");
	}
    public void mute1(){
	  mute=!mute;
        if (mute)
             AudioListener.volume = 1f;
 
         else
             AudioListener.volume = 0f;
	}
}
