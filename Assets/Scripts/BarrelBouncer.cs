using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBouncer : MonoBehaviour
{
    public AnimationCurve myCurve;
    public int liters = 10;

    
    void Start()
    {
        //barrel = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AccelerometerMovement.litersRemain = AccelerometerMovement.litersRemain + liters;
            Destroy(this.gameObject);
        }
    }
}
