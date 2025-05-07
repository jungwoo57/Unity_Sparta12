using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    public TextMeshProUGUI mainText;

    private void Update()
    {
        mainText.text = "Your Best Score " + GameManager.Instance.score;
    }
}
