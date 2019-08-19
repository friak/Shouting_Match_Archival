using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class player_2_controls : MonoBehaviour
{
    public Round_Manager roundMan;
    //player movement
    public float speed;
    public float distance;
    private float targetPos = -2.32f;

    private bool jsUp = false;
    private bool jsDown = false;

    //frame states
    private string frameState = "idle"; //player is idle
    private float timeOut = 0f; //time within each state

    //attack prefabs
    public bool Attack;
    public GameObject enemy_hp;
    public GameObject Light;
    public GameObject Mid;
    public GameObject Heavy;
    public Transform shotPoint2;

    //...sprites
    public Sprite Player;
    public Sprite Player_Windup11;
    public Sprite Player_Windup12;
    public Sprite Player_Windup13;
    public Sprite Player_Hurt;
    public Sprite Player_Move;
    public Sprite Player_Attack;
    public Sprite Player_Block;
    public Sprite Player_Defeat;
    public Sprite Player_Win;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2d;

    //Serial Communication
    SerialPort sp = new SerialPort("COM4", 9600);


    void Start()
    {
        // sp.Open() will throw an error if it can't find an arduino and this "try" block will catch that error and allow the game to keep running
        try
        {
            sp.Open();
            sp.ReadTimeout = 25;
        }
        catch (System.Exception)
        {
            Debug.Log("Controller 1 Not Found!");
        }

        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = Player;
    }

    void Update()
    {
        if (roundMan.startupState != "go")
        {
            frameState = "idle";
            return;
        }

        //SERIAL
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                //print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }


        //LERP
        float amountToMove = Mathf.Lerp(transform.position.y, targetPos, Time.deltaTime * speed);
        // Move towards target position
        transform.position = new Vector3(transform.position.x, amountToMove);


        //FRAME STATE
        if (frameState == "wind up1")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = Player_Windup11;
                timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
                GameObject atk = Instantiate(Light, shotPoint2.position, shotPoint2.rotation);
                atk.GetComponent<attack_script>().enemy_hp = enemy_hp;
                atk.GetComponent<attack_script>().player = "player2";
                frameState = "attack";
                timeOut = .25f;
            }
        }

        if (frameState == "wind up2")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = Player_Windup12;
                timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
                GameObject atk = Instantiate(Mid, shotPoint2.position, shotPoint2.rotation);
                atk.GetComponent<attack_script>().enemy_hp = enemy_hp;
                atk.GetComponent<attack_script>().player = "player2";
                frameState = "attack";
                timeOut = .25f;
            }
        }
        if (frameState == "wind up3")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = Player_Windup13;
                timeOut -= Time.deltaTime; // shorthand for: timeOut = timeOut - Time.deltaTime
            }
            else
            {
                GameObject atk = Instantiate(Mid, shotPoint2.position, shotPoint2.rotation);
                atk.GetComponent<attack_script>().enemy_hp = enemy_hp;
                atk.GetComponent<attack_script>().player = "player2";
                frameState = "attack";
                timeOut = .25f;
            }
        }


        if (frameState == "attack")
        {
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = Player_Attack;
                timeOut -= Time.deltaTime;
            }
            else
            {
                frameState = "idle";
            }
        }

        if (frameState == "idle")
        {
            spriteRenderer.sprite = Player;
        }

        if (frameState == "hurt")
            if (timeOut >= 0)
            {
                spriteRenderer.sprite = Player_Hurt;
                timeOut -= Time.deltaTime;
            }
            else
            {
                frameState = "idle";
            }

        if (frameState == "block")
        {
            spriteRenderer.sprite = Player_Block;
        }


        if (frameState == "defeat")
        {
            spriteRenderer.sprite = Player_Defeat;
        }

        if (frameState == "win")
        {
            spriteRenderer.sprite = Player_Win;
        }


        //DEBUG KEYBOARD CONTROLS
        if (Input.GetKeyDown(KeyCode.UpArrow) && frameState == "idle")
        {
            targetPos += distance;
            if (targetPos >= 1.5f)
            {
                targetPos = 1.5f;
            }
            spriteRenderer.sprite = Player_Move;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && frameState == "idle")
        {
            targetPos -= distance;
            if (targetPos <= -3f)
            {
                targetPos = -3f;
            }
            spriteRenderer.sprite = Player_Move;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && frameState == "idle")
        {
            frameState = "block";
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && frameState == "block")
        {
            frameState = "idle";
        }
        if (frameState == "idle")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("aaaaa");
                frameState = "wind up1";
                timeOut = .25f;
            }
        }
    }



    //MOVE
    void MoveObject(int data)
    {
        if (data == 100) //joystick not moving
        {
            jsUp = false;
            jsDown = false;
        }


        if (data == 2 && !jsUp && frameState == "idle") //up
        {
            jsUp = true;
            targetPos += distance;
            if (targetPos >= 1.5f)
            {
                targetPos = 1.5f;
            }
            spriteRenderer.sprite = Player_Move;
        }
        else if (data == 3 && !jsDown && frameState == "idle") //down
        {
            jsDown = true;
            targetPos -= distance;
            if (targetPos <= -3f)
            {
                targetPos = -3f;
            }
            spriteRenderer.sprite = Player_Move;
        }
        else if (data == 4 && frameState == "idle") //block
        {
            frameState = "block";
        }
        else if (data == 100 && frameState == "block")
        {
            frameState = "idle";
        }

        //ATTACK
        if (frameState == "idle")
        {
            if (data == 1)
            {
                Debug.Log("aaaaa");
                frameState = "wind up1";
                timeOut = .25f;
            }

            else if (data == 11)
            {
                frameState = "wind up2";
                timeOut = .60f;
            }

            else if (data == 111)
            {
                frameState = "wind up3";
                timeOut = .60f;
            }
        }

    }

    //don't take damage when blocking
    public bool TakeHit()
    {
        Debug.Log(frameState);
        if (frameState != "block")
        {
            frameState = "hurt";
            timeOut = 0.25f;
            return true;
        }
        Debug.Log("no hurt");

        return false;
    }

    public void setDefeat()
    {
        frameState = "defeat";
    }

    public void setWin()
    {
        frameState = "win";
    }

    public void setIdle()
    {
        frameState = "idle";
    }

}
