using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject cloud;

    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy1", 10f, 5f);
        CreateSky();
        
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 9f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateEnemy1()
    {
        Instantiate(enemy1, new Vector3(Random.Range(-9f, 9f), 9f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {   
        for(int i = 0; i < 20; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }    
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }
}
