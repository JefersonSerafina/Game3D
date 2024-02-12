using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cinemachine;

public class Shake : Singleton<Shake>
{
    public CinemachineVirtualCamera virtualCamera;

    public float shakeTime;

    [Header("Shake Values")]
    public float amplitude = 3f;
    public float frequency = 3f;
    public float time = 2f;

    [NaughtyAttributes.Button]
    public void Shakee()
    {
        ShakeCamera(amplitude, frequency, time);
    }

    public void ShakeCamera(float amplitude, float frequency, float time)
    {
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        shakeTime = time;
    }

    private void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
        }
    }
}
