using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed;
    public int damage;
    public float maxDistance;
    public float frequency;

    private Vector3 startPosition;
    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float distanceTravelled = Vector3.Distance(startPosition, transform.position);


        if (distanceTravelled >= maxDistance) {

            Destroy(gameObject);
        }

    }


    public int GetFireBallDamage() {
        return damage;
    }

    public float GetFireBallFrequency() { return frequency; }
}
