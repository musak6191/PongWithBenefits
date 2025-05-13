using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorPowerUp : PowerUpBase
{
    LogicManager Logic;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            EternalGameManagerScript.Instance.PlayerGoalPointsTransfer = LogicManager.Instance.GoalPlayerScore;
            EternalGameManagerScript.Instance.Player2GoalPointsTransfer = LogicManager.Instance.GoalAIScore;
            SceneManager.LoadScene(1);
        }
    }
}
