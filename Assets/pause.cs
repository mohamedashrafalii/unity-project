using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] pauseObjects;
    public scene scene;
    public playerMove playerMove;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("pause");
		hidePaused();
		 GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Play();
							GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Stop();
	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(!scene.gameOver){
		if(Input.GetKeyDown(KeyCode.Escape))
		{
            scene.pause=true;

			// if(scene.pause)
			// {
				
				showPaused();
				 GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Stop();
							GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Play();
			// } else {
			// 	hidePaused();
			// }
		}}
	}
public void onClick3()
    {
		if(!scene.gameOver)
       { scene.pause=true;

			// if(scene.pause)
			// {
				
				showPaused();
				            GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Stop();
							GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Play();

			// } else {
			// 	hidePaused();
			// }}
    }
	}
	//Reloads the Level
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
        playerMove.flipped=false;
		 GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Play();
							GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Stop();
	}

	//controls the pausing of the scene
	public void pauseControl(){
			 scene.pause=true;

			// if(scene.pause)
			// {
				
				showPaused();
			// } else {
			// 	hidePaused();
			// }
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
    public void resume()
    {
         scene.pause=false;

			// if(scene.pause)
			// {
				
			// 	showPaused();
			// } else {
				hidePaused();
				 GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Play();
							GameObject.FindGameObjectsWithTag("menuAud")[0].GetComponent<AudioSource>().Stop();
			//}
    }
	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
}
