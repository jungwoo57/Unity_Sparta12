using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGameManager : MonoBehaviour
{
    public GameObject miniGame;
    public GameObject plane;
    public GameObject[] obstacles;
    public GameObject[] enviroments;
    public GameObject[] backGround;

    //public Vector3 originMiniGamePos;
    public Vector3[] originBackGroundPosition;
    public Vector3 originPlanePosition;
    public Vector3[] originObstaclePosition;
    public Vector3[] originEnviromentPosition;

    public bool isReady = false;
    private void Awake()
    {
        //originMiniGamePos = new Vector3(miniGame.transform.position.x, miniGame.transform.position.y, 0);
        originPlanePosition = new Vector3(plane.transform.position.x, plane.transform.position.y, 0);
        OriginPos();
        miniGame.SetActive(false);
    }
    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!isReady) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void Init()
    {
        for (int i = 0; i < originBackGroundPosition.Length; i++)
        {
            backGround[i].transform.position = new Vector3(originBackGroundPosition[i].x, originBackGroundPosition[i].y, 0);
        }
        for (int i = 0; i < originEnviromentPosition.Length; i++)
        {
            enviroments[i].transform.position = new Vector3(originEnviromentPosition[i].x, originEnviromentPosition[i].y, 0);
        }
        for (int i = 0; i < originObstaclePosition.Length; i++)
        {
            obstacles[i].transform.position = new Vector3(originObstaclePosition[i].x, originObstaclePosition[i].y, 0);
        }

        plane.transform.position = new Vector3(originPlanePosition.x, originPlanePosition.y, 0);

       // miniGame.transform.position = new Vector3(originMiniGamePos.x, originMiniGamePos.y, 0);
        
    }

    public void OriginPos()
    {
        
        for(int i = 0; i < backGround.Length; i++)
        {
            originBackGroundPosition[i] = new Vector3(backGround[i].transform.position.x, backGround[i].transform.position.y, 0);
        }
        for(int i = 0; i < obstacles.Length; i++)
        {
            originObstaclePosition[i] = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y, 0);
        }
        for(int i = 0; i < enviroments.Length; i++)
        {
            originEnviromentPosition[i] = new Vector3(enviroments[i].transform.position.x, enviroments[i].transform.position.y, 0);
        }
    }
}
