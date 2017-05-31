using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour
{
	// Use this for initialization
    int max;
    int min;
    int guess;
    
    void Start () 
	{
        StartGame();
	}
	
	// Update is called once per frame
	void Update ()
    {
        TakeGuess();
	}
    
    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = (max + min) / 2;
        print("Welcome to Number Wizard!");
        print("Pick a number in yo head!");
        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);
        print("================================");
        print("Is the number higher or lower than " + guess + "?");
        print("Up = higher, Down = lower, Return = equal");   
        max = max + 1;
    }
    
    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess + "?");
        print("Up = higher, Down = lower, Return = equal");
    }
    
    void TakeGuess()
    {   
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Your number is " + guess + "!\n YOU WIN!!!!!!!!!!!!!!!!");   
            print("=====================================");
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
    }
}
