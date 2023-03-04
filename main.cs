using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
/*using System.Drawing;
using System.Text;
using System.Linq.Expressions;*/

class Program
{
	public static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;



		int InputInt(string prompt)// i see you are here.
		{
			Console.WriteLine(prompt);
			ConsoleColor color = Console.ForegroundColor;
			Console.ResetColor();
			Console.Write("->");
			bool ok = int.TryParse(Console.ReadLine(), out int output);
			Console.ForegroundColor = color;
			return (output);

			//you here? yes something do be wrong  ===i shall debug.=== ʷᵒʷ（＞0＜；；；）
		}
		//Header
		Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════╗");
		Console.WriteLine("║                          Welcome! You are playing                           ║");
		Console.WriteLine("╟─────────────────────────────────────────────────────────────────────────────╢");
		Console.Write("║");
		Console.ForegroundColor = ConsoleColor.Red;
		Console.Write("                             G R E Y W A T E R                               ");
		Console.ResetColor();
		Console.WriteLine("║");
		Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    if(CheatMode){Console.WriteLine("[DEBUG]Skip-Dialog cheat currently active.");}
		//start of story (du väljer vilken person du vill spela som)
		bool ok = false;
		int actionSelection = 0;
		while (!ok)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			actionSelection = InputInt("I want to play as...\n1. Investigator\n2. Murderer");
			if (actionSelection == 1 || actionSelection == 2)
			{
				ok = true;
			}
			else
			{
				if (actionSelection == 69/*nice*/)
				{
					CheatMode = true;
					ConsoleColor color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("[DEBUG]Skip-Dialog cheat activated.");
				}
				else { Console.WriteLine("Characters disallowed."); }

			}
		}
		Console.ForegroundColor = ConsoleColor.White;
		switch (actionSelection)
		{
			case 1:
				//Create investigator
				Investigator investigator = new Investigator();
				break;
			case 2:
				//Create murderer
				Murderer murderer = new Murderer();
				break;
			default:
				throw new NotImplementedException();

		}
	}
	public static bool CheatMode = false;
}

