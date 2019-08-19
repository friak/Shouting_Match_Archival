using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    public player_1_controls player1;
    public player_2_controls player2;

    //Jah Ni
    public float speed0;
    public float distance0;
    public GameObject Light0;
    public GameObject Mid0;
    public GameObject Heavy0;

    public Sprite Player0;
    public Sprite Player_Move0;
    public Sprite Player_Windup01;
    public Sprite Player_Windup02;
    public Sprite Player_Windup03;
    public Sprite Player_Attack0;
    public Sprite Player_Block0;
    public Sprite Player_Defeat0;
    public Sprite Player_Hurt0;


    //Suhena
    public float speed1;
    public float distance1;
    public GameObject Light1;
    public GameObject Mid1;
    public GameObject Heavy1;

    public Sprite Player1;
    public Sprite Player_Move1;
    public Sprite Player_Windup11;
    public Sprite Player_Windup12;
    public Sprite Player_Windup13;
    public Sprite Player_Attack1;
    public Sprite Player_Block1;
    public Sprite Player_Defeat1;
    public Sprite Player_Hurt1;

    public void Start()
    {
        if (Char_Select.Player1 == 0 || Char_Select.Player1 == -1)
        {
            player1.speed = speed0;
            player1.distance = distance0;
            player1.Light = Light0;
            player1.Mid = Mid0;
            player1.Heavy = Heavy0;

            player1.Player = Player0;
            player1.Player_Move = Player_Move0;
            player1.Player_Windup01 = Player_Windup01;
            player1.Player_Windup02 = Player_Windup02;
            player1.Player_Windup03 = Player_Windup03;
            player1.Player_Attack = Player_Attack0;
            player1.Player_Block = Player_Block0;
            player1.Player_Defeat = Player_Defeat0;
            player1.Player_Win = Player_Attack0;
            player1.Player_Hurt = Player_Hurt0;

        }
            
        else if (Char_Select.Player1 ==1)
        {
            player1.speed = speed1;
            player1.distance = distance1;
            player1.Light = Light1;
            player1.Mid = Mid1;
            player1.Heavy = Heavy1;

            player1.Player = Player1;
            player1.Player_Move = Player_Move1;
            player1.Player_Windup01 = Player_Windup11;
            player1.Player_Windup02 = Player_Windup12;
            player1.Player_Windup03 = Player_Windup13;
            player1.Player_Attack = Player_Attack1;
            player1.Player_Block = Player_Block1;
            player1.Player_Defeat = Player_Defeat1;
            player1.Player_Win = Player_Attack1;
            player1.Player_Hurt = Player_Hurt1;
        }


        if (Char_Select.Player2 == 0)
        {
            player2.speed = speed0;
            player2.distance = distance0;
            player2.Light = Light0;
            player2.Mid = Mid0;
            player2.Heavy = Heavy0;

            player2.Player = Player0;
            player2.Player_Move = Player_Move0;
            player2.Player_Windup11 = Player_Windup01;
            player2.Player_Windup12 = Player_Windup02;
            player2.Player_Windup13 = Player_Windup03;
            player2.Player_Attack = Player_Attack0;
            player2.Player_Block = Player_Block0;
            player2.Player_Defeat = Player_Defeat0;
            player2.Player_Win = Player_Attack0;
            player2.Player_Hurt = Player_Hurt0;
        }

        else if (Char_Select.Player2 == 1 || Char_Select.Player2 == -1)
        {
            player2.Light = Light1;
            player2.Mid = Mid1;
            player2.Heavy = Heavy1;

            player2.Player = Player1;
            player2.Player_Move = Player_Move1;
            player2.Player_Windup11 = Player_Windup11;
            player2.Player_Windup12 = Player_Windup12;
            player2.Player_Windup13 = Player_Windup13;
            player2.Player_Attack = Player_Attack1;
            player2.Player_Block = Player_Block1;
            player2.Player_Defeat = Player_Defeat1;
            player2.Player_Win = Player_Attack1;
            player2.Player_Hurt = Player_Hurt1;
        }
    }
}
