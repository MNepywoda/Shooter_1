using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 3f);

        if (transform.position.y < -8.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            //I hit the player!
            GameObject.Find("GameManager").GetComponent<GameManager>().LoseALife(whatIHit);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Weapon")
        {
            //I got shot!
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
