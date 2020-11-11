using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenue : MonoBehaviour
{
    // Start is called before the first frame update
     GameObject[] pauseObjects;
     public scene scene;
    void Start()
    {
        
        GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Play();
        pauseObjects = GameObject.FindGameObjectsWithTag("mainMenue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       public void quit()
 {
     // save any game data here
     #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
 }
 public void LoadLevel(){
		Application.LoadLevel("SampleScene");
	}
    public void options(){
        Application.LoadLevel("options");
    }
}
