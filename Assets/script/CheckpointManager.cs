using UnityEngine;
using System.IO;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 LastCheckpointPosition;

    public static void SetCheckpoint(Vector3 position)
    {
        LastCheckpointPosition = position;
        SaveCheckpointData();
    }

    private static void SaveCheckpointData()
    {
        CheckpointData data = new CheckpointData(LastCheckpointPosition);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText("checkpoint.json", json);
    }

    private void Start()
    {
        if (File.Exists("checkpoint.json"))
        {
            string json = File.ReadAllText("checkpoint.json");
            CheckpointData data = JsonUtility.FromJson<CheckpointData>(json);
            LastCheckpointPosition = data.Position;
        }
    }
}

[System.Serializable]
public class CheckpointData
{
    public Vector3 Position;

    public CheckpointData(Vector3 position)
    {
        Position = position;
    }
}


