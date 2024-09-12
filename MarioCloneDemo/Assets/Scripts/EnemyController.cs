using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed;
    [SerializeField] int enemyDamage = 10;


    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {

        transform.Translate(enemyMoveSpeed * Vector2.left * enemyMoveSpeed * Time.deltaTime);
        // (5,0)
        //
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(enemyDamage);
            }
        }
    }

}
