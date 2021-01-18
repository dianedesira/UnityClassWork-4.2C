using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Slider healthBar;
    GameObject healthBarFill;

    Player player; // reference to the Player script so that we can access the player's health

    int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();

        healthBar = FindObjectOfType<Slider>();
        maxHealth = player.GetHealth();
        healthBar.maxValue = maxHealth;

        healthBarFill = GameObject.Find("HealthBar Image");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHealth().ToString();

        healthBar.value = player.GetHealth();

        if(player.GetHealth() <= (maxHealth / 4))
            healthBarFill.GetComponent<Image>().color = new Color(255, 0, 0);
        else if(player.GetHealth() <= (maxHealth / 2))
            healthBarFill.GetComponent<Image>().color = new Color(255, 69, 0);
    }
}
