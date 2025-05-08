using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerOne : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;
    public float MoveSpeed;
    public float StartMoveSpeed;
    public bool isPlayerOne;
    public Vector3 StartPostionPlayer;
    public Vector3 StartScalePlayer;
    LogicManager Logic;

    //Variablen für GetBiggerPowerUp
    public static bool isPlayerOneBigger;
    public static bool isPlayerTwoBigger;

    bool isAlreadyStunned;

    // Start is called before the first frame update
    void Start()
    {
        StartMoveSpeed = MoveSpeed;
        StartPostionPlayer = transform.position;
        StartScalePlayer = transform.localScale;
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        if (Input.GetKey(KeyCode.W) && isPlayerOne)         // Player One Controls
        {
            PlayerRigid.position += Vector2.up * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && isPlayerOne)
        {
            PlayerRigid.position += Vector2.down * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isPlayerOne)      // Player Two Controls
        {
            PlayerRigid.position += Vector2.up * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isPlayerOne)
        {
            PlayerRigid.position += Vector2.down * MoveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !isAlreadyStunned)
        {
            StartCoroutine(GetStun(0.5f));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            MoveSpeed += 0.25f;
        }
    }
    
    // Spieler darf sich nicht mehr bewegen und blitzt für die Zeit dunkel auf
    IEnumerator GetStun(float StunTime)
    {
        isAlreadyStunned = true;
        SpriteRenderer Sprite = GetComponent<SpriteRenderer>();
        Color CurrentColor = Sprite.color;
        Sprite.color = Color.black;
        float MoveSpeedFromBefore = MoveSpeed;
        MoveSpeed = 0;
        yield return new WaitForSeconds(StunTime);
        MoveSpeed = MoveSpeedFromBefore;
        Sprite.color = CurrentColor;
        isAlreadyStunned = false;
    }
}
