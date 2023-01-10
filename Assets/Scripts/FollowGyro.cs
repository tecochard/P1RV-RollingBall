using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    // Script to access and use the data of the gyroscope
    // Makes the GyroController rotate following the smartphone's rotation
    private Quaternion quaterIni;
    public float angleMax = 30.0f;

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    public Quaternion Calibrage()
    {
        return quaterIni;
    }

    private void Update()
    {
        // On reattribue les rotations pour qu'elles correspondent au bon angle avec le telephone à plat
        Quaternion quater;
        quater.x = -GyroManager.Instance.GetGyroRotation().x;
        quater.y = -GyroManager.Instance.GetGyroRotation().z;
        quater.z = -GyroManager.Instance.GetGyroRotation().y;
        quater.w = GyroManager.Instance.GetGyroRotation().w;

        // On enlève la rotation selon l'axe y
        Vector3 nouv = new Vector3(quater.eulerAngles.x, 0.0f, quater.eulerAngles.z);
 
        // Les conditions servent à limiter les rotations à un certain angle
        if (quater.eulerAngles.x > angleMax && quater.eulerAngles.x <= 180.0f)
        {
            nouv.x = angleMax;
        }
        if (quater.eulerAngles.x < 360.0f - angleMax && quater.eulerAngles.x >= 180.0f)
        {
            nouv.x = 360.0f - angleMax;
        }
        if (quater.eulerAngles.z > angleMax && quater.eulerAngles.z <= 180.0f)
        {
            nouv.z = angleMax;
        }
        if (quater.eulerAngles.z < 360.0f - angleMax && quater.eulerAngles.z >= 180.0f)
        {
            nouv.z = 360.0f - angleMax;
        }

        // on applique enfin la rotation au GyroController
        transform.localRotation = Quaternion.Euler(nouv);
    }
}
