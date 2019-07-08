using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Terrain targetterrain;
    public float speed=80f;
    public float roadDistance=550f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = targetterrain.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetterrain.transform.localPosition.z < -roadDistance)
        {
            targetterrain.transform.position = startPos;
        }
        targetterrain.transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
