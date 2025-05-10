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

    [SerializeField] float Speed;

    bool isGettingRanOver;
    float RanOverDistance = 1;
    [SerializeField] LayerMask Player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOne = GameObject.FindWithTag("PlayerOne");
        PlayerTwo = GameObject.FindWithTag("PlayerTwo");
        PlayerOneBoxCollider = PlayerOne.GetComponent<BoxCollider2D>();
        PlayerTwoBoxCollider = PlayerOne.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerOne.transform.position, Time.deltaTime * Speed);

        // Schauen ob die Ratte von der Seite von Pong getroffen wird
        isGettingRanOver = Physics2D.Raycast(transform.position, Vector2.up, RanOverDistance, Player);

        if ( isGettingRanOver)
        {
            Debug.Log("Spieler getroffen!");
        }
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
