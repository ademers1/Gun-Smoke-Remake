using UnityEngine;


[System.Serializable]
public class SourceForAudioHandler
{
    public string audioName;
    public AudioClip audioClip;


        [Range(.1f, 3f)]
        public float volumePitch;

            [Range(0f, 2f)]
            public float volumeLevel;

                public bool mute;

                    [HideInInspector]
                    public AudioSource source;





}
