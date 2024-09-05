using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoiBehavior : MonoBehaviour
{
    [SerializeField] private float shrinkSpeed = 0.1f;
    [SerializeField] private float growSpeed = 1f;
    [SerializeField] private Vector3 minSize = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 originalSize;
    private bool isShrinking = true;

    void Start()
    {
        originalSize = transform.localScale;
    }

    void Update()
    {
        if (isShrinking)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, minSize, shrinkSpeed * Time.deltaTime);
            if (transform.localScale.x <= minSize.x + 0.01f)
            {
                isShrinking = false;
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalSize, growSpeed * Time.deltaTime);
            if (transform.localScale.x >= originalSize.x - 0.01f)
            {
                isShrinking = true;
            }
        }
    }
}