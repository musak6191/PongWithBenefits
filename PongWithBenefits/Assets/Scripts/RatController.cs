using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatController : MonoBehaviour
{
    GameObject PlayerOne;
    GameObject PlayerTwo;
    Ball BallScript;

    [SerializeField] float Speed;

    bool isPlayerOneCooked;

    float RanOverOffset = 0.5f;
    bool isGettingRanOver;
    [SerializeField] LayerMask Player;

    // Start is called before the first frame update
    void Start()
    {
        // Referenzen
        PlayerOne = GameObject.FindWithTag("PlayerOne");
        PlayerTwo = GameObject.FindWithTag("PlayerTwo");
        BallScript = GameObject.FindWithTag("Ball").GetComponent<Ball>();

        // Zu welchem Spieler soll er laufen
        isPlayerOneCooked = BallScript.isPlayerOneFavoured;
    }

    // Update is called once per frame
    void Update()
    {
        isGettingRanOver = (PlayerOne.transform.position.y + RanOverOffset < transform.position.y || PlayerOne.transform.position.y - RanOverOffset > transform.position.y) || (PlayerOne.transform.position.y + RanOverOffset < transform.position.y || PlayerOne.transform.position.y - RanOverOffset > transform.position.y);
        // Wenn er den Spieler von unten trifft, wird er überfahren
        if (isGettingRanOver)
        {
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.tag = "Projectile";
        }

        // Jage den Spieler
        if (!isPlayerOneCooked)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerOne.transform.position, Time.deltaTime * Speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTwo.transform.position, Time.deltaTime * Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerOne") || collision.CompareTag("PlayerTwo"))
        {
            if (gameObject.tag == "Projectile")
            {
                StartCoroutine(DestroyAfterSeconds());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
