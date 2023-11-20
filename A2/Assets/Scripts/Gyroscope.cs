using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    void Start()
    {
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        Debug.Log(Input.gyro.attitude);
        transform.rotation = GyroUnity(Input.gyro.attitude);
    }

    private Quaternion GyroUnity(Quaternion q)
    {
        return new Quaternion(0, q.y, -q.z, q.w);
        //return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
