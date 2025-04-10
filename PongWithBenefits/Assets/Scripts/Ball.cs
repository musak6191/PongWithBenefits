using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigid;
    bool isRightSideBeginning;
    public float Difficulty;
    public Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        BallMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
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
   
}
