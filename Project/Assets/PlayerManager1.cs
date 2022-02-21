using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager1 : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public void Awake(){
        isGameOver = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            gameOverScreen.SetActive(true);
        }
    }    

    public void ReplayGame(){
        SceneManager.LoadScene("InfiniteScene");
    }
}
