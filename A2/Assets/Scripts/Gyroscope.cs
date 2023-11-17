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
    }
}
