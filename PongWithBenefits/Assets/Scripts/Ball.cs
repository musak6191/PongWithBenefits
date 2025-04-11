using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigid;       // Rigidbody vom Ball
    bool isRightSideBeginning;      // Welche Seite fängt an Boolean
    public float Difficulty;    // Basically Speed of the ball
    public Vector3 StartPosition;       //Start Position deklarieren

    float SpeedIncrease = 0.25f;        // Wie viel schneller es sein soll nach jedem Bounce

    float[] PossibleDirections = new float[] { -0.75f, -0.25f, 0.25f, 0.75f };      // Array für mögliche Richtungen

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
        //Mathf.Clamp(BallRigid.velocity.x, 0, 20);
        //Mathf.Clamp(BallRigid.velocity.y, 0, 20);
    }
    public void BallMovement()
    {
        //AnfangsPosition bestimmen

        StartPosition = transform.position;

        int RandomIndexDirection = Random.Range(0, PossibleDirections.Length);

        Vector2 RandomDirection = new Vector3(PossibleDirections[RandomIndexDirection], PossibleDirections[RandomIndexDirection]);

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
        Vector2 currentDirection = BallRigid.velocity.normalized;       // Richtungsvektor mithilfe von Geschwindigkeitsvektor speicher
        float NewSpeed = BallRigid.velocity.magnitude + SpeedIncrease;      // Neue Speed Variable setzen mithilfe von Länge vom Speed Vektor + Speed Increase

        BallRigid.velocity = currentDirection * NewSpeed;       // Neue Geschwindigkeit gesetzt indem normalized Richtung (also Länge 1) mit neuem Speed multipliziert wird

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
