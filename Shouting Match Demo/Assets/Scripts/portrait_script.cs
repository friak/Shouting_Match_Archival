using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portrait_script : MonoBehaviour
{

    public GameObject portrait;
    public Sprite[] portraitList;
    private int arrayIndx = 0;
    private SpriteRenderer spriteRenderer;

    public string player;


    void Update()
    {
        if (player == "player1")
        {
            if (Input.GetKeyDown(KeyCode.D) && Char_Select.Player1 == -1)
            {

                if (arrayIndx == portraitList.Length - 1)
                {
                    arrayIndx = 0;

                }
                else
                {
                    arrayIndx += 1;
                }
                GetComponent<SpriteRenderer>().sprite = portraitList[arrayIndx];

            }
            else if (Input.GetKeyDown(KeyCode.A) && Char_Select.Player1 == -1)
            {

                if (arrayIndx == 0)
                {
                    arrayIndx = portraitList.Length - 1;
                }
                else
                {
                    arrayIndx -= 1;
                }
                GetComponent<SpriteRenderer>().sprite = portraitList[arrayIndx];
            }

        }

        if (player == "player2")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && Char_Select.Player2 == -1)
            {

                if (arrayIndx == portraitList.Length - 1)
                {
                    arrayIndx = 0;

                }
                else
                {
                    arrayIndx += 1;
                }
                GetComponent<SpriteRenderer>().sprite = portraitList[arrayIndx];

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Char_Select.Player2 == -1)
            {

                if (arrayIndx == 0)
                {
                    arrayIndx = portraitList.Length - 1;
                }
                else
                {
                    arrayIndx -= 1;
                }
                GetComponent<SpriteRenderer>().sprite = portraitList[arrayIndx];
            }

        }
    }
}
