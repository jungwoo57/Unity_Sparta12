using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;
    private void Update()
    {
        scoreText.text = "Score : " + GameManager.Instance.score.ToString();
        maxScoreText.text = "MaxScore : " + GameManager.Instance.maxScore.ToString();
    }
}
