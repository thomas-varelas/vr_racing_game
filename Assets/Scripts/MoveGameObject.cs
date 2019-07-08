using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObject : MonoBehaviour
{

    public float speedMin=10f;
    public float speedMax=30f;
    private float speed;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = new Vector3(0, 0, -1) * speed;
        rb.AddForce(Vector3.back * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AccelerometerMovement.TurnOnPanel();
        }
    }

}
