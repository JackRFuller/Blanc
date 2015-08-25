using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Event1Manager : MonoBehaviour {

    [SerializeField] private GameManager GM_Script;
	[SerializeField] private GameObject E;

	[SerializeField] private int EventStage = 0;

	[Header("Text Walls")]
	[SerializeField] private Animation[] TextWalls;

    [Header("Text Effects")]
    [SerializeField] private Text CurrentText;
    [SerializeField] private float FadeInSpeed; 

    [Header("Event F")]
    [SerializeField] private E_Behaviour E_Script;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {     
        if(GM_Script.CurrentLevelState == GameManager.LevelState.Building1)
        {
            if (EventStage == 5)
            {
                if (Input.GetMouseButton(0))
                {
					foreach(Animation Wall in TextWalls)
					{
						Wall.Play("Lower");
					}
                    StartCoroutine(E_Script.WakeUp());
                }
            }
        }   
        
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
		TextWalls[0].Play("Raise"); 
		yield return new WaitForSeconds(TextWalls[0].GetClip("Raise").length);
		EventStage++;

    }

	void EventB()
	{
		TextWalls[1].Play("Raise"); 
		EventStage++;
		E.GetComponent<Rigidbody>().isKinematic = false;
	}

	void EventC()
	{
		TextWalls[2].Play("Raise"); 
		EventStage++;
	}

	void EventD()
	{
		TextWalls[3].Play("Raise"); 
		EventStage++;
	}

	IEnumerator EventE(){

		for(int i = 4; i < TextWalls.Length; i++)
		{
			TextWalls[i].Play("Raise");
			yield return new WaitForSeconds(TextWalls[i].GetClip("Raise").length);
		}
        EventStage++;
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
