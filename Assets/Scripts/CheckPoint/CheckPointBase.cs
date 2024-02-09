using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

    public string checkPointKey = "CheckpointKey";

    private bool checkpointActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActived && other.transform.tag == "Player")
        {
            CheckCheckpoint();
        }
    }

    private void CheckCheckpoint()
    {
        SaveCheckPoint();
        TurnItOn();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckPoint()
    {
        //   if(PlayerPrefs.GetInt(checkPointKey, 0) > key)
        //     PlayerPrefs.SetInt(checkPointKey, key);

        CheckpointManager.Instance.SaveCheckPoint(key);

        checkpointActived = true;
    }

}
