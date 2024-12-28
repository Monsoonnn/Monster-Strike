using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnBuyItem : BaseBtn
{
    [SerializeField] private List<Sprite> star;
    public StarBuyUI starBuyUI;
    private bool isBuying = false;
    protected override void OnClick() {


        int totalCoins = PlayerPrefs.GetInt("Coins");

        starBuyUI = GetComponent<StarBuyUI>();

        string itemname = starBuyUI.item.itemName;
        int currentLevel = PlayerPrefs.GetInt(itemname, 0);
       
        if (!isBuying) {
            

            
            if (currentLevel < 3) {

                if (totalCoins >= starBuyUI.coin) {
                    int newCoins = (totalCoins - starBuyUI.coin);
                    PlayerPrefs.SetInt("Coins", newCoins );
                    currentLevel++;
                    PlayerPrefs.SetInt(itemname, currentLevel);
                    starBuyUI.ChangeSprite(star[0]);
                    isBuying = true;
                }

                
            }


            // Lưu level mới vào PlayerPrefs
            
        }
           
       
    }
}
