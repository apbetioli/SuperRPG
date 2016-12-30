using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

	public Animator animator;
	private Text text;


	void OnEnable(){
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
		Destroy(gameObject, clipInfo[0].clip.length);
		text = animator.GetComponent<Text>();
	}

	public void SetText(string text){
		this.text.text = text;
	}
}
