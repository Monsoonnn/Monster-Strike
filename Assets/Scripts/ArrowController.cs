using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    // V? sau thay th? b?ng scriptableObj
    public float arrowSpeed = 3f;
    public int Damage = 1;
    public float maxDistance = 5f;
    public float arrowFrequency = 1.2f;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);

        float distanceTravelled = Vector3.Distance(startPosition, transform.position);

        
        if (distanceTravelled >= maxDistance) {
            
            Destroy(gameObject);
        }

    }


    public int GetArrowDamage() { 
        return Damage;
    }

    public float GetArrowFrequency() { return arrowFrequency; }


}
