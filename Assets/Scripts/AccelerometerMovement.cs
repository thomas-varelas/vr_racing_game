using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerMovement : MonoBehaviour
{
    public bool isFlat = true;
    public float speed = 10f;

    public Text scoreText;
    public Text barelsText;

    private float dirX;
    private Rigidbody rigd;
    private Gyroscope gyro;

    public static float mainScore;
    private float nextLiterLoss = 0.0f;
    public float period = 0.1f;
    public static int litersRemain;



    public GameObject panel;
    static GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        litersRemain = 5;
        pausePanel = panel;
        mainScore = 0;
        UpdateScore(0);
        rigd = GetComponent<Rigidbody>();
        gyro = Input.gyro;
        if (!gyro.enabled)
        {
            gyro.enabled = true;
        }
    }

    void FixedUpdate()
    {
        /*float moveH = Input.gyro.userAcceleration.x;
        float moveV = Input.gyro.userAcceleration.y;

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rigd.AddForce(movement * speed * 2);*/
        rigd.velocity = new Vector3(dirX, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y,transform.position.z);
        mainScore += Time.deltaTime;
        UpdateScore(mainScore);
        if (Time.time > nextLiterLoss)
        {
            nextLiterLoss += period;
            litersRemain = litersRemain - 1;
        }
        if (litersRemain <= 0)
        {
            TurnOnPanel();
        }
        UpdateLiters();
        //rigd.AddForce(gyro.attitude * speed * Time.deltaTime;);
        //Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
    }

    Quaternion GyroToUnity(Quaternion quat)
    {
        return new Quaternion(quat.x, quat.z, quat.y, -quat.w);
    }

    void UpdateScore(float mainScore)
    {
        scoreText.text = Mathf.RoundToInt(mainScore*2.8f) + " m";
    }

    public static void TurnOnPanel()
    {
        pausePanel.SetActive(true);
    }

    public static void TurnOffPanel()
    {
        pausePanel.SetActive(false);
    }

    void UpdateLiters()
    {
        barelsText.text = litersRemain + " m";
    }


}
