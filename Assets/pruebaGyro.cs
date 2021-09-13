////Attach this script to a GameObject in your Scene.
//using UnityEngine;


//public class GyroManager : MonoBehaviour
//{
//    #region Instance
//    private static GyroManager instance;
//    public static GyroManager Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType<GyroManager>();
//            }
//            if (instance == null)
//            {
//                instance = new GameObject("Spawned GyronManager", typeof(GyroManager)).GetComponent<GyroManager>();
//            }
//            return instance;
//        }
//        set
//        {
//            instance = value;
//        }

//    }
//    #endregion

//    [Header("Logic")]
//    private Gyroscope gyro;
//    private Quaternion rotation;
//    private bool gyroActive;

//    public void EnableGyro()
//    {
//        if (gyroActive)
//            return;
//        if (SystemInfo.supportsGyroscope)
//        {
//            gyro = Input.gyro;
//            gyro.enabled = true;
//        }
//        gyroActive = gyro.enabled;
//    }
//    public void Update()
//    {
//        if (gyroActive)
//        {
//            UnityEngine.Gyroscope gyroName = Input.gyro;
//            rotation = gyro.attitude;
//        }
//    }
//    public Quaternion GetGyroRotation()
//    {
//        return rotation;
//    }
//}