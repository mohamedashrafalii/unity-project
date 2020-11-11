using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] overObjects;
    public scene scene;
	public playerMove playerMove;
	private bool  playOnce = false;
	// Use this for initialization
	void Start () {
		
		overObjects = GameObject.FindGameObjectsWithTag("over");
		hidePaused();
	}

    // Update is called once per frame
    void Update()
    {
        if(scene.gameOver && !playOnce)
       {
		  
		   GameObject.FindGameObjectsWithTag("gameAud")[0].GetComponent<AudioSource>().Stop();
		 	 			GameObject.FindGameObjectWithTag("menuAud").GetComponent<AudioSource>().Play();
									   showPaused();
									   playOnce= true;
	   }
    }
    public void showPaused(){
		foreach(GameObject g in overObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in overObjects){
			g.SetActive(false);
		}
	}
	 public void LoadLevel(){
		 playerMove.flipped=false;
		Application.LoadLevel("startMenue");
	}

}
