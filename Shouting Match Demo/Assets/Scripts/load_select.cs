using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.IO.Ports;


public class load_select : MonoBehaviour
{

    public GameObject fadeTransition;

    SerialPort sp = new SerialPort("COM5", 9600);

    private void Start()
    {
        sp.Open();
        sp.ReadTimeout = 25;
    }

    void Update()
    {
        Debug.Log(sp.IsOpen);
        if (sp.IsOpen)
        {
            try
            {
                LoadScene(sp.ReadByte());
               // print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Select_Screen");
            //fadeTransition.GetComponent<fade_in>().DoFade(0.5f, "Select_Screen");
        }

    }

    void LoadScene(int Shout)
    {
        Debug.Log("hey");
        if (Shout == 1 || Shout == 11 || Shout == 111)
        {
            SceneManager.LoadScene("Select_Screen");
            
        }
    }
}