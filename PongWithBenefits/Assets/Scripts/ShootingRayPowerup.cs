using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRayPowerup : MonoBehaviour
{
    LogicManager Logic;
    PlayerOne Player;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
        Player = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerOne>();
        StartCoroutine(DestroyAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(Logic.ActivateLasers());
        }
    }

    public IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
