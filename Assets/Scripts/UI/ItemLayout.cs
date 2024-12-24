using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLayout : MonoBehaviour {

    [SerializeField] private List<GameObject> LayoutGrid;


    public List<LayoutItem> arrowSpriteItem;
    public List<LayoutItem> swordSpriteItem;
    public List<LayoutItem> uniqueSpriteItem;
    public List<LayoutItem> petSpriteItem;

    public GameObject GameChoiceUI;


    void Start() {
        InitItem();
    }

    void InitItem() {

        foreach (var item in arrowSpriteItem) {


            GameObject itemChoice = Instantiate(GameChoiceUI, transform.GetChild(0).position, transform.GetChild(0).rotation, transform.GetChild(0).transform);

            GameChoiceUI uiController = itemChoice.GetComponent<GameChoiceUI>();

            uiController.intItem(item, "arrow");

        }
        foreach (var item in swordSpriteItem) {


            GameObject itemChoice = Instantiate(GameChoiceUI, transform.GetChild(1).position, transform.GetChild(1).rotation, transform.GetChild(1).transform);

            GameChoiceUI uiController = itemChoice.GetComponent<GameChoiceUI>();

            uiController.intItem(item, "sword");

        }

        foreach (var item in uniqueSpriteItem) {


            GameObject itemChoice = Instantiate(GameChoiceUI, transform.GetChild(2).position, transform.GetChild(2).rotation, transform.GetChild(2).transform);

            GameChoiceUI uiController = itemChoice.GetComponent<GameChoiceUI>();

            uiController.intItem(item, "unique");

        }
        foreach (var item in petSpriteItem) {


            GameObject itemChoice = Instantiate(GameChoiceUI, transform.GetChild(3).position, transform.GetChild(3).rotation, transform.GetChild(3).transform);

            GameChoiceUI uiController = itemChoice.GetComponent<GameChoiceUI>();

            uiController.intItem(item, "pet");

        }



    } 
    private void Update() {
        

    }


}
