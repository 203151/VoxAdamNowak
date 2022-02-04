using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private TextMeshProUGUI uGUITextMeshPro;
    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        uGUITextMeshPro = GetComponent<TextMeshProUGUI>();
        uGUITextMeshPro.text = "Aktualny wynik: " + currentScore;
    }

    public void IncreaseScore()
    {
        currentScore++;
        uGUITextMeshPro.text = "Aktualny wynik: " + currentScore;
    }
}
