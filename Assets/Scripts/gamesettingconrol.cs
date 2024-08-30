using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamesettingcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseGameSettingUI()
    {
      
            GameObject MainMenu = GameObject.FindGameObjectWithTag("mainmenu").transform.gameObject;
            GameObject GameSettingUI = GameObject.FindGameObjectWithTag("gamesettingui").transform.gameObject;
            MainMenu.transform.GetChild(0).gameObject.SetActive(true);
            GameSettingUI.transform.GetChild(0).gameObject.SetActive(false);
        
    }
}
