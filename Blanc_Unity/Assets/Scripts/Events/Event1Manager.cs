using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Event1Manager : MonoBehaviour {

	[SerializeField] private GameObject E;

	[SerializeField] private int EventStage = 0;

    [Header("Text Effects")]
    [SerializeField] private Text CurrentText;
    [SerializeField] private float FadeInSpeed;

    [Header("Event A")]
    [SerializeField] private Animation TextWall_1;
    [SerializeField] private Animator TextItem_1;

	[Header("Event B")]
	[SerializeField] private Animation TextWall_2;

	[Header("Event C")]
	[SerializeField] private Animation TextWall_3;

	[Header("Event D")]
	[SerializeField] private Animation TextWall_4;

	[Header("Event E")]
	[SerializeField] private Animation[] TextWalls;

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
			EventB();
			break;
		case 2:
			EventC();
			break;
		case 3:
			EventD ();
			break;
		
		case 4:
			StartCoroutine(EventE());
		break;
		}
	}

    IEnumerator EventA()
    {
        TextWall_1.Play();        
        yield return new WaitForSeconds(TextWall_1.clip.length);
		EventStage++;

    }

	void EventB()
	{
		TextWall_2.Play();
		EventStage++;
		E.GetComponent<Rigidbody>().isKinematic = false;
	}

	void EventC()
	{
		TextWall_3.Play();
		EventStage++;
	}

	void EventD()
	{
		TextWall_4.Play();
		EventStage++;
	}

	IEnumerator EventE(){

		for(int i = 0; i < 3; i++)
		{
			TextWalls[i].Play();
			yield return new WaitForSeconds(TextWalls[i].clip.length);
		}
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
