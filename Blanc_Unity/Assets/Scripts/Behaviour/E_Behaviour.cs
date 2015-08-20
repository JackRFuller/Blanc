using UnityEngine;
using System.Collections;

public class E_Behaviour : MonoBehaviour {

    [SerializeField] private GameManager GM_Script;

    [Header("Building 1")]
    [SerializeField] private Renderer E_Mesh;
    [SerializeField] private Color StartColor;
    [SerializeField] private Color EndColor;
    [SerializeField] private float LerpTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator WakeUp()
    {
        GM_Script.CurrentLevelState = GameManager.LevelState.Building2;
        while(E_Mesh.material.color != EndColor)
        {
            E_Mesh.material.color = Color.Lerp(E_Mesh.material.color, EndColor, LerpTime * Time.deltaTime);
        }
        
        Debug.Log("A");       
        yield return new WaitForSeconds(LerpTime);
    }
}