public class Investigator
{
	int InputInt(string prompt)
	{
		Console.WriteLine(prompt);
		ConsoleColor color = Console.ForegroundColor;
		Console.ResetColor();
		Console.Write("->");
		bool ok = int.TryParse(Console.ReadLine(), out int output);
		Console.ForegroundColor = color;
		return (output);

		//you here? yes something do be wrong  ===i shall debug.=== ʷᵒʷ（＞0＜；；；）
	}
	public static void PrintDialog(string dialog)
	{
		string[] dialogPieces = dialog.Split("*cl");

		for (int i = 0; i < dialogPieces.Length; i++)
		{
			int color;
			if (i > 0)
			{

				bool ok = int.TryParse(dialogPieces[i].ElementAt(0).ToString() + dialogPieces[i].ElementAt(1), out int Colour);
				color = Colour;
				dialogPieces[i] = dialogPieces[i].Remove(0, 2);
				switch (color)
				{
					case 0:
						Console.ForegroundColor = ConsoleColor.Black; break;
					case 1:
						Console.ForegroundColor = ConsoleColor.DarkBlue; break;
					case 2:
						Console.ForegroundColor = ConsoleColor.DarkGreen; break;
					case 3:
						Console.ForegroundColor = ConsoleColor.DarkCyan; break;
					case 4:
						Console.ForegroundColor = ConsoleColor.DarkRed; break;
					case 5:
						Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
					case 6:
						Console.ForegroundColor = ConsoleColor.DarkYellow; break;
					case 7:
						Console.ForegroundColor = ConsoleColor.Gray; break;
					case 8:
						Console.ForegroundColor = ConsoleColor.DarkGray; break;
					case 9:
						Console.ForegroundColor = ConsoleColor.Blue; break;
					case 10:
						Console.ForegroundColor = ConsoleColor.Green; break;
					case 11:
						Console.ForegroundColor = ConsoleColor.Cyan; break;
					case 12:
						Console.ForegroundColor = ConsoleColor.Red; break;
					case 13:
						Console.ForegroundColor = ConsoleColor.Magenta; break;
					case 14:
						Console.ForegroundColor = ConsoleColor.Yellow; break;
					case 15:
						Console.ForegroundColor = ConsoleColor.White; break;
				}
			}

			char[] moddialog = dialogPieces[i].ToArray<char>();
			for (int j = 0; j < moddialog.Length; j++)
			{
				Thread.Sleep(25);
				Console.Write(moddialog[j]);
			}
		}
	}
	Place currentPlace = new Place("Garden", 0, new List<int>(), new List<Object>() { new Object("flower pot", 1, "There is a key underneath", true), new Object("Door mat", 0, "", false) });
	List<Place> places = new List<Place>()
	{
		new Place("Garden",         0, new List<int>(),    new List<Object>(){new Object("flower pot", 1, "There is a key underneath", true), new Object("Door mat", 0, "", false)}),
		new Place("Foyer",          1, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false)}),
		new Place("Greenhouse",     2, new List<int>(),    new List<Object>(){new Object("Broken pot", 0, "How did the pot break?", true)}),
		new Place("Dining hall",    3, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false)}),
		new Place("Kitchen",        4, new List<int>(),    new List<Object>(){new Object("Stove", 0, "", false), new Object("Pot", 0, "It's a dirty pot. Someone did not clean up.", false)}),
		new Place("Corridor",       5, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("Painting", 0, "It's a painting.", false)}),
		new Place("Master Bedroom", 6, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("Bed", 1, "It's a bed.", false)}),
		new Place("Bedroom 1",      7, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("Bed", 1, "It's a bed.", false)}),
		new Place("Bedroom 2",      8, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("Bed", 1, "It's a bed.", false)}),
		new Place("WC 1",           9, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("toilet", 1, "Oh, crap! It's a crapper!", false)}),
		new Place("Studio",        10, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false)}),
		new Place("Closet",        11, new List<int>(),    new List<Object>(){new Object("Box", 0, "It contains general art supplies.", false)}),
		new Place("Living room",   12, new List<int>(),    new List<Object>(){new Object("carpet", 0, "It's a carpet.", false)}),
		new Place("WC 2",          13, new List<int>(){0}, new List<Object>(){new Object("carpet", 0, "It's a carpet.", false), new Object("toilet", 1, "Oh, crap! It's a crapper!", false)})
	};
	public Investigator()
	{
		#region setup
		string[] Prologue = new string[40];
		List<VoiceLine> VoiceLines = new List<VoiceLine>()
		{

		};

		Prologue[0] = "(I have arrived at greywater manor, where someone apparently made quite a scene. Police are running around everywhere, as usual.)";
		Prologue[1] = "I was asked to take this case due to there being a fire, and thus only the best detectives would be able to solve the case.";
		Prologue[2] = "I should go and have a look, should I not?)";
		//problem lies here VVV
		noteBook.Add(Prologue);
		for (int i = 1; i < 39; i++) { noteBook.Add(new string[40]); }
		string[] Inst = new string[40];
		Inst[0] = "test";//put instructions here.
		noteBook.Add(Inst);



		#endregion setup
		#region investigate
		if (Program.CheatMode) { goto SkipDialog; }
		PrintDialog("ˢᶦʳ ᵂᶦⁿᶠʳᵉᵈ ᴴᵃᵇᵇᵒʳˡᵃᶦⁿ⁽ʸᵒᵘ⁾");
		Console.ForegroundColor = ConsoleColor.DarkBlue;
		PrintDialog("\n(I have arrived at greywater manor, where someone apparently made quite a scene. Police are running around everywhere, as usual. ");//prologue add 'To see this again, go to page 0.' to the end
		Thread.Sleep(500); Thread.Sleep(500); Thread.Sleep(500);
		PrintDialog("I was asked to take this case due to there being a fire, and thus only the best detectives would be able to solve the case.\n");
		PrintDialog("I should go and have a look, should I not?)");
		Console.WriteLine();
		Console.ForegroundColor = ConsoleColor.DarkGreen;
		PrintDialog("To see this again, go to page 0.");

		PrintDialog("For instructions on how to play the game, go to notebook, page 39");//instructions
	SkipDialog:
		if (Program.CheatMode)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("[DEBUG]Skipped Dialog.");
		}
		Console.ResetColor();
		Console.WriteLine("\n");

		while (true)
		{
			int selection = 0;
			bool ok = false;
			while (!ok)
			{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("Currently in " + currentPlace.name);
				Console.ForegroundColor = ConsoleColor.Cyan;
				string HereOrNot = "";
				if (currentPlace.peopleHere.Count == 0)
				{
					HereOrNot = "  There is nobody to talk to.";
				}
				selection = InputInt("What to do?\n1. Move...\n2. Notebook...\n3. Talk... " + HereOrNot + Environment.NewLine + "4. Inspect...");
				if (selection == 1 || selection == 2 || selection == 3 || selection == 4) { ok = true; } else { Console.WriteLine("Could not decode"); }
			}
			switch (selection)
			{
				case 1: Move(); break;
				case 2: NoteBook(); break;
				case 3: Speak(); break;
			}
		}
		#endregion investigate

	}
	//noteringsblocket för investigator (utredare?)
	List<string[]> noteBook = new List<string[]>();
	public void Move()
	{
		Console.WriteLine("");
		for (int i = 0; i < places.Count; i++)
		{
			Console.WriteLine((places[i].id + 1).ToString() + " " + places[i].name);
		}
		bool ok = false;
		int selection = 0;
		while (!ok)
		{
			selection = InputInt("VVV Enter choice") - 1;

			if (selection < places.Count + 1 && selection >= 0)
			{
				ok = true;
			}
			else { Console.WriteLine("Could not interpret."); }
		}
		currentPlace = places[selection];
		PrintDialog("*cl02Moved to " + currentPlace.name);

	}

	public List<Person> people = new List<Person>()
	{
		new Person(0, 65535, "testy Mc testface", "⁽ᵗᵉˢᵗʸ ᴹᶜ ᵗᵉˢᵗᶠᵃᶜᵉ⁾", new List<VoiceLine>(){new VoiceLine("Oh, my god!! I forgot to lock the door!", true, 0)})
	};
	public void Speak()
	{
		bool ok = false; int selection = 0;
		while (!ok)
		{
			for (int i = 0; i < currentPlace.peopleHere.Count; i++)
			{
				Console.WriteLine((i + 1).ToString() + ". " + people.Find(x => x.id == currentPlace.peopleHere[i])?.name);

			}
			selection = InputInt("");
			ok = selection > 0 && selection < currentPlace.peopleHere.Count + 1;
			if (!ok) { Console.WriteLine("Could not decode"); }
		}
		selection--;
		if (currentPlace.peopleHere.Count > 0)
		{
			var person = people.Single(x => x.id == currentPlace.peopleHere[selection]);
			if (person.storyIndex != null)
			{
				if (person.storyIndex != -1)
				{
					PrintDialog(person.smallName + "\n" + person.voiceline[person.storyIndex.GetValueOrDefault()].line + "\n");
					person.storyIndex++;
				}
			}
			else
			{
				Console.WriteLine(person.name + " Does not have anything to say.");
			}
		}
	}
	public void Inspect()
	{

	}
	public void NoteBook()
	{
		bool keepgoing = true;
		while (keepgoing)
		{
			bool ok = false;
			int actionSelection = 0;
			while (!ok)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				actionSelection = InputInt("Entering notebook...\n1. View notebook\n2. Edit notebook\n3. Exit notebook");
				if (actionSelection == 1 || actionSelection == 2 || actionSelection == 3)
				{
					ok = true;
				}
				else
				{
					Console.WriteLine("Characters disallowed.");
				}
			}
			if (actionSelection == 1)
			{
				Read();
			}
			if (actionSelection == 2)
			{
				Write();
			}
			if (actionSelection == 3)
			{
				keepgoing = false;
			}

			void Write()
			{
				string[] nextLines = new string[40];
				int page = InputInt("What page to start writing on? Defaults to page 0");
				int lineindex = InputInt("What line to start writing on? Defaults to page 0");

				Console.ResetColor();
				Console.Write("Enter text.\n-> ");
				string line = Console.ReadLine();
				string[] lines = line.Split("*nl");
				if (lines.Length > 40 - lineindex)
				{
					int j = lines.Length;
					for (int i = 40 - lineindex; i < j; i++)
					{
						nextLines.Append(lines[i]);

					}
				}
				for (int i = 0; i < lines.Length; i++)
				{
					//Console.WriteLine(i.ToString() + " " + lines.Length.ToString() + ", " + noteBook.Count.ToString() + " " + page.ToString());
					noteBook[page].SetValue(lines[i], lineindex);
					lineindex++;
					//Console.WriteLine("test. first line -> " + lines[i]);
				}
				//end write
			}
			void Read()
			{
				bool ok = false;
				int page = 0;
				while (!ok)
				{
					page = InputInt("What page to read? default 0. Max 39");
					if (page < 40 && page >= 0)
					{
						ok = true;
					}
					else
					{
						Console.WriteLine("Characters disallowed.");
					}
				}
				Console.ResetColor();

				Console.WriteLine("=========Page " + page.ToString() + "=========");
				bool empty = true;
				for (int i = 0; i < noteBook[page].Length; i++)
				{

					if (!string.IsNullOrWhiteSpace(noteBook[page].GetValue(i)?.ToString()))
					{
						Console.WriteLine(noteBook[page].GetValue(i));
						empty = false;
					}
				}
				if (empty) { Console.WriteLine($"Page {page} is empty."); }
			}
		}

	}
}
public class Place
{
	public Place(string Name, int Id, List<int> PeopleHere, List<Object> Objects)
	{
		name = Name;
		id = Id;
		peopleHere = PeopleHere;
		objects = Objects;

	}//this did not work.
	public string name { get; set; }
	public int id { get; set; }
	public List<int> peopleHere = new();
	public List<Object> objects = new();
}

