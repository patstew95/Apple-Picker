using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
     [Header("Dynamic")]
    public int round = 1;

    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        if (uiText == null)
        {
            Debug.LogWarning("RoundCounter: this GameObject has no UnityEngine.UI.Text component (a TextMeshPro component is a different type and will not be found), so the round text cannot update.");
            return;
        }
        uiText.text = "Round " + round.ToString("#,0");
    }

    public void SetRound(int newRound)
    {
        round = newRound;
        if (uiText != null) uiText.text = "Round " + round.ToString("#,0");
    }

    public void ShowGameOver()
    {
        if (uiText != null) uiText.text = "GAME OVER";
    }
}
