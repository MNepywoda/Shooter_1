using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            //The player picked up a coin!
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            Destroy(this.gameObject);
        }
    }
}
