using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigid;
    bool isRightSideBeginning;
    public float Difficulty;    // Basically Speed of the ball
    public Vector3 StartPosition;

    public bool isPlayerOneFavoured;

    PlayerOne Player;
    LogicManager Logic;
    // Start is called before the first frame update
    void Start()
    {
        BallMovement();
        Player = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerOne>();
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }
    private void Update()
    {
        // Speed Clampen
        Mathf.Clamp(BallRigid.velocity.x, 0, 20);
        Mathf.Clamp(BallRigid.velocity.y, 0, 20);
    }
    public void BallMovement()
    {
        //AnfangsPosition bestimmen

        StartPosition = transform.position;

        Vector2 RandomDirection = new Vector3(Random.Range(0.25f, 0.75f), Random.Range(0.25f, 0.75f));

        // Coinflip

        float Coinflip = Random.value;
        if (Coinflip > 0.5f)
        {
            isRightSideBeginning = true;
        }

        // BewegungBall
        if (isRightSideBeginning)
        {
            BallRigid.velocity += RandomDirection.normalized * Difficulty;
        }
        else
        {
            BallRigid.velocity -= RandomDirection.normalized * Difficulty;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nach jedem Bounce schneller machen
        BallRigid.velocity += new Vector2 (0.0025f, 0.0025f);

        // Wer hat den Ball zuletzt berührt
        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            isPlayerOneFavoured = true;

            if (PlayerOne.isPlayerOneBigger)
            {
                Logic.RevertBiggerPowerUp();
            }
        }
        if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            isPlayerOneFavoured = false;

            if (PlayerOne.isPlayerTwoBigger)
            {
                Logic.RevertBiggerPowerUp();
            }
        }
    }
}
