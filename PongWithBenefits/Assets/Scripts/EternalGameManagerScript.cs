using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EternalGameManagerScript : MonoBehaviour
{
    public static EternalGameManagerScript Instance;

    public float PlayerGoalPointsTransfer;
    public float Player2GoalPointsTransfer;

    public bool isGladiatorFightOver;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (isGladiatorFightOver && SceneManager.GetActiveScene().name == "MainLevel")
        {
            TransferGladiatorPoints();
        }
    }

    void TransferGladiatorPoints()
    {
        LogicManager.Instance.GoalAIScore = EternalGameManagerScript.Instance.Player2GoalPointsTransfer;
        LogicManager.Instance.GoalPlayerScore = EternalGameManagerScript.Instance.PlayerGoalPointsTransfer;
        LogicManager.Instance.AIGoalUI.text = LogicManager.Instance.GoalAIScore.ToString();
        LogicManager.Instance.PlayerGoalUI.text = LogicManager.Instance.GoalPlayerScore.ToString();
        isGladiatorFightOver = false;
    }
}
