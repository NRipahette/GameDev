using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private EnemyController[] EnemyList;
    private List<EnemyController> Deads = new List<EnemyController>();
    private int dead = 0;
    private GameObject GameOver;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        EnemyList = GetComponentsInChildren<EnemyController>();
        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);
        currentState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case "Playing":
                if (Time.timeScale != 1)
                    Time.timeScale = 1;
                for (int i = 0; i < EnemyList.Length; i++)
                {
                    if (EnemyList[i].CheckIsAlive() == false)
                    {

                        Debug.Log("ded");
                        dead++;
                    }
                }
                if (EnemyList.Length == dead)
                {
                    currentState = "GameOver";
                    Debug.Log("GameOver");

                }else
                {
                    dead = 0;
                }
                    if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentState = "Pause";
                }
                

                break;
            case "Pause":
                if(Time.timeScale!= 0)
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentState = "Playing";
                }
                break;
            case "GameOver":
                GameOverScreen();
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(0);
                }
                break;

            default:
                currentState = "Playing";
                break;
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    currentState = "Pause";
        //}
    }


    private void GameOverScreen()
    {
        if(GameOver.activeInHierarchy == false)
        {
        Time.timeScale = 0.1f;
        GameOver.SetActive(true);
        }
    }
}
