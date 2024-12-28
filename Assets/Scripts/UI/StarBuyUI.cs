using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarBuyUI : MonoBehaviour
{
    [SerializeField] private Image imageUI;
    [SerializeField] private TextMeshProUGUI textCoins;
    public int coin;
    public Item item;
    public void init(Sprite image, int coins) {
        imageUI.sprite = image;
        textCoins.text = coins.ToString();
        coin = coins;
    }

    public void ChangeSprite( Sprite image) {
        imageUI.sprite = image;
        
    }

}
