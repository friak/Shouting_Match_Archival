using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2attack_script : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;

    public GameObject destroySound;
    public GameObject enemy_hp;


    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    { 
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
        DestroyProjectile();
            enemy_hp.GetComponent<bar_script>().ApplyDamage(damage);
         // IN THE BAR SCRIPT have a variable of remaining damage
         // DO THIS IN THE BAR SCRIPT
        //damage amount is subtracted from the x scale of game object "Bar"        

            }

        transform.Translate(Vector2.left* speed * Time.deltaTime);

        void DestroyProjectile()
        {
            Instantiate(destroySound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}