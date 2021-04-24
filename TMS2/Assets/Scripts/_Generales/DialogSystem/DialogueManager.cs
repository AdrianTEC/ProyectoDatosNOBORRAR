using System.Collections;
using System.Collections.Generic;
using _Scripts._Generales;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public Canvas canvas;
	[Header("Options")]
	public Transform optionsBox;
	public GameObject buttonPrefab;
	public PlayableDirector cutScene;
	[Header("TextThings")]
	public AudioClip sound;
	private Queue<string> sentences;
	private bool open;
	private AudioSource audioSource;
	

	// Use this for initialization
	void Start (){
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		sentences = new Queue<string>();
		audioSource = GetComponent<AudioSource>();
	}

	public void StartDialogue (Dialogue dialogue){
		if (cutScene){
			cutScene.Pause();
		}
		if (open) return;
		GameInfo.gameIsPaused = true;
		Time.timeScale = 0;
		
		open = true;
		if(dialogue is OptionDialogue){
			foreach (DialogOption option in ((OptionDialogue)dialogue).options){
				
				GameObject newOption = Instantiate(buttonPrefab,optionsBox);
				newOption.GetComponent<TextMeshProUGUI>().text = option.text;
				AddEvent(newOption, EventTriggerType.PointerClick, delegate{
					
					newOption.GetComponent<AudioSource>().Play();
					string tempText = dialogue.sentences[0];
					dialogue.sentences[0] = option.sentenceInAction;
					option.sentenceInAction = tempText;

					tempText = option.text;
					option.text = option.textInAction;
					option.textInAction = tempText;
					
					StopAllCoroutines();
					dialogueText.text = dialogue.sentences[0];
					newOption.GetComponent<TextMeshProUGUI>().text = option.text;
					option.target.switchState();
					EndDialogue();

				});

			}
		}
		canvas.enabled = true;
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	
	private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
	{
		EventTrigger trigger = obj.GetComponent<EventTrigger>();
		var eventTrigger = new EventTrigger.Entry();
		eventTrigger.eventID = type;
		eventTrigger.callback.AddListener(action);
		trigger.triggers.Add(eventTrigger);
	}
	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			audioSource.PlayOneShot(sound);
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		
		if (cutScene){
			cutScene.Play();
		}
		
		StopAllCoroutines();
		canvas.enabled = false;
		Time.timeScale = 1;
		if (optionsBox){
			foreach (Transform buttom in optionsBox){
				Destroy(buttom.gameObject);
			}
		}

		open = false;
		GameInfo.gameIsPaused = false;

	}

}
