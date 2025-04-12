using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBiggerPowerUp : PowerUpBase
{
    LogicManager Logic;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
        StartCoroutine(DestroyAfterSeconds());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Logic.GetBiggerPowerUp();
        Destroy(this.gameObject);
    }

    public IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}

