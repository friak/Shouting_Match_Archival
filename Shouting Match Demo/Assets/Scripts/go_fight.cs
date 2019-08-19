using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_fight : MonoBehaviour
{

    private float timeOut = 1f;
    private bool readyToFight = false;

    public void Update()
    {
        if (readyToFight)
        {
            timeOut -= Time.deltaTime;
            if (timeOut <= 0f)
            {
                SceneManager.LoadScene("Fight_Scene");
            }
        }
    }
    public void goFight()
    {
        if (Char_Select.Player1 != -1 && Char_Select.Player2 != -1)
        {
            readyToFight = true;
        }
    }
}
