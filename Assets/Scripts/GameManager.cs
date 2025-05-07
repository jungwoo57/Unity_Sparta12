using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }
    public GameObject camera;
    public GameObject plane;
    public GameObject player;
    public GameObject miniGame;
    public GameObject npc;

    public int score = 0;
    public int maxScore = 0;

    public MiniGameManager miniGameManager;
    public GameObject miniGameUI;

    private const string MaxScoreKey = "MaxScore";
    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        maxScore = PlayerPrefs.GetInt(MaxScoreKey, 0);
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
    public void MiniGameStart()
    {
        score = 0;
        miniGame.GetComponent<MiniGameManager>().Init();
        player.gameObject.GetComponent<Player>().isMainGame = false;
        npc.gameObject.GetComponent<Npc>().selectUI.SetActive(false);
        miniGame.SetActive(true);
        camera.transform.position = new Vector3 (plane.transform.position.x, plane.transform.position.y, -10);
        camera.gameObject.GetComponent<Camera>().target = plane;
        plane.gameObject.GetComponent<Plane>().isDead = false;
        StartCoroutine("WaitSeconds");
        miniGameManager.isReady = true;
    }

    public void MiniGameOver() 
    {
        if(maxScore < score)
        {
            maxScore = score;
        }
        miniGameUI.SetActive(true);
    }
    
    void MiniGameInit()
    {
        miniGameManager.GetComponent<MiniGameManager>().Init();
        player.gameObject.GetComponent<Player>().isMainGame = false;
        npc.gameObject.GetComponent<Npc>().selectUI.SetActive(false);
        miniGame.SetActive(true);
        camera.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y, -10);
        camera.gameObject.GetComponent<Camera>().target = plane;
        plane.gameObject.GetComponent<Plane>().isDead = false;
    }

    public void ReturnMain()
    {
        miniGame.SetActive(false);
        miniGameManager.isReady = false;
        player.gameObject.GetComponent<Player>().isMainGame = true;
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        camera.gameObject.GetComponent<Camera>().target = player;
        miniGameUI.SetActive(false);

    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
