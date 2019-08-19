using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Round_Manager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public string startupState = "start";
    public float fightersWait = 0f;

    public AudioSource readySound;
    public AudioSource fightSound;
    public Sprite readySprite;
    public Sprite fightSprite;
    public Sprite clearSprite; // add a clear thing

    public Sprite p1Wins;
    public Sprite p2Wins;

    private SpriteRenderer spriteRenderer;

    public float timeOut = 3f;

    public bool roundOver = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        fightersWait -= Time.deltaTime;
        if (roundOver)
        {
            timeOut -= Time.deltaTime;
            if ( timeOut <= 0f)
            {
                SceneManager.LoadScene("Select_Screen");
                Char_Select.Player1 = -1;
                Char_Select.Player2 = -1;
            }
        }

        if (startupState == "start")
        {
            startupState = "ready";
            fightersWait = 2f;
            //readySound.Play();
        }
        else if (startupState == "ready")
        {
            spriteRenderer.sprite = readySprite;
            if (fightersWait < 0)
            {
                startupState = "fight";
                fightersWait = 2f;
                //fightSound.Play();
            }
        }
        else if (startupState == "fight")
        {
            spriteRenderer.sprite = fightSprite;
            if (fightersWait < 0)
            {
                startupState = "go";
            }
        }
        else if (!roundOver)
        {
            spriteRenderer.sprite = clearSprite;
        }


    }

    public void endRound(string losingPlayer)
    {
        if (losingPlayer == "player1")
        {
            player1.GetComponent<player_1_controls>().setDefeat();
            player2.GetComponent<player_2_controls>().setWin();
            roundOver = !false;
        }
        else if (losingPlayer == "player2")
        {
            player1.GetComponent<player_1_controls>().setWin();
            player2.GetComponent<player_2_controls>().setDefeat();
            roundOver = !false;
        }

    }
}
