using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RatPowerupScript : PowerUpBase
{
    [SerializeField] GameObject Rat;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(Rat, transform.position, Rat.transform.rotation);
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
