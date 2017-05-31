using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public Sprite newBackground;
	
	
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
		corridor_0, upstairs, closet, exit
		};
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
		if (myState == States.cell)				{cell();}
		else if (myState == States.sheets_0)	{sheets_0();}
		else if (myState == States.lock_0)		{lock_0();}
		else if (myState == States.mirror)		{mirror();}
		// after obtaining mirror
		else if (myState == States.cell_mirror)	{cell_mirror();}
		else if (myState == States.sheets_1)	{sheets_1();}
		else if (myState == States.lock_1)		{lock_1();}
		else if (myState == States.corridor_0)	{corridor_0();}
		// after exiting to corridor
		else if (myState == States.upstairs)	{upstairs();}
		else if (myState == States.closet)		{closet();}
		else if (myState == States.exit)		{exit();}
	}
	
	void cell()
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
	
	void sheets_0()
	{
		text.text = "Well, those sheets SURE ARE DIRTY! I wouldn't sleep on them if I were you...\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void lock_0()
	{
		text.text = "You notice a lock with a keypad. There's also a note scribbled above it -" + 
		"\"The answer is above your head\". You look above you and there's a combination " + 
		"painted above your head...but you can't make it out clearly - it's a mirrored image.\n\n" + 
		"Press R to Return to roaming your cell";
				
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void mirror()
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
	void cell_mirror()
	{
		text.text = "You've got a mirror now! Great! But you're still imprisoned." + 
					"What do you want to do now?\n\n" + 
					"Press S to view Sheets, or L to look at the lock.";
		
		// state change
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}		
	}
	
	void sheets_1()
	{
		text.text = "The sheets are very dirty, so you just look at them " + 
					"without doing anything. But hey, at least you've got a mirror!\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void lock_1()
	{
		text.text = "You notice a lock with a keypad. There's also a note scribbled above it -" + 
					"\"The answer is above your head\". You look above you and there's a combination " + 
					"painted above your head... but it's mirrored.\n" + 
					"Thanks to the mirror, you manage to read the combination!\n\n" + 
					"Press O to try opening the door using combination " + 
					"or press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.O))		{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void corridor_0()
	{
		Change();
		text.text = "After you input the code, you exit the room, and the door closes shut behind you." + 
					"You managed to escape the room. You are now inside a long corridor.\n" + 
					"There are stairs that go up, a closet and a door with \"EXIT\" sign on them\n\n." + 
					"Press U to go Upstairs, C to investigate the Closet, or E to go to Exit";
		
		// state change
		if (Input.GetKeyDown(KeyCode.U))		{myState = States.upstairs;}
		else if (Input.GetKeyDown(KeyCode.C))	{myState = States.closet;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.exit;}
	}
	
	void upstairs()
	{
		
	}
	
	void closet()
	{
		
	}
	
	void exit()
	{
		
	}
	
	private void Change()
	{
		GetComponent<Image>().sprite = newBackground;
	}
	
}
