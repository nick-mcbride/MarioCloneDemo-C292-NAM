using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;

public class UIManagement : MonoBehaviour
{
    public static UIManagement Instance;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI hitPointsText;

    private int currentPoints = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int points)
    {
        currentPoints += points;
        pointText.text = "x" + currentPoints;
    }

    public void UpdateHitPoints(int hitPoints)
    {
        hitPointsText.text = "HP: " + hitPoints;
    }
}
