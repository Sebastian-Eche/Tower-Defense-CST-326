using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    public float shakeIntensity = 7;
    public float shakeDuration = 0.2f;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private float shakeTimer = 0;
    void Awake()
    {
        instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0;
    }
    public void ShakeCamera()
    {
        cbmcp.m_AmplitudeGain = shakeIntensity;
        shakeTimer = shakeDuration;
    }

    public void StopShakeCamera()
    {
        cbmcp.m_AmplitudeGain = 0f;
    }

    void Update()
    {
        while(shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                StopShakeCamera();
            }
        }
    }
    
}
