using UnityEngine;
using Cinemachine;

public class CinemachineCameraShake : MonoBehaviour
{
    //public static CinemachineCameraShake instance;
    public CinemachineVirtualCamera cm;
    public float ShakeTimer;
    // Start is called before the first frame update
    void Awake()
    {
        CinemachineBasicMultiChannelPerlin cmvc = cm.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void CameraShake(float Intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cmvc = cm.GetComponent<CinemachineBasicMultiChannelPerlin>();
        //cmvc.m_AmplitudeGain = Intensity;
        ShakeTimer = time;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ShakeTimer > 0)
        {
            ShakeTimer -= Time.deltaTime;
            if (ShakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cmvc =cm.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cmvc.m_AmplitudeGain=0f;
            }
        }*/
    }
}
