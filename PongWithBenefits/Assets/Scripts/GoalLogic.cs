using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLogic : MonoBehaviour 
{
    LogicManager Logic;
    public bool isPlayerTwoGoal;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayerTwoGoal)
            {
                Logic.AddPlayerTwoScore();
            }
            else
            {
                Logic.AddPlayerScore();
            }
        }
    }
}
