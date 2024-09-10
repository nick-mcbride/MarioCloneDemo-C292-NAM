using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int pointValue;

    private void Start()
    {
        switch (gameObject.tag)
        {
            case "smallCoin":
                pointValue = 1;
                Debug.Log("Coin initialized as smallCoin with value 1");
                break;
            case "coin":
                pointValue = 5;
                Debug.Log("Coin initialized as coin with value 5");
                break;
            case "bigCoin":
                pointValue = 10;
                Debug.Log("Coin initialized as bigCoin with value 10");
                break;
            default:
                pointValue = 1;
                Debug.Log("Coin initialized with default value 1");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with coin");
            UIManagement.Instance.IncreaseScore(pointValue);
            Destroy(gameObject);
        }
    }
}
