using JetBrains.Annotations;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    [Header("Level Data Reference", order = 0)] [NotNull]
    public GameData Level_1_Data;
    public GameData Level_2_Data;
    public GameData Level_3_Data;
    public GameData Level_4_Data;
    public GameData Level_5_Data;
    
    
    [Header("Audio Data", order = 1)]
    public SoundAudioClip[] SoundAudioClipsArray;
    
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound Sound;
        public AudioClip AudioClip;
    }
}