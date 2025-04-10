using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{

    public float GoalPlayerScore = 0;
    public float GoalAIScore = 0;

    public Text PlayerGoalUI;
    public Text AIGoalUI;

    public PlayerOne Player;
    public PlayerOne Player2;
    public Ball Ball;
   
    public void AddPlayerTwoScore()
    {
        GoalAIScore += 1f;
        AIGoalUI.text = GoalAIScore.ToString();
        ResetGame();
    }

    public void AddPlayerScore()
    {
        GoalPlayerScore += 1f;
        PlayerGoalUI.text = GoalPlayerScore.ToString();
        ResetGame();
    }
    public void ResetGame()
    {
        Player.PlayerRigid.transform.position = Player.StartPostionPlayer;
        Player2.PlayerRigid.transform.position = Player2.StartPostionPlayer;
        Ball.BallRigid.velocity = Ball.StartPosition;
        Ball.BallRigid.transform.position = Ball.StartPosition;
        Ball.BallMovement();
    }
}
