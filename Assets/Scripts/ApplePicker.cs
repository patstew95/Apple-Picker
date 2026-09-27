using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public  GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY =2f;
    public GameObject restartButton;
    public List<GameObject> basketList;

    private RoundCounter roundCounter;

    // Start is called before the first frame update
    void Start()
    {
        //timeScale survives scene loads, so make sure a restarted game is not still frozen
        Time.timeScale = 1f;

        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets ; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        GameObject roundGO = GameObject.Find("RoundCounter");
        if (roundGO != null) roundCounter = roundGO.GetComponent<RoundCounter>();
        if (roundCounter == null)
        {
            Debug.LogWarning("ApplePicker: no active GameObject named \"RoundCounter\" with a RoundCounter component; round display will not update.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AppleMissed()
    {
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray)
        {
            Destroy( tempGo);
        }
        //destroy one of the baskets
        // get the index of the last Basket in basketlist
        int basketIndex = basketList.Count -1;
        //get a reference to that basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // remove basket from list and destroy object
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        //if no baskets left, restart game
        if(basketList.Count == 0)
        {
            GameOver();
        }
        else if (roundCounter != null)
        {
            roundCounter.SetRound(numBaskets - basketList.Count + 1);
        }
    }

    // end the game immediately, however it was lost
    public void GameOver()
    {
        //show the button and freeze first, so a failure updating the text cannot suppress them
        if (restartButton != null) restartButton.SetActive(true);
        //freeze the game so GAME OVER stays on screen until the player restarts
        Time.timeScale = 0f;
        if (roundCounter != null) roundCounter.ShowGameOver();
    }
}
