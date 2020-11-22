using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    private AudioSource source;

    public float Volumn;
    public bool loop;

    public void Setsource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.volume = Volumn;
        source.loop = loop;
    }

    public void SetVolumn()
    {
        source.volume = Volumn;
    }

    public void Play()
    {
        source.PlayOneShot(clip);
    }

    public void Stop()
    {
        source.Stop();
    }
    public void SetLoop()
    {
        source.loop = true;
    }
    public void SetLoopCancel()
    {
        source.loop = false;
    }
}
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;
    public Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name);
            sounds[i].Volumn = scrollbar.value;
            sounds[i].Setsource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }

    public void Play(string _name)
    {
        for(int i = 0;i<sounds.Length; i++)
        {
            if(_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void SetLoop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoop();
                return;
            }
        }
    }
    public void SetLoopCancel(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoopCancel();
                return;
            }
        }
    }

    public void SetVolumn()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Volumn = scrollbar.value;
            sounds[i].SetVolumn();
        }
    }
}
