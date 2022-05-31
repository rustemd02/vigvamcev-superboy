using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealthBar : MonoBehaviour
{
    [SerializeField] private Hero player;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currHealthBar;

    void Start()
    {
        Debug.Log(player.hp / 10);
        totalHealthBar.fillAmount = player.hp / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currHealthBar.fillAmount = player.hp / 10;
    }
}
