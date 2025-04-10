using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBiggerPowerUp : MonoBehaviour
{
    LogicManager Logic;
    PlayerOne Player;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
        Player = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerOne>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Logic.GetBiggerPowerUp();
        Destroy(this.gameObject);
    }
}
