using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorController : MonoBehaviour
{
    Rigidbody2D PlayerRigid;
    [SerializeField] bool isPlayerOne;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] float RotationMaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Schneller über Zeit
            Mathf.Lerp(RotationSpeed, RotationMaxSpeed, Time.deltaTime);

        // drehen
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);

        //Controls
        if (Input.GetKey(KeyCode.W) && isPlayerOne)         // Player One Controls
        {
            PlayerRigid.position += Vector2.right * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && isPlayerOne)
        {
            PlayerRigid.position += Vector2.left * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isPlayerOne)      // Player Two Controls
        {
            PlayerRigid.position += Vector2.left * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isPlayerOne)
        {
            PlayerRigid.position += Vector2.right * MoveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
