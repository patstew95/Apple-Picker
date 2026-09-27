using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make clicking this button call Restart(), then hide it until the game is over
        Button btn = GetComponent<Button>();
        if (btn != null) btn.onClick.AddListener(Restart);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ApplePickerScene");
    }
}
