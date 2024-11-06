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

    public GameObject coin;

    private int score;
    public TextMeshProUGUI scoreText;

    private int lives;
    public TextMeshProUGUI livesText;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy1", 10f, 5f);
        InvokeRepeating("CreateCoin", 20f, Random.Range(10f, 15f));
        CreateSky();
        
        score = 0;
        scoreText.text = "Score: " + score;

        lives = 3;
        livesText.text = "Lives: " + lives;
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

    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 0f), 0), Quaternion.identity);
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

    public void LoseALife(Collider2D whatIHit)
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if(lives == 0)
        {   
            Instantiate(explosion, whatIHit.transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
        }
    }
}
