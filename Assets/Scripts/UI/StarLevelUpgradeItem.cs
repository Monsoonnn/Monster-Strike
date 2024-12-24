using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StarLevelUpgradeItem : MonoBehaviour
{
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject  noneStar;


    public void InitStarItem(int starLevel) {


        int count = 0;

        for (int i = 0; i < starLevel; i++) {

            Instantiate(star, transform.position, Quaternion.identity, transform);
            count++;

        }

        while (count < 3) {
            Instantiate(noneStar, transform.position, Quaternion.identity, transform);
            count++;
        }

    }




}
