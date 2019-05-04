using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealisticCarController : MonoBehaviour
{
    public Rigidbody car;
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public float maxSteerAngle = 30;
    public float motorForce = 1500;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public int Brakes;


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
        Brakes = 0;
        m_horizontalInput = Input.GetAxis("Horizontal");
        //Decelerate if the vertical input isn't pressed
        if (Input.GetAxis("Vertical") == -1 && !Input.GetKey("joystick 1 button 4"))
        {
            //m_verticalInput = 0;
            Brakes = 2000;
        }

        
        else if (Input.GetKey("joystick 1 button 4"))
        {
            Debug.Log("Reversal Applied!");
            m_verticalInput = -10;
        }
        //Brake
        else if (Input.GetAxis("Mouse ScrollWheel") != 0 && Input.GetAxis("Mouse ScrollWheel") != 0.1f)
        {
            //Debug.Log("Brakes Applied!");
            Brakes = 3000000;
        }
        else if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Vertical") != -1 && m_verticalInput < 10.19f)
        {
            m_verticalInput = Mathf.Abs(Input.GetAxis("Vertical")) * 10000f;
            Debug.Log("Checking m_verticalInput: " + m_verticalInput);
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

        if (Brakes == 0 && m_verticalInput >= 0)
        {            
            frontDriverW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;
            frontPassengerW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;
            Debug.Log("Checking m_verticalInput: " + m_verticalInput);
            Debug.Log("Checking frontW_motorTorque: " + frontDriverW.motorTorque);
        }
        else if (m_verticalInput < 0)
        {
            Debug.Log("Accelerating backwards!");

            frontDriverW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;
            frontPassengerW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;
            rearDriverW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;
            rearPassengerW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;

            Debug.Log("Checking frontW_motorTorque: " + frontDriverW.motorTorque);
        }
        else
        {
            //Debug.Log("Braking!");
            //motorForce = 0;
            frontDriverW.motorTorque = 0;
            frontPassengerW.motorTorque = 0;
        }
    }

    private void Braking()
    {
        frontDriverW.brakeTorque = Brakes;
        rearDriverW.brakeTorque = Brakes;
        frontPassengerW.brakeTorque = Brakes;
        rearPassengerW.brakeTorque = Brakes;
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
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
            {
                print("joystick 1 button " + i);
            }
        }

    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        Braking();
        UpdateWheelPoses();
    }
}