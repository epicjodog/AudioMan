using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// What to do when there's a new measure
/// </summary>
public enum ActionsOnNewMeasure
{
	nothing,
	start,
	stop
}

/// <summary>
/// Music tracks for MusicEngine, use (music).source.[...] for changing the sound on runtime.
/// </summary>
[System.Serializable]
public class Music {

	/// <summary>
	/// The name of the music track.
	/// </summary>
	public string name;

	/// <summary>
	/// The Audio Mixer Group that the track is apart of.
	/// </summary>
	public AudioMixerGroup mixerGroup;

	/// <summary>
	/// The selected audio clip.
	/// </summary>
	public AudioClip clip;

	/// <summary>
	/// The overall volume of the track.
	/// </summary>
	[Range(0f, 1f)]
	public float volume = .75f;

	/// <summary>
	/// The BPM of the track
	/// </summary>
	public float BPM = 120;

	/// <summary>
	/// Does the track loop?
	/// </summary>
	public bool loop = true;
	/// <summary>
	/// Does the track play on Awake?
	/// </summary>
	public bool playOnAwake = false;



	/// <summary>
	/// The track's audio source, change this to modify the sound on runtime.
	/// </summary>
	[HideInInspector]
    public AudioSource source;

	/// <summary>
	/// Is the track currently playing now?
	/// </summary>
	[HideInInspector]
    public bool isPlaying;

	[HideInInspector]
	public ActionsOnNewMeasure onNewMeasure = ActionsOnNewMeasure.nothing;
}