using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Timers;

public class RealisticCarController : MonoBehaviour
{
    public Rigidbody car;
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public float maxSteerAngle = 30;
    public float motorForce = 35;

    private float m_horizontalInput;
    public static float m_verticalInput;
    private float m_steeringAngle;
    public int Brakes;

    public static float carSpeed;

    private static Timer endTutorialTimer;
    private static bool endTutorialBool = false;

    public static int overSpeedCounter = 0;
    public static bool overSpeedBool = false;

    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("This should only print for the tutorial scene!!!!!!!!!!!!");
            endTutorialTimer = new System.Timers.Timer();
            endTutorialTimer.Interval = 120000;

            endTutorialTimer.Elapsed += OnTimedEvent;
            endTutorialTimer.AutoReset = true;
            endTutorialTimer.Enabled = true;
        }
    }

    private void Update()
    {
        if (endTutorialBool)
        {
            endTutorialBool = false;
            SceneManager.LoadScene(0);
        }
    }

    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {

        Debug.Log("ENDING TUTORIAL..................");
        endTutorialTimer.Enabled = false;
        endTutorialBool = true;


    }


    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }


    public void GetInput()
    {

        /* STEERING INPUT DETECTION */
        m_horizontalInput = Input.GetAxis("Horizontal");


        //Decelerate if the vertical input isn't pressed
        if (Input.GetAxis("Vertical") == -1 && !Input.GetKey("joystick 1 button 4") && ((((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) <= 0))
        {
            Brakes = 0;
            frontDriverW.motorTorque = 500;
            frontPassengerW.motorTorque = 500;
        }

        // REVERSAL CURRENTLY BROKEN
        else if (Input.GetKey("joystick 1 button 4"))
        {
            //Debug.Log("Reversal Applied!");
            m_verticalInput = -60;
        }

        /* BRAKING INPUT DETECTION */
        else if (((((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) > 0))
        {
            int tempBrake = (int)(((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) * 12;
            if (tempBrake > 25)
            {
                Brakes = (int)(((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) * 12;
                //Debug.Log("Brakes Applied!");
            }
        }

        /* GAS INPUT DETECTION */
        else if (((Input.GetAxis("Vertical") + 1) * 50) > 0)
        {
            Brakes = 0;
            m_verticalInput = ((Input.GetAxis("Vertical") + 1) * 50);
        }
    }


    private void Steer()
    {

        //Debug.Log("Steering");
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;

    }

    private void Accelerate()
    {
        if (m_verticalInput < 10)
        {
            m_verticalInput = 0;
        }
        //Debug.Log("Accelerating forwards!");

        if (frontDriverW.rpm > 1000 || frontPassengerW.rpm > 1000)
        {
            if (!(Brakes > 0))
            {
                frontDriverW.motorTorque = 500;
                frontPassengerW.motorTorque = 500;
            }
        }
        else
        {
            frontDriverW.motorTorque = m_verticalInput * 10 * motorForce;
            frontPassengerW.motorTorque = m_verticalInput * 10 * motorForce;
            Debug.Log("Checking m_verticalInput in accelerate func: " + m_verticalInput);
            Debug.Log("Checking frontW_motorTorque in accelerate func: " + frontDriverW.motorTorque);
        }
    }

    private void Braking()
    {
        Debug.Log("In braking func(), brakes are: " + Brakes);
        frontDriverW.brakeTorque = Brakes * 6;
        rearDriverW.brakeTorque = Brakes * 6;
        frontPassengerW.brakeTorque = Brakes * 6;
        rearPassengerW.brakeTorque = Brakes * 6;

    }

    private void UpdateWheelPoses()
    {
        //Debug.Log("Update Wheel Poses");
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void DetectInput()
    {
        Debug.Log(("Brakes are pressed at " + ((((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) + "%")));
        Debug.Log(("Gas is pressed at " + (Input.GetAxis("Vertical") + 1) * 50) + "%");
    }

    public double getSpeedMPH()
    {
        Debug.Log("SPEED IS....... " + (car.velocity.magnitude * 2.237f * .555555) + " mph");
        carSpeed = Mathf.Floor(car.velocity.magnitude * 2.237f * .555555f);
        GameObject.Find("SpeedDisplay").GetComponent<Text>().text = "" + carSpeed;
        if (carSpeed > 60)
        {
            if (overSpeedBool == false)
            {
                overSpeedCounter = overSpeedCounter + 1;
                overSpeedBool = true;
                GameObject.Find("SpeedDisplay").GetComponent<Text>().color = new Color(255, 0, 0);
            }


        }
        else
        {
            overSpeedBool = false;
            GameObject.Find("SpeedDisplay").GetComponent<Text>().color = new Color(255, 255, 255);
        }
        return (car.velocity.magnitude * 2.237f * .5555555);
    }

    private void FixedUpdate()
    {

        if (!((((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) == 50 && ((Input.GetAxis("Vertical") + 1) * 50) == 50))
        {
            if (Mathf.Abs(GameObject.Find("Tocus").transform.rotation.z) > 20)
            {
                Crash.EndGame();
            }
            DetectInput();
            GetInput();
            Steer();
            Accelerate();
            Braking();
            UpdateWheelPoses();
            getSpeedMPH();
        }
    }
}