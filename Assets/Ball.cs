using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{

    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;

    int playerScore;
    int enemyScore;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Gates"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("Goal player"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }

        if (other.gameObject.name.Contains("Goal computer"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();
        }
    }
}
