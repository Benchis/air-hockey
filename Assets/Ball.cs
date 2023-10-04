using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{

    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    public AudioClip pipe;
    public AudioClip perfect;

    int playerScore;
    int enemyScore;

    public float maxSpeed = 50;

    private void Update()
    {
        var currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        print(currentSpeed);
        if (currentSpeed > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(pipe);
        GetComponent<AudioSource>().volume = 0.2f;


        if (other.gameObject.name.Contains("Goal computer"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();

            transform.position = Vector3.right;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<AudioSource>().PlayOneShot(perfect);
            GetComponent<AudioSource>().volume = 1;
        }

        if (other.gameObject.name.Contains("Goal player"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();

            transform.position = Vector3.left;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<AudioSource>().PlayOneShot(perfect);
            GetComponent<AudioSource>().volume = 1;

        }
    }
}
