using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Sound settings for the AudioManager, use (sound).source.[...] for changing the sound on runtime.
/// </summary>
[System.Serializable]
public class Sound {

	/// <summary>
	/// The name of the sound.
	/// </summary>
	public string name;

	/// <summary>
	/// The Audio Mixer Group that the sound is apart of.
	/// </summary>
	public AudioMixerGroup mixerGroup;

	/// <summary>
	/// The selected audio clip.
	/// </summary>
	public AudioClip clip;

	/// <summary>
	/// If not empty, the sound will use this source instead of creating a new one. Useful for custom sound settings.
	/// </summary>
    public AudioSource customAudioSource;

	/// <summary>
	/// The overall volume of the sound.
	/// </summary>
	[Range(0f, 1f)]
	public float volume = .75f;
	/// <summary>
	/// The amount of variation in volume of the sound, very buggy and unstable.
	/// </summary>
	[Range(0f, 1f)]
	public float volumeVariance = .1f;
	[HideInInspector] public float originalVolume;

	/// <summary>
	/// The overall pitch of the sound.
	/// </summary>
	[Range(.1f, 3f)]
	public float pitch = 1f;
	/// <summary>
	/// The amount of varition in pitch of the sound.
	/// </summary>
	[Range(0f, 1f)]
	public float pitchVariance = .1f;

	/// <summary>
	/// How "3D" the sound is.
	/// </summary>
	[Range(0f, 1f)]
	public float spatialBlend = 1f;

	/// <summary>
	/// Does the sound loop?
	/// </summary>
	public bool loop = false;
	/// <summary>
	/// Does the sound play on Awake?
	/// </summary>
	public bool playOnAwake = false;
	/// <summary>
	/// Does the sound bypass reverb zones?
	/// </summary>
    public bool bypassReverbZones = false;

	/// <summary>
	/// The sound's audio source, change this to modify the sound on runtime.
	/// </summary>
	[HideInInspector]
    public AudioSource source;

	/// <summary>
	/// Is the sound currently playing now?
	/// </summary>
	[HideInInspector]
    public bool isPlaying;
}
