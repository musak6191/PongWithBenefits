using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public static LogicManager Instance;

    public float GoalPlayerScore = 0;
    public float GoalAIScore = 0;

    public Text PlayerGoalUI;
    public Text AIGoalUI;

    public PlayerOne Player;
    public PlayerOne Player2;
    public Ball Ball;

    [SerializeField] GameObject ShootingRay;
    [SerializeField] GameObject ShootingRay2;
    ActivateShootingRay ShootingRayScript;
    public bool isShootingRayAlreadyActive;

    [SerializeField] SpawnManager Spawn;

    SpriteRenderer Sprite1;
    SpriteRenderer Sprite2;
    Color CurrentColorLogic1;

    //Variablen für SizeChangePowerup
    Vector3 ScaleChange = new Vector3(0, 20, 0);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //PlayerGoalUI = GameObject.Find("PlayerOneGoalInfo").GetComponent<Text>();
        //AIGoalUI = GameObject.Find("PlayerTwoGoalInfo").GetComponent<Text>();
        //Player = GameObject.Find("PlayerOne").GetComponent<PlayerOne>();
        //Player2 = GameObject.Find("PlayerTwo").GetComponent<PlayerOne>();
        //Ball = GameObject.Find("Ball").GetComponent<Ball>();
        //ShootingRay = GameObject.Find("ShootingRay");
        //ShootingRay2 = GameObject.Find("ShootingRay2");
        //Spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        AIGoalUI.text = GoalAIScore.ToString();
        PlayerGoalUI.text = GoalPlayerScore.ToString();
        ShootingRayScript = FindAnyObjectByType<ActivateShootingRay>();
        Sprite1 = Player.GetComponent<SpriteRenderer>();
        Sprite2 = Player2.GetComponent<SpriteRenderer>();
        CurrentColorLogic1 = Sprite1.color;
    }

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
        Sprite1.color = CurrentColorLogic1;
        Sprite2.color = CurrentColorLogic1;
        Ball.BallRigid.velocity = Ball.StartPosition;
        Ball.BallRigid.transform.position = Ball.StartPosition;
        Ball.BallMovement();
        PlayerOne.isPlayerOneBigger = false;
        PlayerOne.isPlayerTwoBigger = false;
        Player.MoveSpeed = Player.StartMoveSpeed;
        Player2.MoveSpeed = Player2.StartMoveSpeed;
        DeleteAllPowerUpsFromField();
        Spawn.CancelInvoke();
        Spawn.InvokeRepeating("SpawnPowerup", 5, 5);
        ShootingRay.SetActive(false);
        ShootingRay2.SetActive(false);
    }

                        // Powerups

    //Method to remove all Powerups
    void DeleteAllPowerUpsFromField()
    {
        PowerUpBase[] AllPowerUpsOnField = FindObjectsOfType<PowerUpBase>();
        foreach (PowerUpBase PowerUp in AllPowerUpsOnField)
        {
            Destroy(PowerUp.gameObject);
        }
    }

    //Methods for making the player bigger/smaller
    public void GetBiggerPowerUp()
    {
        if (Ball.isPlayerOneFavoured && !PlayerOne.isPlayerOneBigger)
        {
            Player.transform.localScale = Player.transform.localScale + ScaleChange;
            PlayerOne.isPlayerOneBigger = true;
        }
        if (!Ball.isPlayerOneFavoured && !PlayerOne.isPlayerTwoBigger)
        {
            Player2.transform.localScale = Player2.transform.localScale + ScaleChange;
            PlayerOne.isPlayerTwoBigger = true;
        }
    }
    public void RevertBiggerPowerUp()
    {
        if (PlayerOne.isPlayerOneBigger && Ball.isPlayerOneFavoured)
        {
            Player.transform.localScale = Player.transform.localScale - ScaleChange;
            PlayerOne.isPlayerOneBigger = false;
        }
        if (PlayerOne.isPlayerTwoBigger && !Ball.isPlayerOneFavoured)
        {
            Player2.transform.localScale = Player2.transform.localScale - ScaleChange;
            PlayerOne.isPlayerTwoBigger = false;
        }
    }

    //Method for instantiating a Ray that stuns
    public IEnumerator ActivateLasers()
    {
        if (Ball.isPlayerOneFavoured && isShootingRayAlreadyActive)
        {
            ShootingRay.SetActive(true);
            yield return new WaitForSeconds(ShootingRayScript.WindUpTime);
            ShootingRay.transform.localScale = ShootingRayScript.BigScale;
            ShootingRay.gameObject.tag = "Projectile";
            yield return new WaitForSeconds(ShootingRayScript.duration);
            ShootingRay.transform.localScale = ShootingRayScript.SmallScale;
            ShootingRay.gameObject.tag = "Untagged";
            isShootingRayAlreadyActive = false;
            ShootingRay.gameObject.SetActive(false);
        }
        else if (!Ball.isPlayerOneFavoured && isShootingRayAlreadyActive)
        {
            ShootingRay2.SetActive(true);
            yield return new WaitForSeconds(ShootingRayScript.WindUpTime);
            ShootingRay2.transform.localScale = ShootingRayScript.BigScale;
            ShootingRay2.gameObject.tag = "Projectile";
            yield return new WaitForSeconds(ShootingRayScript.duration);
            ShootingRay2.transform.localScale = ShootingRayScript.SmallScale;
            ShootingRay2.gameObject.tag = "Untagged";
            isShootingRayAlreadyActive = false;
            ShootingRay2.gameObject.SetActive(false);
        }
    }
}
