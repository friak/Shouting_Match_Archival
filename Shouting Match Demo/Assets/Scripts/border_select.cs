using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.IO.Ports;

public class border_select : MonoBehaviour
{

    public GameObject gotoFight;
    private GameObject Border;

    public GameObject sound;
    public GameObject selected;

    public float speed;

    private Vector2[] selectPos = new Vector2[] { new Vector2(-1f, -3.5f), new Vector2(1f, -3.5f) };
    private int targetPos = 0;

    public GameObject portrait;

    private bool jsLeft = false;
    private bool jsRight = false;

    SerialPort sp = new SerialPort("COM5", 9600);

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
            Debug.Log("Controller 2 Not Found!");
        }

    }

    // Update is called once per frame
    void Update()
    {

        {

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

            float newXPos = Mathf.Lerp(transform.position.x, selectPos[targetPos].x, Time.deltaTime * speed);
            float newYPos = Mathf.Lerp(transform.position.y, selectPos[targetPos].y, Time.deltaTime * speed);
            transform.position = new Vector3(newXPos, newYPos);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //change targetPos to charID
                selected.GetComponent<AudioSource>().Play();
                Char_Select.Player1 = targetPos;
                gotoFight.GetComponent<go_fight>().goFight();

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Char_Select.Player1 = -1;
            }

            if (Input.GetKeyDown(KeyCode.D) && Char_Select.Player1 == -1)
            {
                sound.GetComponent<AudioSource>().Play();
                if (targetPos == selectPos.Length - 1)
                {
                    targetPos = 0;
                }
                else
                {
                    targetPos += 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && Char_Select.Player1 == -1)
            {
                sound.GetComponent<AudioSource>().Play();
                if (targetPos == 0)
                {
                    targetPos = selectPos.Length - 1;
                }
                else
                {
                    targetPos -= 1;
                }
            }
        }

        void MoveObject(int data)
        {
            Debug.Log("mov");
            if (data == 100) //joystick not moving
            {
                jsLeft = false;
                jsRight = false;
            }


            if (data == 4 && !jsLeft && Char_Select.Player1 == -1) //up
            {
                jsLeft = true;
                sound.GetComponent<AudioSource>().Play();
                if (targetPos == 0)
                {
                    targetPos = selectPos.Length - 1;
                }
                else
                {
                    targetPos -= 1;
                }
            }
            else if (data == 5 && !jsRight && Char_Select.Player1 == -1) //down
            {
                jsRight = true;
                sound.GetComponent<AudioSource>().Play();
                if (targetPos == selectPos.Length - 1)
                {
                    targetPos = 0;
                }
                else
                {
                    targetPos += 1;
                }
            }


            //SELECT
            if (data == 1 || data == 11 || data == 111)
            {
                //change targetPos to charID
                selected.GetComponent<AudioSource>().Play();
                Char_Select.Player1 = targetPos;
                gotoFight.GetComponent<go_fight>().goFight();

            }

        }
    }
}
