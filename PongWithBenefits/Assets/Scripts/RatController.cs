using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatController : MonoBehaviour
{
    GameObject PlayerOne;
    GameObject PlayerTwo;
    BoxCollider2D PlayerOneBoxCollider;
    BoxCollider2D PlayerTwoBoxCollider;
    Ball BallScript;

    [SerializeField] float Speed;

    bool isPlayerOneCooked;

    bool isGettingRanOver;
    float RanOverDistance = 1;
    [SerializeField] LayerMask Player;
    // Start is called before the first frame update
    void Start()
    {
        // Referenzen
        PlayerOne = GameObject.FindWithTag("PlayerOne");
        PlayerTwo = GameObject.FindWithTag("PlayerTwo");
        PlayerOneBoxCollider = PlayerOne.GetComponent<BoxCollider2D>();
        PlayerTwoBoxCollider = PlayerOne.GetComponent<BoxCollider2D>();
        BallScript = GameObject.FindWithTag("Ball").GetComponent<Ball>();

        // Zu welchem Spieler soll er laufen
        isPlayerOneCooked = BallScript.isPlayerOneFavoured;
    }

    // Update is called once per frame
    void Update()
    {
        // Jage den Spieler
        if (!isPlayerOneCooked)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerOne.transform.position, Time.deltaTime * Speed);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTwo.transform.position, Time.deltaTime * Speed);
        }

        // Schauen ob die Ratte von der Seite von Pong getroffen wird
        isGettingRanOver = Physics2D.Raycast(transform.position, Vector2.up, RanOverDistance, Player);

        //if ( isGettingRanOver)
        //{
        //    Destroy(gameObject);
        //}
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * RanOverDistance);
    }
}
