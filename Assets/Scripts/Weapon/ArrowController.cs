using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{


    [SerializeField] private BaseItem arrow;
    [SerializeField] private BaseItem_critValue critGlasses;
    [SerializeField] private BaseItem_Support SpeedyCape;

    public float speed;
    public int Damage;
    public float maxDistance;
    public float arrowFrequency;
    public int level;
    public int levelCritGlasses;
    public int levelSpeedCape;
    public int count;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float distanceTravelled = Vector3.Distance(startPosition, transform.position);

        
        if (distanceTravelled >= maxDistance) {
            
            Destroy(gameObject);
        }

    }


    public int GetArrowDamage() {


        
        int totalDamage = critGlasses.totalDamage(Damage, levelCritGlasses);
        int bonusDamage = (int) SpeedyCape.BonusDamage( speed, levelSpeedCape);

        Debug.Log(bonusDamage + "duoc nhan them");

        // Giảm dmg sau gây dmg lần đầu đi 90%
        Damage = (int) ((float)Damage * 0.1f);


        return totalDamage + bonusDamage;

    }

    public float GetArrowFrequency() { return arrowFrequency; }

    public void InitializeArrowProperties() {
        if (arrow == null) {
            return;
        }
        levelCritGlasses = critGlasses.level;
        levelSpeedCape = SpeedyCape.level;

        speed = arrow.speed;
        maxDistance = arrow.maxDistance;
        level = arrow.level;
        Damage = (int)arrow.damageByLevel[level];
        arrowFrequency = arrow.frequencyByLevel[level];
        count = (int)arrow.countByLevel[level];



    }
}
