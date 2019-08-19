using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_script : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;
    public LayerMask whatdoesP1Hit;
    public LayerMask whatdoesP2Hit;

    public string player;

    public GameObject destroySound;
    public GameObject enemy_hp;


    private void Start()
    {
        GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        RaycastHit2D hitInfo;
        if (player == "player1")
        {
            hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatdoesP1Hit);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else
        {
            hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatdoesP2Hit);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        
        if (hitInfo.collider != null)
        {
            if (player == "player1")
            {
               if(hitInfo.collider.GetComponent<player_2_controls>().TakeHit())
                {
                    enemy_hp.GetComponent<bar_script>().ApplyDamage(damage);
                }

            }
            else if (player == "player2")
            {
                if(hitInfo.collider.GetComponent<player_1_controls>().TakeHit())
                {
                    enemy_hp.GetComponent<bar_script>().ApplyDamage(damage);
                }
            }

            Instantiate(destroySound, transform.position, Quaternion.identity);
            Destroy(gameObject);       
        }
    }
  
}