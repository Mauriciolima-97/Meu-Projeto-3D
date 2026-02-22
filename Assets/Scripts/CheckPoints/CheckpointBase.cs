using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int Key = 01;

    private bool checkpointActived = false;

    private string checkpointKey = "CheckpointKey";

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();

        if (!checkpointActived && player != null)
        {
            CheckCheckpoint();
        }
    }

    private void CheckCheckpoint()
    {
        TurnItOn();
        SaveCheckpoint();
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

    private void SaveCheckpoint()
    {
        if (PlayerPrefs.GetInt(checkpointKey, 0) > Key)
        PlayerPrefs.SetInt(checkpointKey, Key);

        CheckpointManager.Instance.SaveCheckPoint(Key);

        checkpointActived = true;
    }
}
