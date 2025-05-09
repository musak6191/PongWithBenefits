using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    GameObject PlayerOne;
    GameObject PlayerTwo;

    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOne = GameObject.FindWithTag("PlayerOne");
        PlayerTwo = GameObject.FindWithTag("PlayerTwo");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerOne.transform.position, Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerOne") || collision.CompareTag("PlayerTwo"))
        {
            StartCoroutine(DestroyAfterSeconds());
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
