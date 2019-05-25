using System.Collections;਍甀猀椀渀最 匀礀猀琀攀洀⸀䌀漀氀氀攀挀琀椀漀渀猀⸀䜀攀渀攀爀椀挀㬀ഀഀ
using UnityEngine;਍甀猀椀渀最 唀渀椀琀礀䔀渀最椀渀攀⸀唀䤀㬀ഀഀ
using UnityEngine.SceneManagement;਍甀猀椀渀最 匀礀猀琀攀洀⸀吀椀洀攀爀猀㬀ഀഀ
਍瀀甀戀氀椀挀 挀氀愀猀猀 刀攀愀氀椀猀琀椀挀䌀愀爀䌀漀渀琀爀漀氀氀攀爀 㨀 䴀漀渀漀䈀攀栀愀瘀椀漀甀爀ഀഀ
{਍    瀀甀戀氀椀挀 刀椀最椀搀戀漀搀礀 挀愀爀㬀ഀഀ
    public WheelCollider frontDriverW, frontPassengerW;਍    瀀甀戀氀椀挀 圀栀攀攀氀䌀漀氀氀椀搀攀爀 爀攀愀爀䐀爀椀瘀攀爀圀Ⰰ 爀攀愀爀倀愀猀猀攀渀最攀爀圀㬀ഀഀ
    public Transform frontDriverT, frontPassengerT;਍    瀀甀戀氀椀挀 吀爀愀渀猀昀漀爀洀 爀攀愀爀䐀爀椀瘀攀爀吀Ⰰ 爀攀愀爀倀愀猀猀攀渀最攀爀吀㬀ഀഀ
਍    瀀甀戀氀椀挀 昀氀漀愀琀 洀愀砀匀琀攀攀爀䄀渀最氀攀 㴀 ㌀　㬀ഀഀ
    public float motorForce = 35;਍ഀഀ
    private float m_horizontalInput;਍    瀀甀戀氀椀挀 猀琀愀琀椀挀 昀氀漀愀琀 洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀㬀ഀഀ
    private float m_steeringAngle;਍    瀀甀戀氀椀挀 椀渀琀 䈀爀愀欀攀猀㬀ഀഀ
਍    瀀甀戀氀椀挀 猀琀愀琀椀挀 昀氀漀愀琀 挀愀爀匀瀀攀攀搀㬀ഀഀ
਍    瀀爀椀瘀愀琀攀 猀琀愀琀椀挀 吀椀洀攀爀 攀渀搀吀甀琀漀爀椀愀氀吀椀洀攀爀㬀ഀഀ
    private static bool endTutorialBool = false;਍ഀഀ
    private void Start()਍    笀ഀഀ
        ਍        椀昀 ⠀匀挀攀渀攀䴀愀渀愀最攀爀⸀䜀攀琀䄀挀琀椀瘀攀匀挀攀渀攀⠀⤀⸀戀甀椀氀搀䤀渀搀攀砀 㴀㴀 ㄀⤀ഀഀ
        {਍            䐀攀戀甀最⸀䰀漀最⠀∀吀栀椀猀 猀栀漀甀氀搀 漀渀氀礀 瀀爀椀渀琀 昀漀爀 琀栀攀 琀甀琀漀爀椀愀氀 猀挀攀渀攀℀℀℀℀℀℀℀℀℀℀℀℀∀⤀㬀ഀഀ
            endTutorialTimer = new System.Timers.Timer();਍            攀渀搀吀甀琀漀爀椀愀氀吀椀洀攀爀⸀䤀渀琀攀爀瘀愀氀 㴀 ㄀㈀　　　　㬀ഀഀ
਍            攀渀搀吀甀琀漀爀椀愀氀吀椀洀攀爀⸀䔀氀愀瀀猀攀搀 ⬀㴀 伀渀吀椀洀攀搀䔀瘀攀渀琀㬀ഀഀ
            endTutorialTimer.AutoReset = true;਍            攀渀搀吀甀琀漀爀椀愀氀吀椀洀攀爀⸀䔀渀愀戀氀攀搀 㴀 琀爀甀攀㬀ഀഀ
        }਍    紀ഀഀ
਍    瀀爀椀瘀愀琀攀 瘀漀椀搀 唀瀀搀愀琀攀⠀⤀ഀഀ
    {਍        椀昀 ⠀攀渀搀吀甀琀漀爀椀愀氀䈀漀漀氀⤀ഀഀ
        {਍            攀渀搀吀甀琀漀爀椀愀氀䈀漀漀氀 㴀 昀愀氀猀攀㬀ഀഀ
            SceneManager.LoadScene(0);਍        紀ഀഀ
    }਍ഀഀ
    private static void OnTimedEvent(object sender, ElapsedEventArgs e)਍    笀ഀഀ
        ਍            䐀攀戀甀最⸀䰀漀最⠀∀䔀一䐀䤀一䜀 吀唀吀伀刀䤀䄀䰀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀⸀∀⤀㬀ഀഀ
            endTutorialTimer.Enabled = false;਍            攀渀搀吀甀琀漀爀椀愀氀䈀漀漀氀 㴀 琀爀甀攀㬀ഀഀ
਍        ഀഀ
    }਍ഀഀ
਍    瀀爀椀瘀愀琀攀 瘀漀椀搀 唀瀀搀愀琀攀圀栀攀攀氀倀漀猀攀⠀圀栀攀攀氀䌀漀氀氀椀搀攀爀 开挀漀氀氀椀搀攀爀Ⰰ 吀爀愀渀猀昀漀爀洀 开琀爀愀渀猀昀漀爀洀⤀ഀഀ
    {਍        嘀攀挀琀漀爀㌀ 开瀀漀猀 㴀 开琀爀愀渀猀昀漀爀洀⸀瀀漀猀椀琀椀漀渀㬀ഀഀ
        Quaternion _quat = _transform.rotation;਍ഀഀ
        _collider.GetWorldPose(out _pos, out _quat);਍ഀഀ
        _transform.position = _pos;਍        开琀爀愀渀猀昀漀爀洀⸀爀漀琀愀琀椀漀渀 㴀 开焀甀愀琀㬀ഀഀ
    }਍ഀഀ
਍    瀀甀戀氀椀挀 瘀漀椀搀 䜀攀琀䤀渀瀀甀琀⠀⤀ഀഀ
    {਍ഀഀ
        /* STEERING INPUT DETECTION */਍        洀开栀漀爀椀稀漀渀琀愀氀䤀渀瀀甀琀 㴀 䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀䠀漀爀椀稀漀渀琀愀氀∀⤀㬀ഀഀ
਍ഀഀ
        //Decelerate if the vertical input isn't pressed਍        椀昀 ⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀嘀攀爀琀椀挀愀氀∀⤀ 㴀㴀 ⴀ㄀ ☀☀ ℀䤀渀瀀甀琀⸀䜀攀琀䬀攀礀⠀∀樀漀礀猀琀椀挀欀 ㄀ 戀甀琀琀漀渀 㐀∀⤀ ☀☀ ⠀⠀⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀䴀漀甀猀攀 匀挀爀漀氀氀圀栀攀攀氀∀⤀⤀ ⨀ ⴀ㔀　　⤀ ⬀ 㔀　⤀ 㰀㴀 　⤀⤀ഀഀ
        {਍            䈀爀愀欀攀猀 㴀 　㬀ഀഀ
            m_verticalInput = 8;਍        紀ഀഀ
਍        ⼀⼀ 刀䔀嘀䔀刀匀䄀䰀 䌀唀刀刀䔀一吀䰀夀 䈀刀伀䬀䔀一ഀഀ
        else if (Input.GetKey("joystick 1 button 4"))਍        笀ഀഀ
            //Debug.Log("Reversal Applied!");਍            洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 㴀 ⴀ㘀　㬀ഀഀ
        }਍ഀഀ
        /* BRAKING INPUT DETECTION */਍        攀氀猀攀 椀昀 ⠀⠀⠀⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀䴀漀甀猀攀 匀挀爀漀氀氀圀栀攀攀氀∀⤀⤀ ⨀ ⴀ㔀　　⤀ ⬀ 㔀　⤀ 㸀 　⤀⤀ഀഀ
        {਍            椀渀琀 琀攀洀瀀䈀爀愀欀攀 㴀 ⠀椀渀琀⤀⠀⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀䴀漀甀猀攀 匀挀爀漀氀氀圀栀攀攀氀∀⤀⤀ ⨀ ⴀ㔀　　⤀ ⬀ 㔀　⤀ ⨀ ㄀㈀㬀ഀഀ
            if (tempBrake > 25)਍            笀ഀഀ
                Brakes = (int)(((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) * 12;਍                ⼀⼀䐀攀戀甀最⸀䰀漀最⠀∀䈀爀愀欀攀猀 䄀瀀瀀氀椀攀搀℀∀⤀㬀ഀഀ
            }਍        紀ഀഀ
਍        ⼀⨀ 䜀䄀匀 䤀一倀唀吀 䐀䔀吀䔀䌀吀䤀伀一 ⨀⼀ഀഀ
        else if (((Input.GetAxis("Vertical") + 1) * 50) > 0)਍        笀ഀഀ
            Brakes = 0;਍            洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 㴀 ⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀嘀攀爀琀椀挀愀氀∀⤀ ⬀ ㄀⤀ ⨀ 㔀　⤀㬀ഀഀ
        }਍    紀ഀഀ
਍ഀഀ
    private void Steer()਍    笀ഀഀ
਍        ⼀⼀䐀攀戀甀最⸀䰀漀最⠀∀匀琀攀攀爀椀渀最∀⤀㬀ഀഀ
        m_steeringAngle = maxSteerAngle * m_horizontalInput;਍        昀爀漀渀琀䐀爀椀瘀攀爀圀⸀猀琀攀攀爀䄀渀最氀攀 㴀 洀开猀琀攀攀爀椀渀最䄀渀最氀攀㬀ഀഀ
        frontPassengerW.steerAngle = m_steeringAngle;਍ഀഀ
    }਍ഀഀ
    private void Accelerate()਍    笀ഀഀ
਍        ⼀⼀䐀攀戀甀最⸀䰀漀最⠀∀䄀挀挀攀氀攀爀愀琀椀渀最 昀漀爀眀愀爀搀猀℀∀⤀㬀ഀഀ
        frontDriverW.motorTorque = m_verticalInput * motorForce;਍        昀爀漀渀琀倀愀猀猀攀渀最攀爀圀⸀洀漀琀漀爀吀漀爀焀甀攀 㴀 洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 ⨀ 洀漀琀漀爀䘀漀爀挀攀㬀ഀഀ
        Debug.Log("Checking m_verticalInput in accelerate func: " + m_verticalInput);਍        䐀攀戀甀最⸀䰀漀最⠀∀䌀栀攀挀欀椀渀最 昀爀漀渀琀圀开洀漀琀漀爀吀漀爀焀甀攀 椀渀 愀挀挀攀氀攀爀愀琀攀 昀甀渀挀㨀 ∀ ⬀ 昀爀漀渀琀䐀爀椀瘀攀爀圀⸀洀漀琀漀爀吀漀爀焀甀攀⤀㬀ഀഀ
਍        ⼀⨀攀氀猀攀 椀昀 ⠀洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 㰀 　⤀ഀഀ
        {਍        笀ഀഀ
            Debug.Log("Accelerating backwards!");਍ഀഀ
            frontDriverW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;਍            昀爀漀渀琀倀愀猀猀攀渀最攀爀圀⸀洀漀琀漀爀吀漀爀焀甀攀 㴀 洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 ⨀ 洀漀琀漀爀䘀漀爀挀攀 ⨀ 吀椀洀攀⸀搀攀氀琀愀吀椀洀攀㬀ഀഀ
            rearDriverW.motorTorque = m_verticalInput * motorForce * Time.deltaTime;਍            爀攀愀爀倀愀猀猀攀渀最攀爀圀⸀洀漀琀漀爀吀漀爀焀甀攀 㴀 洀开瘀攀爀琀椀挀愀氀䤀渀瀀甀琀 ⨀ 洀漀琀漀爀䘀漀爀挀攀 ⨀ 吀椀洀攀⸀搀攀氀琀愀吀椀洀攀㬀ഀഀ
            Debug.Log("Checking motorForce: " + motorForce);਍            䐀攀戀甀最⸀䰀漀最⠀∀䌀栀攀挀欀椀渀最 昀爀漀渀琀圀开洀漀琀漀爀吀漀爀焀甀攀㨀 ∀ ⬀ 昀爀漀渀琀䐀爀椀瘀攀爀圀⸀洀漀琀漀爀吀漀爀焀甀攀⤀㬀ഀഀ
        }*/਍    紀ഀഀ
਍    瀀爀椀瘀愀琀攀 瘀漀椀搀 䈀爀愀欀椀渀最⠀⤀ഀഀ
    {਍        䐀攀戀甀最⸀䰀漀最⠀∀䤀渀 戀爀愀欀椀渀最 昀甀渀挀⠀⤀Ⰰ 戀爀愀欀攀猀 愀爀攀㨀 ∀ ⬀ 䈀爀愀欀攀猀⤀㬀ഀഀ
        frontDriverW.brakeTorque = Brakes*2;਍        爀攀愀爀䐀爀椀瘀攀爀圀⸀戀爀愀欀攀吀漀爀焀甀攀 㴀 䈀爀愀欀攀猀⨀㈀㬀ഀഀ
        frontPassengerW.brakeTorque = Brakes*2;਍        爀攀愀爀倀愀猀猀攀渀最攀爀圀⸀戀爀愀欀攀吀漀爀焀甀攀 㴀 䈀爀愀欀攀猀⨀㈀㬀ഀഀ
਍    紀ഀഀ
਍    瀀爀椀瘀愀琀攀 瘀漀椀搀 唀瀀搀愀琀攀圀栀攀攀氀倀漀猀攀猀⠀⤀ഀഀ
    {਍        ⼀⼀䐀攀戀甀最⸀䰀漀最⠀∀唀瀀搀愀琀攀 圀栀攀攀氀 倀漀猀攀猀∀⤀㬀ഀഀ
        UpdateWheelPose(frontDriverW, frontDriverT);਍        唀瀀搀愀琀攀圀栀攀攀氀倀漀猀攀⠀昀爀漀渀琀倀愀猀猀攀渀最攀爀圀Ⰰ 昀爀漀渀琀倀愀猀猀攀渀最攀爀吀⤀㬀ഀഀ
        UpdateWheelPose(rearDriverW, rearDriverT);਍        唀瀀搀愀琀攀圀栀攀攀氀倀漀猀攀⠀爀攀愀爀倀愀猀猀攀渀最攀爀圀Ⰰ 爀攀愀爀倀愀猀猀攀渀最攀爀吀⤀㬀ഀഀ
    }਍ഀഀ
    private void DetectInput()਍    笀ഀഀ
        Debug.Log(("Brakes are pressed at " + ((((Input.GetAxis("Mouse ScrollWheel")) * -500) + 50) + "%")));਍        䐀攀戀甀最⸀䰀漀最⠀⠀∀䜀愀猀 椀猀 瀀爀攀猀猀攀搀 愀琀 ∀ ⬀ ⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀嘀攀爀琀椀挀愀氀∀⤀ ⬀ ㄀⤀ ⨀ 㔀　⤀ ⬀ ∀─∀⤀㬀ഀഀ
    }਍ഀഀ
	public double getSpeedMPH(){਍ऀऀ䐀攀戀甀最⸀䰀漀最⠀∀匀倀䔀䔀䐀 䤀匀⸀⸀⸀⸀⸀⸀⸀ ∀ ⬀ ⠀挀愀爀⸀瘀攀氀漀挀椀琀礀⸀洀愀最渀椀琀甀搀攀 ⨀ ㈀⸀㈀㌀㜀昀⤀ ⬀ ∀ 洀瀀栀∀⤀㬀ഀഀ
        carSpeed = (car.velocity.magnitude * 2.237f);਍        䜀愀洀攀伀戀樀攀挀琀⸀䘀椀渀搀⠀∀匀瀀攀攀搀䐀椀猀瀀氀愀礀∀⤀⸀䜀攀琀䌀漀洀瀀漀渀攀渀琀㰀吀攀砀琀㸀⠀⤀⸀琀攀砀琀 㴀 ∀∀ ⬀ 挀愀爀匀瀀攀攀搀㬀ഀഀ
        return (car.velocity.magnitude * 2.237f);਍ऀ紀ഀഀ
਍    瀀爀椀瘀愀琀攀 瘀漀椀搀 䘀椀砀攀搀唀瀀搀愀琀攀⠀⤀ഀഀ
    {	਍        椀昀 ⠀℀⠀⠀⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀䴀漀甀猀攀 匀挀爀漀氀氀圀栀攀攀氀∀⤀⤀ ⨀ ⴀ㔀　　⤀ ⬀ 㔀　⤀ 㴀㴀 㔀　 ☀☀ ⠀⠀䤀渀瀀甀琀⸀䜀攀琀䄀砀椀猀⠀∀嘀攀爀琀椀挀愀氀∀⤀ ⬀ ㄀⤀ ⨀ 㔀　⤀ 㴀㴀 㔀　⤀⤀ഀഀ
        {           ਍            䐀攀琀攀挀琀䤀渀瀀甀琀⠀⤀㬀ഀഀ
            GetInput();਍            匀琀攀攀爀⠀⤀㬀ഀഀ
            Accelerate();਍            䈀爀愀欀椀渀最⠀⤀㬀ഀഀ
            UpdateWheelPoses();਍ऀऀऀ最攀琀匀瀀攀攀搀䴀倀䠀⠀⤀㬀ഀഀ
        }਍    紀ഀഀ
}