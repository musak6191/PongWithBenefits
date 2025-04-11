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

    [SerializeField] GameObject ShootingRay;
    [SerializeField] GameObject ShootingRay2;

    //Variablen für SizeChangePowerup
    Vector3 ScaleChange = new Vector3(0, 20, 0);

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
        Player.PlayerRigid.transform.localScale = Player.StartScalePlayer;
        Player2.PlayerRigid.transform.localScale = Player.StartScalePlayer;
        Player.PlayerRigid.transform.position = Player.StartPostionPlayer;
        Player2.PlayerRigid.transform.position = Player2.StartPostionPlayer;
        Ball.BallRigid.velocity = Ball.StartPosition;
        Ball.BallRigid.transform.position = Ball.StartPosition;
        Ball.BallMovement();
    }

    // Powerups

    //Verschwindet nach so und sovielen Sekunden
    public IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }

    //Methods for making the player bigger/smaller
    public void GetBiggerPowerUp()
    {
        if (Ball.isPlayerOneFavoured && !PlayerOne.isPlayerOneBigger)
        {
            Player.transform.localScale = Player.transform.localScale + ScaleChange;
            PlayerOne.isPlayerOneBigger = true;
            Debug.Log("Player One is bigger now!");
        }
        if (!Ball.isPlayerOneFavoured && !PlayerOne.isPlayerTwoBigger)
        {
            Player2.transform.localScale = Player2.transform.localScale + ScaleChange;
            PlayerOne.isPlayerTwoBigger = true;
            Debug.Log("Player Two is bigger now!");
        }
    }
    public void RevertBiggerPowerUp()
    {
        if (PlayerOne.isPlayerOneBigger && Ball.isPlayerOneFavoured)
        {
            Player.transform.localScale = Player.transform.localScale - ScaleChange;
            PlayerOne.isPlayerOneBigger = false;
            Debug.Log("Player One is smaller now!");
        }
        if (PlayerOne.isPlayerTwoBigger && !Ball.isPlayerOneFavoured)
        {
            Player2.transform.localScale = Player2.transform.localScale - ScaleChange;
            PlayerOne.isPlayerTwoBigger = false;
            Debug.Log("Player Two is smaller now!");
        }
    }

    //Method for instantiating a Ray that stuns
    public IEnumerator ActivateLasers()
    {
        if (Ball.isPlayerOneFavoured)
        {
            ShootingRay.SetActive(true);
            yield return new WaitForSeconds(2);
            ShootingRay.SetActive(false);
        }
        if (!Ball.isPlayerOneFavoured)
        {
            ShootingRay2.SetActive(true);
            yield return new WaitForSeconds(2);
            ShootingRay2.SetActive(false);
        }
    }
}
