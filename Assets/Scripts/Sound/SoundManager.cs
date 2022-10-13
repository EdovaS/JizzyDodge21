using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerDie,
        EnemyDie1,
        EnemyDie2,
        EnemyDie3
    }
    
    
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.SoundAudioClipsArray)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.AudioClip;
            }
        }
        Debug.LogError("Sound" + sound + " Not found!");
        return null;
    }
}
