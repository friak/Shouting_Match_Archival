using System.Collections;
using System.Collections.Generic;

public static class Char_Select
{
    private static int player1 =-1;
    private static int player2 =-1;
    
    public static int Player1
    {
        get
        {
            return player1;
        }
        set
        {
            player1 = value;
        }
    }

    public static int Player2
    {
        get
        {
            return player2;
        }
        set
        {
            player2 = value;
        }
    }
}
