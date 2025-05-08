using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRayPowerup : PowerUpBase
{
    LogicManager Logic;
    PlayerOne Player;
    ActivateShootingRay ShootingRay;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
        Player = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerOne>();
        Transform child = Player.transform.Find("ShootingRay");

        //ShootingRay = Player.GetComponentInChildren<ActivateShootingRay>();

        ShootingRay = child.GetComponent<ActivateShootingRay>();

        StartCoroutine(DestroyAfterSeconds());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Logic.isShootingRayAlreadyActive = true;
            Logic.StartCoroutine(Logic.ActivateLasers());
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
