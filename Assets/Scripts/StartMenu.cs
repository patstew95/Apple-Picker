using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make the Play button call StartGame(), so it needs no Inspector wiring
        Button btn = GetComponentInChildren<Button>();
        if (btn != null) btn.onClick.AddListener(StartGame);
        else Debug.LogWarning("StartMenu: no Button found on this GameObject or its children.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ApplePickerScene");
    }
}
