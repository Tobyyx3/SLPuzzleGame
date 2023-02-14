using System;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    void Start()
    {
        LevelConfigsClass levelConfigsInJson = JsonUtility.FromJson<LevelConfigsClass>(LoadConfigJson());

        foreach (LevelConfig levelConfig in levelConfigsInJson.LevelConfigs)
        {
            Debug.Log($"Folgende Configs geladen: Level1: {levelConfig.Level1}, Level2: {levelConfig.Level2}, Level3: {levelConfig.Level3}");
        }
    }

    public static String LoadConfigJson()
    {
        var jsonTextFile = Resources.Load<TextAsset>("levelConfig");

        return jsonTextFile.text;
    }
}