public class Person
{
	public Person(int Id, int Age, string Name, string SmallName, List<VoiceLine> VoiceLines)
	{
		id = Id;
		age = Age;
		name = Name;
		voiceline = VoiceLines;
		storyIndex = 0;
		smallName = SmallName;
		if (VoiceLines.Count == 0) { storyIndex = null; }
	}
	public int? storyIndex { get; set; }
	public int id { get; set; }
	public int age { get; set; }
	public string name { get; set; }
	public string smallName { get; set; }
	public Place location { get; set; }
	public List<VoiceLine> voiceline = new();
}
public class VoiceLine
{
	public VoiceLine(string Line, bool Repeating, int Index,  int? Response = null, int? ResponseTarget = null)
	{
		line = Line;
		repeating = Repeating;
		index = Index;
		VoiceLineUsed += VoiceLine_VoiceLineUsed;
		response = Response;
		responseTarget = ResponseTarget;
	}

	private void VoiceLine_VoiceLineUsed(object? sender, VoiceLine e)
	{
		if(response != null && responseTarget != null)
		{
			if(responseTarget == -1)
			{

			}
			else
			{

			}
		}
	}

	public string line { get; set; }
	public bool repeating { get; set; }
	public int index { get; set; }
	public event EventHandler<VoiceLine> VoiceLineUsed;
	public int? response { get; set; }//respons that should be invoked
	public int? responseTarget { get; set; }//responseTarget: id of person who has the response; -1 indicates it is you
}
public class Object
{
	public Object(string name, int id, string? significance, bool significant)
	{
		Name = name;
		Id = id;
		Significance = significance;
		Significant = significant;
	}
	public string Name { get; set; }
	public int Id { get; set; }
	public string? Significance { get; set; }
	public bool Significant { get; set; }
}
//Det här hindrade programmet från att köra

