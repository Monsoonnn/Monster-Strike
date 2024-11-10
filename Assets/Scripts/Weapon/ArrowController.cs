using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{


    [SerializeField] private BaseItem arrow;


    public float speed;
    public int Damage;
    public float maxDistance;
    public float arrowFrequency;

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
        return Damage;
    }

    public float GetArrowFrequency() { return arrowFrequency; }

    public void InitializeArrowProperties() {
        if (arrow == null) {
            return;
        }

        
        speed = arrow.speed;
        Damage = (int)arrow.damage;
        maxDistance = arrow.maxDistance;
        arrowFrequency = arrow.frequency;

    }
}
