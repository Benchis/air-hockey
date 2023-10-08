using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;
    public TMP_Text goal;

    int playerScore;
    int enemyScore;

    public float maxSpeed = 50;

    public AudioClip goalSound;
    public AudioClip hitSound;
    AudioSource source;

    public bool shouldReset;
    public float resetTimer;

    public Transform deathPoint;
    Vector3 respawnPoint;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        var distanceToCenter = Vector3.Distance(Vector3.zero, transform.position);
        if (distanceToCenter > 10)
        {
            transform.position = Vector3.zero;
        }


        // reset ball after 2 seconds of goal
        if (shouldReset)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer > 2f)
            {
                goal.GetComponent<MeshRenderer>().enabled = false;
                transform.position = respawnPoint;
                resetTimer = 0;
                shouldReset = false;
            }
        }



    }

    void OnCollisionEnter2D(Collision2D other)
    {
        source.clip = hitSound;
        
        source.PlayOneShot(hitSound);


        if (other.gameObject.name.Contains("Goal computer"))
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();


            source.clip = goalSound;
            source.Play();

            shouldReset = true;
            goal.GetComponent<MeshRenderer>().enabled = true;
            transform.position = deathPoint.position;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            respawnPoint = Vector3.right;

        }

        if (other.gameObject.name.Contains("Goal player"))
        {
            enemyScore++;
            enemyScoreText.text = enemyScore.ToString();


            source.clip = goalSound;
            source.Play();

            shouldReset = true;
            goal.GetComponent<MeshRenderer>().enabled = true;
            transform.position = deathPoint.position;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            respawnPoint = Vector3.left;
        }

        if (playerScore >= 7 || enemyScore >= 7)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}