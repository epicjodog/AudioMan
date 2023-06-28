/*
	Exit Light Framework Interactive Music Engine
        0.0.1 prototype
	Created by Josiah Holcom
*/
using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Manages interactive music in a scene, based on AudioMan logic.
/// </summary>
public class MusicEngine : MonoBehaviour
{
    /// <summary>
	/// Beats per minute, for the metronome
	/// </summary>
    [SerializeField] float BPM = 120f;
    /// <summary>
	/// The measure in X/4 (i.e. 4/4), for the metronome
	/// </summary>
    [SerializeField] int measure = 4;
    int currentMeasure = 0;

    [Header("Metronome")]
    [SerializeField] AudioClip metronomeTick;
    [SerializeField] AudioClip metronomeTock;
    /// <summary>
	/// Whether or not the metronome should play (only works once)
	/// </summary>
    [SerializeField] bool playMetronome;
    [SerializeField] AudioSource metronomeSource;

    [Header("Music Tracks")]
    public AudioMixerGroup mixerGroup;
	public Music[] tracks;

    // Start is called before the first frame update
    void Start()
    {
        //starts the metronome
        if(playMetronome && metronomeSource != null) StartCoroutine(Metronome());
        

    }

    void Awake()
	{
		foreach (Music m in tracks)
		{
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
			m.source.loop = m.loop;
            //if the music loops, it'll play
            if(m.loop) m.source.Play();
			
            m.source.playOnAwake = m.playOnAwake;
            //if POA, the volume will be set to its base volume
            if(m.playOnAwake) m.source.volume = m.volume;
            //if not, it'll be set to 0 but still play
            else m.source.volume = 0f;

            m.source.pitch = BPM / m.BPM;

			m.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
	/// Plays the selected track (or unmutes a looping track)
	/// </summary>
	/// <param name="music"></param>
	public void Play(string music)
	{
		Music m = Array.Find(tracks, item => item.name == music);
		if (m == null)
		{
			Debug.LogWarning("Track: " + music + " not found!");
			return;
		}

        if(m.loop) {m.source.volume = m.volume; m.isPlaying = true;}
        else m.source.Play();

        
	}

    /// <summary>
	/// Stops the selected track (or mutes a looping track)
	/// </summary>
	/// <param name="music"></param>
    public void Stop(string music)
	{
		Music m = Array.Find(tracks, item => item.name == music);
		if (m == null)
		{
			Debug.LogWarning("Track: " + music + " not found!");
			return;
		}

        if(m.loop) {m.source.volume = 0f; m.isPlaying = false;}
        else m.source.Stop();

        
	}


    IEnumerator Metronome()
    {
        while (playMetronome)
        {
            if(currentMeasure == 0) 
            {
                metronomeSource.clip = metronomeTick;
                onNewMeasure();
            }
            else metronomeSource.clip = metronomeTock;

            metronomeSource.Play();
            currentMeasure++;
            if(currentMeasure == measure) currentMeasure = 0;

            yield return new WaitForSeconds(1 / (BPM / 60f));
        }
    }

    void onNewMeasure()
    {
        foreach (Music m in tracks)
        {
            if(m.startOnNewMeasure) Play(m.name);
        }
    }
}
