using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public bool resetScore = false;	// should this level reset the score to 0?  (generally for level 1)
	private static int score = 0;


	// Use this for initialization
	void Start () 
	{
		if (resetScore) score = 0;
		UpdateText();
	}


	// Update is called once per frame
	void Update ()
    {
		
	}


	public void AddPoints(int points)
	{
		score += points;
		UpdateText();
	}


	private void UpdateText()
	{
		GetComponent<UnityEngine.UI.Text>().text = "" + score;
	}
}
