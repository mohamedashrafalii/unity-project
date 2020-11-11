using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ground : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public tile tilePrefab;
   
    public int tilesToPreSpawn = 3; //How many tiles should be pre-spawned
   //How many tiles at the beginning should not have obstacles, good for warm-up

    List<tile> spawnedTiles = new List<tile>();
    int nextTileToActivate = -1;
    [HideInInspector]
   
   
    public static ground instance;

    public scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;

        Vector3 spawnPosition = startPoint.position;
       
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            tile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as tile;
            // if(tilesWithNoObstaclesTmp > 0)
            // {
            //     spawnedTile.DeactivateAllObstacles();
            //     tilesWithNoObstaclesTmp--;
            // }
            // else
            // {
                spawnedTile.ActivateRandomObstacle();
            // }
            
            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object upward in world space x unit/second.
        //Increase speed the higher score we get
        if (!scene.gameOver && scene.gameStarted&&!scene.pause)
        {
            int speedrate=(scene.score/50+1);
            speedrate=speedrate>=0?(scene.score/50+1):1;
            
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (scene.movingSpeed * speedrate), Space.World);
          //  score += Time.deltaTime * movingSpeed;
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
        {
            //Move the tile to the front if it's behind the Camera
            tile tileTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
            tileTmp.ActivateAllObstacles();
            tileTmp.ActivateRandomObstacle();
            // tileTmp.ActivateRandomObstacle();
            // tileTmp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTmp);
        }

        if(scene.health<0)
        scene.gameOver=true;
        // if (scene.gameOver || !scene.gameStarted)
        // {
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         if (scene.gameOver)
        //         {
        //             //Restart current scene
        //             Scene scene = SceneManager.GetActiveScene();
        //             SceneManager.LoadScene(scene.name);
        //         }
        //         else
        //         {
                    //Start the game
                    
           
               // }
            }
        }
    