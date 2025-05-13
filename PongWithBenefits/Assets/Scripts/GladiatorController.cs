using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PointUI;
    [SerializeField] TextMeshProUGUI GameOverUI;
    Rigidbody2D PlayerRigid;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    SpriteRenderer PlayerRenderer;

    [SerializeField] bool isPlayerOne;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] float RotationMaxSpeed;

    public int PointsToWin = 10;

    float StartPosition1;
    float StartPosition2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MakePointsLessValuable());
        PlayerRenderer = GetComponent<SpriteRenderer>();
        StartPosition1 = Player1.transform.position.x - 0.5f;
        StartPosition2 = Player2.transform.position.x + 0.5f;
        StartCoroutine(GladiatorStart());
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime * 0.05f;       //Dass es langsamer sich an Max Speed nähert
        // Schneller über Zeit
        RotationSpeed = Mathf.Lerp(RotationSpeed, RotationMaxSpeed, t);

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

        PlayerRigid.position = new Vector2 (Mathf.Clamp(PlayerRigid.position.x, StartPosition1, StartPosition2), PlayerRigid.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            PlayerRenderer.color = Color.black;
            StartCoroutine(GladiatorOver());
        }
    }

    IEnumerator MakePointsLessValuable()
    {
        PointUI.text = "Points to win : " + PointsToWin;

        yield return new WaitForSeconds(3);
        PointsToWin = 5;
        PointUI.text = "Points to win : " + PointsToWin;

        yield return new WaitForSeconds(7);
        PointsToWin = 3;
        PointUI.text = "Points to win : " + PointsToWin;
    }

    IEnumerator GladiatorOver()
    {
        Time.timeScale = 0;
        GameOverUI.gameObject.SetActive(true);
        PointUI.gameObject.SetActive(false);
        if (Player1 == null)
        {
            GameOverUI.text = "Player 2 wins " + PointsToWin + " points !";
            LogicManager.Instance.GoalAIScore += PointsToWin;
        }
        else
        {
            GameOverUI.text = "Player 1 wins " + PointsToWin + " points !";
            LogicManager.Instance.GoalPlayerScore += PointsToWin;
        }

        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    IEnumerator GladiatorStart()
    {
        Time.timeScale = 0;
        GameOverUI.gameObject.SetActive(true);
        PointUI.gameObject.SetActive(false);
        GameOverUI.text = "Kill your opponent!";
        Debug.Log("3 Sekunden angefangen!");
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("3 Sekunden beendet!");
        GameOverUI.gameObject.SetActive(false);
        PointUI.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
