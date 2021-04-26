using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pickup;
    public GameObject notpickup;
    public int pickupCount;

    //Three variables to control the range and pace of spawn
    public Vector3 spawnValue;
    public float startWait;
    public float spawnWait;

    //Two variables to control how long the cube exists
    public float pickupWait;
    public float notpickupWait;

    public Text TimeText;
    public Text EndText;
    private bool GameOver;
    public float time;
    
    void Start()
    {
        GameOver = false;
        EndText.gameObject.SetActive(false);
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.R))
            {
                Scene newLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(newLevel.name);
                Time.timeScale = 1;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            TimeText.text = "Time Remaining: " + Mathf.Ceil(time);
        }
        if(time <= 0)
        {
            EndText.text = "                     Time up!\nPress 'R' to restart or 'Esc' to exit";
            EndGame();
        }
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWait);
        while (! GameOver)
        {
            for(int i = 1; i <= pickupCount; i++)
            {
                if (GameOver)
                {
                    break;
                }

                //spawn GameObject NotPickUp when judg is less than or equal 2 (sur 8)
                int judg = Random.Range(1, 8);
                Vector3 spawnAt = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 
                                                                       spawnValue.y, 
                                                                       Random.Range(-spawnValue.z, spawnValue.z));
                if(judg <= 2)
                {
                    GameObject tmp = Instantiate(notpickup, spawnAt, Quaternion.identity);
                    Destroy(tmp, notpickupWait);
                }
                else
                {
                    GameObject tmp = Instantiate(pickup, spawnAt, Quaternion.identity);
                    Destroy(tmp, pickupWait);
                }
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    public void EndGame()
    {
        GameOver = true;
        EndText.gameObject.SetActive(true);
    }
}
