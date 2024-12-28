using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameChoiceUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public Image imgUI;
    public Image boxImgUI;
    public LayoutItem LayoutItem;
    public string type; 
    
    
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameObject wolf;

    public List<Sprite> boxBGSripte;


    ArrowController arrowController;
    SwordController swordController;
    DragonController dragonController;
    WolfController wolfController;
    PlayerController playerController;

    private void Start() {
        arrowController = arrow.gameObject.GetComponent<ArrowController>();
        swordController = sword.gameObject.GetComponent<SwordController>();
        dragonController = dragon.gameObject.GetComponent<DragonController>();
        wolfController = wolf.gameObject.GetComponent<WolfController>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    public void intItem(LayoutItem item, string typeItem) {
        LayoutItem = item;
        type = typeItem;
        imgUI.sprite = item.image;
        if (typeItem == "arrow") boxImgUI.sprite = boxBGSripte[0];
        else if (typeItem == "sword") boxImgUI.sprite = boxBGSripte[1];
        else if (typeItem == "unique") boxImgUI.sprite = boxBGSripte[2];
        else if (typeItem == "pet") boxImgUI.sprite = boxBGSripte[3];

    }
    
    private void Update() {
        if (type == "arrow") {
            if (LayoutItem.name == "Arrow damage") {
                textUI.text = arrowController.Damage.ToString();
            }
            else if (LayoutItem.name == "Arrow Count") {
                textUI.text = arrowController.count.ToString();
            }
            else if (LayoutItem.name == "Arrow distance") {
                textUI.text = arrowController.maxDistance.ToString();
            }
            else if (LayoutItem.name == "Arrow Frequency") {
                float arrowFreq = arrowController.arrowFrequency - 100;
                textUI.text = arrowFreq.ToString();
            }
            else if (LayoutItem.name == "Arrow Speed") {
                textUI.text = arrowController.speed.ToString();
            }
        }
        if (type == "sword") {
            if (LayoutItem.name == "Sword Count") {
                textUI.text = swordController.swordCount.ToString();
            } else if (LayoutItem.name == "Sword Countdown") {
                textUI.text = "-" + swordController.attackFrequency.ToString();
            } else if (LayoutItem.name == "Sword Damage") {
                textUI.text = swordController.damage.ToString();
            } else if (LayoutItem.name == "Sword Distance") {
                textUI.text = swordController.attackDistance.ToString();
            } else if (LayoutItem.name == "Sword Speed") {
                textUI.text = swordController.moveSpeed.ToString();
            }
        }
        if (type == "unique") {
            if (LayoutItem.name == "Crit Glasses") {
                textUI.text = "Lvl " + arrowController.levelCritGlasses.ToString();
            } else if (LayoutItem.name == "Impact Belt") {
                textUI.text = "Lvl " + playerController.levelBelt.ToString();
            } else if (LayoutItem.name == "Lifesteal Necklace") {
                textUI.text = "Lvl " + arrowController.levelLifeSteal.ToString();
            } else if (LayoutItem.name == "Speedy Cape") {
                textUI.text = "Lvl " + arrowController.levelSpeedCape.ToString();
            }
        }
        if (type == "pet") {
            if (LayoutItem.name == "Dragon") {
                textUI.text = "Lvl " + dragonController.dragonCount.ToString(); // sai phải lấy lvl fireball
            } else if (LayoutItem.name == "Wolf") {
                textUI.text = "Lvl " + wolfController.level.ToString();
            } 
        }

    }
}
