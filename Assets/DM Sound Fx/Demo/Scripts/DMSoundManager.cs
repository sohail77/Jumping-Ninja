using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DMSoundManager : MonoBehaviour {

	//List sounds for random selecting and play
	public AudioClip[] listOfHoverSounds;

	//Text UI component for show name current Audio Clip
	public Text statusText;

	//Play when new bonus came to scene
	public AudioClip[] surpriseAudioClips;
	//Play when new enemy came to scene
	public AudioClip[] attentionAudioClips;

	//Audio Source for play random selected Audio Clip
	AudioSource audioSourceComponent;

	// Use this for initialization
	void Start () {
		audioSourceComponent = GetComponent<AudioSource>();
	}

	public void PlayRandomHowerSound() {
		if (listOfHoverSounds != null) {
			int randomSoundNumber = Random.Range (0, listOfHoverSounds.Length);

			AudioClip clipForPlay = listOfHoverSounds [randomSoundNumber];

			PlayStatusSound (clipForPlay);

			if (statusText != null) {
				//Show text with name of Audio Clip
				statusText.text = "Now Playing: " + clipForPlay.ToString();
			}
		}
	}

	private void PlayStatusSound(AudioClip audioClip) {
		if (audioClip != null) {
			audioSourceComponent.clip = audioClip;
			audioSourceComponent.Play ();
		}
	}

	public void PlayAttentionSound() {
		if (attentionAudioClips != null && attentionAudioClips.Length > 0) {
			PlayStatusSound (attentionAudioClips [Random.Range (0, attentionAudioClips.Length)]);
		}
	}

	public void PlaySurpriseSound() {
		if (surpriseAudioClips != null && surpriseAudioClips.Length > 0) {
			PlayStatusSound (surpriseAudioClips [Random.Range (0, surpriseAudioClips.Length)]);
		}
	}

}
