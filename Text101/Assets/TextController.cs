using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () 
	{
		myState = States.cell;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(myState);
		if (myState == States.cell)				{state_cell();}
		else if (myState == States.sheets_0)	{state_sheets_0();}
		else if (myState == States.lock_0)		{state_lock_0();}
		else if (myState == States.mirror)		{state_mirror();}
		// after obtaining mirror
		else if (myState == States.cell_mirror)	{state_cell_mirror();}
		else if (myState == States.sheets_1)	{state_sheets_1();}
		else if (myState == States.lock_1)		{state_lock_1();}
		else if (myState == States.freedom)		{state_freedom();}
	}
	
	void state_cell()
	{
		text.text = "You wake up in a prison cell. It's cold inside - you should probably try " + 
					"to escape. There are some dirty sheets on the bed, a mirror on the wall, " +
					"and the door is closed from the outside.\n\n" + 
					"Press S to view Sheets, M to look at Mirror or L to look at the lock.";
					
		
		// state change
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}
		else if (Input.GetKeyDown(KeyCode.M))	{myState = States.mirror;}
		
	}
	
	void state_sheets_0()
	{
		text.text = "Well, those sheets SURE ARE DIRTY! I wouldn't sleep on them if I were you...\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void state_lock_0()
	{
		text.text = "You notice a lock with a keypad. There's also a note scribbled above it -" + 
		"\"The answer is above your head\". You look above you and there's a combination " + 
		"painted above your head...but you can't make it out clearly - it's a mirrored image.\n\n" + 
		"Press R to Return to roaming your cell";
				
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void state_mirror()
	{
		text.text = "You look at the mirror - and see your handsome face.\n" + 
					"You also notice that the mirror is only hanging on a nail." + 
					"It's small enough for you to pick it up.\n\n" + 
					"Press R to Return to roaming your cell, or T to pick up the mirror";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T))	{myState = States.cell_mirror;}
		
	}
	
	// STATES AFTER PICKING UP A MIRROR
	void state_cell_mirror()
	{
		text.text = "You've got a mirror now! Great! But you're still imprisoned." + 
					"What do you want to do now?\n\n" + 
					"Press S to view Sheets, or L to look at the lock.";
		
		// state change
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}		
	}
	
	void state_sheets_1()
	{
		text.text = "The sheets are very dirty, so you just look at them " + 
					"without doing anything. But hey, at least you've got a mirror!\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void state_lock_1()
	{
		text.text = "You notice a lock with a keypad. There's also a note scribbled above it -" + 
					"\"The answer is above your head\". You look above you and there's a combination " + 
					"painted above your head... but it's mirrored.\n" + 
					"Thanks to the mirror, you manage to read the combination!\n\n" + 
					"Press O to try opening the door using combination " + 
					"or press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.O))	{myState = States.freedom;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void state_freedom()
	{
		text.text = "After you input the code, the door slowly opens. Seems like it worked!" +
					"You managed to escape!\n" + 
					"CONGRATULATIONS, YOU WIN!\n\n" + 
					"Press P to Play Again!";
		
		// state change
		if (Input.GetKeyDown(KeyCode.P))	{myState = States.cell;}
	}
	
}
