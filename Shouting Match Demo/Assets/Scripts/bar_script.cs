using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_script : MonoBehaviour
{

    private float hp = 1f;
    public GameObject roundManager;
    public GameObject player;

    private void Start()
    {
        roundManager = GameObject.Find("Round_Manager");
    }

    public void ApplyDamage(float amount)
    {
        hp -= amount;
        transform.localScale = new Vector3(hp, 1f);

        if (hp <= 0f)
        {
           roundManager.GetComponent<Round_Manager>().endRound(player.name);
        }
    }
    

}
