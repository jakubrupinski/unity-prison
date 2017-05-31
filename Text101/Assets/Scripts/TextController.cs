using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private Sprite background;
	public AudioSource bgMusicEscape;
	public AudioSource bgMusicFreedom;	
	
	private enum States {
		menu, cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, 
		lock_1,corridor_0, corridor_1, upstairs_0, upstairs_1, closet, 
		exit_0, exit_1, freedom
	};
	private States myState;
	
	// Use this for initialization
	void Start () 
	{
		myState = States.menu;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// change background
		Change();
		
		// print and check states
		print(myState);
		if (myState == States.menu)				{menu();}
		else if (myState == States.cell)		{cell();}
		else if (myState == States.sheets_0)	{sheets_0();}
		else if (myState == States.lock_0)		{lock_0();}
		else if (myState == States.mirror)		{mirror();}
		// after obtaining mirror
		else if (myState == States.cell_mirror)	{cell_mirror();}
		else if (myState == States.sheets_1)	{sheets_1();}
		else if (myState == States.lock_1)		{lock_1();}
		else if (myState == States.corridor_0)	{corridor_0();}
		// after exiting to corridor
		else if (myState == States.upstairs_0)	{upstairs_0();}
		else if (myState == States.closet)		{closet();}
		else if (myState == States.exit_0)		{exit_0();}
		// after obtaining the key from the closet
		else if (myState == States.corridor_1)	{corridor_1();}
		else if (myState == States.upstairs_1)	{upstairs_1();}
		else if (myState == States.exit_1)		{exit_1();}
		else if (myState == States.freedom)		{freedom();}
		
		// check if user wants to quit
		else if (Input.GetKeyDown(KeyCode.Q))	{Application.Quit();} 
	
	}
	
	void menu()
	{
		bgMusicFreedom.Stop();
		bgMusicEscape.Stop ();
		background = Resources.Load<Sprite>("prison word");
		Change();
		text.text = "A quasi-text adventure game\n\n\n" + 
					"Press Enter to start, Q to quit\n\n\n\n\n" + 
					"Game by Jakub Rupiński.\n" + 
					"Music: http://www.bensound.com, images taken from Google Graphics";
		// state change
		if (Input.GetKeyDown(KeyCode.Return))	{myState = States.cell;}
	}
	
	void cell()
	{
		if (!bgMusicEscape.isPlaying)
			bgMusicEscape.Play();
			
		background = Resources.Load<Sprite>("cell");
		Change();
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
		background = Resources.Load<Sprite>("sheets");
		text.text = "Well, those sheets SURE ARE DIRTY! I wouldn't sleep on them if I were you...\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void lock_0()
	{
		background = Resources.Load<Sprite>("lock");
		text.text = "You notice a lock with a keypad. There's also a note scribbled above it -" + 
		"\"The answer is above your head\". You look above you and there's a combination " + 
		"painted above your head...but you can't make it out clearly - it's a mirrored image.\n\n" + 
		"Press R to Return to roaming your cell";
				
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell;}
	}
	
	void mirror()
	{
		background = Resources.Load<Sprite>("mirror");
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
		background = Resources.Load<Sprite>("cell");
		text.text = "You've got a mirror now! Great! But you're still imprisoned." + 
					"What do you want to do now?\n\n" + 
					"Press S to view Sheets, or L to look at the lock.";
		
		// state change
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}		
	}
	
	void sheets_1()
	{
		background = Resources.Load<Sprite>("sheets");
		text.text = "The sheets are very dirty, so you just look at them " + 
					"without doing anything. But hey, at least you've got a mirror!\n\n" + 
					"Press R to Return to roaming your cell";
		
		// state change
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.cell_mirror;}
	}
	
	void lock_1()
	{
		background = Resources.Load<Sprite>("lock");
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
		background = Resources.Load<Sprite>("corridor");
		Change();
		text.text = "After you input the code, you exit the room, and the door closes shut behind you." + 
					"You managed to escape the room. You are now inside a long corridor.\n" + 
					"There are stairs that go up, a closet and a door with \"EXIT\" sign on them.\n\n" + 
					"Press U to go Upstairs, C to investigate the Closet, or E to go to Exit";
		
		// state change
		if (Input.GetKeyDown(KeyCode.U))		{myState = States.upstairs_0;}
		else if (Input.GetKeyDown(KeyCode.C))	{myState = States.closet;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.exit_0;}
	}
	
	void upstairs_0()
	{
		background = Resources.Load<Sprite>("upstairs");
		text.text = "You go upstairs.\n You are now inside a room with nothing but a window." + 
					"It's barred and closed, so there's no way to open it. You can see the sun " +
					"and clouds through it though.\n\n" + 
					"Press D to go back to the corridor downstairs";
				
		if (Input.GetKeyDown(KeyCode.D))	{myState = States.corridor_0;}
	}
	
	void closet()
	{
		background = Resources.Load<Sprite>("closet");
		text.text = "You investigate the closet. Inside you find some useless junk, and a key.\n" + 
					"It might be useful...\n\n" +
					"Press K to take the key R to return to the corridor";
		
		if (Input.GetKeyDown(KeyCode.K))		{myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_0;}
	}
	
	void exit_0()
	{
		background = Resources.Load<Sprite>("exit");
		text.text = "You go to the exit door. It's closed - looks like you need a key.\n\n" +
					"Press R to return to the corridor";
		
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_0;}
	}
	
	// after obtaining the key
	void corridor_1()
	{
		background = Resources.Load<Sprite>("corridor");
		text.text = "You are still inside a long corridor...with a key in your hand\n" + 
					"There are stairs that go up and a door with \"EXIT\" sign on them.\n\n" + 
					"Press U to go Upstairs, or E to go to Exit";
		
		// state change
		if (Input.GetKeyDown(KeyCode.U))		{myState = States.upstairs_1;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.exit_1;}
	}
	
	void upstairs_1()
	{
		background = Resources.Load<Sprite>("upstairs");
		text.text = "You go upstairs.\n The sun is still on the horizon, and " + 
					"rays of sunlight brighten up the room. The room is still " +
					"empty though.\n\n " +
					"Press D to go back to the corridor downstairs";
		
		if (Input.GetKeyDown(KeyCode.D))	{myState = States.corridor_1;}
	}
	
	void exit_1()
	{
		background = Resources.Load<Sprite>("exit");
		text.text = "You go to the exit door. It's closed - looks like you need a key.\n" + 
					"Keyhole looks like it might be a perfect fit for the key from the closet\n\n" +
					"Press K to use the key and exit R to return to the corridor";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.K))	{myState = States.freedom;}
		
	}
	
	void freedom()
	{
		bgMusicEscape.Stop();
		if (!bgMusicFreedom.isPlaying)
			bgMusicFreedom.Play();
		background = Resources.Load<Sprite>("freedom");
		text.text = "You feel a breeze of air on your face, and the sunlight in your eyes.\n" + 
					"You managed to escape! Congratulations!\n\n" + 
					"Press P to play again, or Q to exit!";
		
		if (Input.GetKeyDown(KeyCode.P))	{myState = States.menu;}
	}
	
	// code for changing the background
	private void Change()
	{
		GetComponent<Image>().sprite = background;
	}
}
