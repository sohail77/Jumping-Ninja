using UnityEngine;
using System.Collections;

public class DMHeroSoundSystem : MonoBehaviour {
	//Play when user take coin
	public AudioClip[] coinAudioClips;

	//Play when user touch flame and lost life
	public AudioClip[] lostAudioClips;

	//Play when drop man jump
	public AudioClip[] jumpAudioClips;

	//Play when drop man run
	public AudioClip[] runFootStepsAudioClips;

	//Audio Source for play random selected Audio Clip
	AudioSource audioSourceComponent;

	// Use this for initialization
	void Start () {
		audioSourceComponent = GetComponent<AudioSource>();
	}

	public void PlayCoinSound() {
		if (coinAudioClips != null && coinAudioClips.Length > 0) {
			PlayStatusSound (coinAudioClips [Random.Range (0, coinAudioClips.Length)]);
		}
	}

	public void PlayLostSound() {
		if (lostAudioClips != null && lostAudioClips.Length > 0) {
			PlayStatusSound (lostAudioClips [Random.Range (0, lostAudioClips.Length)]);
		}
	}

	public void PlayJumpSound() {
		if (jumpAudioClips != null && jumpAudioClips.Length > 0) {
			PlayStatusSound (jumpAudioClips [Random.Range (0, jumpAudioClips.Length)]);
		}
	}

	//Play Foot Steps sounds
	public void PlayRunSound() {
		if (runFootStepsAudioClips != null && runFootStepsAudioClips.Length > 0) {
			if (!audioSourceComponent.isPlaying) {
				PlayStatusSound (runFootStepsAudioClips [Random.Range (0, runFootStepsAudioClips.Length)]);
			}
		}
	}

	//Play Audio Clip on current Audio Source, what attached to Player
	void PlayStatusSound(AudioClip audioClip) {
		if (audioSourceComponent != null && audioClip != null) {
			audioSourceComponent.clip = audioClip;
			audioSourceComponent.Play ();
		}
	}
}
