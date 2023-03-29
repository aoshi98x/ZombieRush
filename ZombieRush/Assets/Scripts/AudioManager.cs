using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxAudioSource;
    public static AudioManager Instance {get; private set;}
    // Start is called before the first frame update
    private void Awake() {
        
        if(Instance!= null && Instance!= this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }
    
}
