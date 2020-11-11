﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject[] obstacles; //Objects that contains different obstacle types which will be randomly activated

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles();

        System.Random random = new System.Random();
        int randomNumber = random.Next(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
        obstacles[randomNumber].SetActive(true);
        obstacles[randomNumber].SetActive(true);
        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }
     public void ActivateAllObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(true);
        }
    }
}