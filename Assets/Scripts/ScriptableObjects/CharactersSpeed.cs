using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersSpeed", menuName = "ScriptableObjects/CharactersSpeed")]
public class CharactersSpeed : ScriptableObject
{
    public GameMode[] GameModes;
    public float[] EnemySpeeds;
    public float PlayerSpeed;

    public Dictionary<GameMode, float> EnemySpeedDictionaty;

    public void InitEnemySpeedDictionary()
    {
        EnemySpeedDictionaty = new Dictionary<GameMode, float>();

        for (int i = 0; i < GameModes.Length; i++)
        {
            EnemySpeedDictionaty.Add(GameModes[i], EnemySpeeds[i]);
        }
    }
}