public class Murderer
{
	//le föremål
	bool knife = false;


	int InputInt(string prompt)
	{
		Console.WriteLine(prompt);
		ConsoleColor color = Console.ForegroundColor;
		Console.ResetColor();
		Console.Write("->");
		var ok = int.TryParse(Console.ReadLine(), out int output);
		Console.ForegroundColor = color;
		return (output);

	}
	public Murderer()
	{//Console.Writeline(); (reminder) 
		
		void PrintDialog(string dialog)
		{
			string[] dialogPieces = dialog.Split("*cl");
			
			for(int i = 0; i < dialogPieces.Length; i++)
			{
				int color;
				if(i > 0)
				{
					
					bool ok = int.TryParse(dialogPieces[i].ElementAt(0).ToString() + dialogPieces[i].ElementAt(1), out int Colour);
					color = Colour;
					dialogPieces[i] = dialogPieces[i].Remove(0, 2);
					switch(color)
					{
						case 0:
						Console.ForegroundColor = ConsoleColor.Black; break;
					case 1:
						Console.ForegroundColor = ConsoleColor.DarkBlue; break;
					case 2:
						Console.ForegroundColor = ConsoleColor.DarkGreen; break;
					case 3:
						Console.ForegroundColor = ConsoleColor.DarkCyan; break;
					case 4:
						Console.ForegroundColor = ConsoleColor.DarkRed; break;
					case 5:
						Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
					case 6:
						Console.ForegroundColor = ConsoleColor.DarkYellow; break;
					case 7:
						Console.ForegroundColor = ConsoleColor.Gray; break;
					case 8:
						Console.ForegroundColor = ConsoleColor.DarkGray; break;
					case 9:
						Console.ForegroundColor = ConsoleColor.Blue; break;
					case 10:
						Console.ForegroundColor = ConsoleColor.Green; break;
					case 11:
						Console.ForegroundColor = ConsoleColor.Cyan; break;
					case 12:
						Console.ForegroundColor = ConsoleColor.Red; break;
					case 13:
						Console.ForegroundColor = ConsoleColor.Magenta; break;
					case 14:
						Console.ForegroundColor = ConsoleColor.Yellow; break;
					case 15:
						Console.ForegroundColor = ConsoleColor.White; break;
					}
				}
				
				char[] moddialog = dialogPieces[i].ToArray<char>();
				for(int j = 0; j < moddialog.Length; j++)
				{
					Thread.Sleep(25);
					Console.Write(moddialog[j]);
				}
			}
		}
	    void next() 
		{
			Console.WriteLine("\n\n\n↓");
	    Console.ReadKey(true);
	    Console.WriteLine("\n\n");}
	    
	    //10/10 Funktion, bry dig inte om att jag inte fattade varför den inte funkade... Vissade sig att jag hade råkade lägga den inuti din funktion så att den inte gick att kalla. ~Bruh face~
	    bool ok = false;
			int actionSelection = 0;
			while(!ok)
			{
	      Console.ForegroundColor = ConsoleColor.DarkGray;
				actionSelection = InputInt("Your now playing as Murderer\n1. sounds good\n2. No go back ");
				if(actionSelection == 1 || actionSelection == 2){
					ok = true;
				}
				else{
					Console.WriteLine("Characters disallowed.");
	        
				}
			}
	    //
	    Console.ForegroundColor = ConsoleColor.White;
	    //
			switch(actionSelection)
			{
			case 1: 
				//fixed
	      if(Program.CheatMode){goto SkipDialog;}
			
	      	  //here
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n*urghh...* ");
	      Console.ForegroundColor = ConsoleColor.Blue;//         																																																																																																																											                        																																																																																																												Discord?
	        //ok
	      PrintDialog("(I probably had one too many last night, I feel sick.)");
	     next();
	     PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(My life has been terrible, and it's all because of that Mona Cheyne, she ruined my life.)");
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(I used to work at Greywater manor, as a gardener actually, but one day I was watering the flowers as usual and somehow a fire had started in the greenhouse, I didn't notice the fire before it was too late.)"/*"in time"*/);
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(Mona Cheyne, the owner of manor was furious and accused me of starting the fire, I got immediately fired and as a cherry on top of that she later repoted this to the police and there was apparently enough evidence to sentence me to four years in prison for arson.)");
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(This resulted in my life getting ruined, not only going to prison but losing my entire family, my wife left me and took the kids with her and my parents have been avoiding me ever since then.)");
	      next();
	      PrintDialog("Financially, I've gotten by I guess, it's hard to find any good jobs with a crime in the register so at the moment I'm working as a janitor at a cafe.");
	      next();
	      PrintDialog("(Most of the money that I earn usally ends up being spent on beer and whisky at the local pub.)");
	      next();
	          Console.ForegroundColor = ConsoleColor.White;
	          PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n...");
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\nI hate her...");
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n");
	      Console.BackgroundColor = ConsoleColor.DarkRed;
	      PrintDialog("I FUCKING HATE THAT BITCH, I'M GONNA KILL HER IF IT'S THE LAST THING I DO!");
	      Console.ResetColor();
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n...");
	      next();
	      PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\nI've made up my mind, I'll do it, I'll kill her no matter what.");
	      next();
	       Console.ForegroundColor = ConsoleColor.Blue;
	          PrintDialog("ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(But for now i should probably get out of bed and go eat some breakfast.)");
	      next();
	    	SkipDialog:
        if(Program.CheatMode){
          Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("[DEBUG]Skipped Dialog.");}
				
				break;// använd '+' istället för ',' när du använder min funktion
	    case 2://replit sa att jag skulle använda ',' så jag blev lurad 
				//Go back            Replit brukar ju lura oss.
        
        Program program = new Program();
        Console.Clear();
        Program.Main();
        
      
				/*Console.ForegroundColor = ConsoleColor.Red;
	      PrintDialog("ᴸᵃᶻʸ ᵈᵉᵛ\nNot implemented :P");*///L O L
        // I implemented it, I'm not "lazy dev" anymore
				for(int i = 0; i < 10; i++){Thread.Sleep(250);}
	      Environment.Exit(0);//haha
				break;
			default:
				throw new NotImplementedException();//<-- här
				}//<-- den här
    string StandInKitchen = ("\n*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(While i'm eating my cereal, I should look around my kitchen to see if there's anything useful.)");
    string KnifeOption = ("Pick up knife");
    int MakeshiftSolution = 0;

       
       Josephkitchen();
	     void Josephkitchen()
	  {  
	    Random rnd = new Random();
	    int AlreadyHoldingKnifeDialogSelector = rnd.Next(1, 5);
      bool inroom = true;
	    
	    bool ok1 = false;
			int actionSelection1 = 0;//colour coding works now
			while(!ok1) //nice and has been deployed
	    //hur använder man det?
			// skriv *cl[insert color here]
			//t.ex. "exempeltext som *cl02blir grön"
	    /*ok, gissar att man får kolla här: 
	      https://replit.com/@Eliaskungen5/grej#main.cs:380:12
	      vilken siffra som är vilken färg*/
			
			//00-Black, 01-DarkBlue,  02-DarGreen, 03-DarkCyan, 04-DarkRed
			//05-DarkMagenta, 06-DarkYellow, 07-Grey, 08-DarkGrey, 09-Blue
			//10-Green, 11-Cyan, 12-Red, 13-Magenta, 14-Yellow, 15-White
       
			{
      
      if(knife){KnifeOption = ("Inspect knife");}
      if(MakeshiftSolution == 1){StandInKitchen = ("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(My bowl that I had cereal in is still on the table, washing that bowl will be a later problem.)");}
        else{MakeshiftSolution = 1;}
        // ====>|D I S C O R D?|<====
        PrintDialog(StandInKitchen);
        Console.ForegroundColor = ConsoleColor.DarkGray;
				actionSelection1 = InputInt("\n1. " + KnifeOption + ". \n2. Leave the kitchen");
        
				if(actionSelection1 == 1 || actionSelection1 == 2)
				{
					ok = true;
				}
				else
				{
					Console.WriteLine("Characters disallowed.");
				}
	      switch(actionSelection1)
				{
	      case 1:
	        if (knife == false) {PrintDialog("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(Could come in handy when you're tring to end someones life.)\n*cl08Picked up knife*cl09");
            next();
	        knife = true;}
	        else 
	        {
						switch(AlreadyHoldingKnifeDialogSelector)
						{
	          case 1:
	            PrintDialog("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(Damn the knife is sharp.)");
              next();
	          break;
	           case 2:
	            PrintDialog("*cl15ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n*Ow* *cl09(probably shoud be more careful, the knife's quite sharp.)");
              next();
						break;
             case 3:
              PrintDialog("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(This is probably the only knife I own that's not blunt.)");
              next();
            break;
            case 4:
              PrintDialog("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(I actualy bought this on a vacation to Japan about 7 years ago, yeah before all the things went down, belive it's a gyuto knife.)");
              next();
            break;
            
              
						}
	          
	        }
	        Josephkitchen();
	        break;
	      case 2:
	        PrintDialog("*cl09ᴵʳᵛᶦⁿ ᴶᵒˢᵉᵖʰ⁽ʸᵒᵘ⁾\n(This kitchen is gross, should probably leave before I become even more depressed from all the stains.)");
          next();
          inroom = false;
					break;
        default://this is unreachable. but we got that exception... Replit..? is there something you haven't told us?
					throw new NotImplementedException();}
       if(!inroom){break;}}
      }//discord?
    
    
	}
	void JosephEntranceHall()
	{
	 
	}
}
#region Comments
//extra info
//Onomatopoeia marked with *[Onomatopoeia here]* ans has green color if the noice comes from a non human source (color not shown in example) like this: 
//"*moo*
//the cow seems hungry"  
//+=========+
//|  Story  |
//+=========+

//https://www.fantasynamegenerators.com/victorian-names.php

//there is a murder at greywater manor, Beckinsale, england (please add more)
//Investigator sir Winfred Habborlain
//Murderer Irvin Joseph
//victim Mona Cheyne



//You are murderer or investigator you choose
// ﮩ٨ـﮩﮩ٨ـ♡ﮩ٨ـﮩﮩ٨ـ
//🩸murderer🗡🩸
//꒦꒷︶꒷︶꒷꒦꒷︶꒦꒷꒦
//Plan a way to murder and collect equpment
//Commit murder
//Try to get away with it 


//+================+
//|  INVESTIGATOR  |
//+================+

//investigate crime scene;
//  notebook mechanic - done
//  returns EvidenceCount

//choose suspect;

//do stuff in court.
#endregion Comments