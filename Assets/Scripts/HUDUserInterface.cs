using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUserInterface : MonoBehaviour {

    public Unit player;
    public Image healthBar;
    public Text healthLabel;
    int i = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = player.GetHealth()*1.0f / (player.maxHealth*1.0f);
        healthLabel.text = player.GetHealth().ToString();
        
        if(player == null && i == 0)
        {
            Debug.Log("No player");
            i++;
        }
	}
}
