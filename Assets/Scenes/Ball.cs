using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{

    public TMP_Text scorePlayer;
    public TMP_Text scoreEnemy;
    int scoreP = 0;
    int scoreE = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer.text = scoreP.ToString();
        scoreEnemy.text = scoreE.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("Goal player"))
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            scoreP++;
        }

        if (collision.gameObject.name.Contains("Goal computer"))
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            scoreE++;
        }
    }
}
