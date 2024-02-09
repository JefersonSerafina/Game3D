using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckpointKey = 0;
    public List<CheckPointBase> checkpoints;


    public bool HasCheckPoint()
    {
        return lastCheckpointKey > 0;
    }

    public void SaveCheckPoint(int i)
    {
        lastCheckpointKey = i;
    }

    public Vector3 GetPositionFromLastCheckpoint()
    {
        var checkpoint = checkpoints.Find( i => i.key == lastCheckpointKey );
        return checkpoint.transform.position;
    }

}
