using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Event1Manager : MonoBehaviour {

	[SerializeField] private int EventStage = 0;

    [Header("Text Effects")]
    [SerializeField] private Text CurrentText;
    [SerializeField] private float FadeInSpeed;

    [Header("Event A")]
    [SerializeField] private Animation TextWall_1;
    [SerializeField] private Animator TextItem_1;

	// Use this for initialization
	void Start () {
	
	}

	public void TriggerEventStage()
	{
		switch(EventStage)
		{
		case 0:
                StartCoroutine(EventA());
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		}
	}

    IEnumerator EventA()
    {
        TextWall_1.Play();        
        yield return new WaitForSeconds(TextWall_1.clip.length);
        TextItem_1.enabled = true;

        //CurrentText = TextItem_1;
        //TextFadeIn();
    }

    void TextFadeIn()
    {
        for(float i = CurrentText.color.a; i < 255; i++)
        {
            Color Alpha = CurrentText.color;
            Alpha.a = i;
            CurrentText.color = Alpha;            
        }
        
    }
}
