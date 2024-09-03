using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

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

}
