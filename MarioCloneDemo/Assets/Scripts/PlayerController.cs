using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] int maxHitPoints = 100;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int currentHitPoints;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHitPoints = maxHitPoints;
        UpdateHitPointsUI();

        //Vector3position = transform.position;
        //Vector3 size = GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        // (1,0)
        // new vector2(1,0)
        transform.Translate(moveInput * Vector2.right * moveSpeed * Time.deltaTime);
        // (5,0)
        //
    }

    private void Jump()
    {
        // (0,1)
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints <= 0)
        {
            currentHitPoints = 0;
            // Game over thing that will happen
        }
        UpdateHitPointsUI();
    }

    private void UpdateHitPointsUI()
    {
        UIManagement.Instance.UpdateHitPoints(currentHitPoints);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Restart the level
    }
}
