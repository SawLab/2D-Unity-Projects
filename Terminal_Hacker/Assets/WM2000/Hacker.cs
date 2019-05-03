using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string currentPassword;

    enum Screen { MainMenu, Password, Win }
    Screen currentScreen = Screen.MainMenu;
    const string menuHint = "You may type menu at any time.\nType exit or press esc to exit.";


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("\nPress 1 for the High School");
        Terminal.WriteLine("Press 2 for the Bank");
        Terminal.WriteLine("Press 3 for CERN");
        Terminal.WriteLine("\nEnter your choice:");
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "exit")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunGame(input);
        }     

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void RunGame(string input)
    {

        if (input == currentPassword)
        {            
            DisplayWinScreen();
        }

        else
        {
            Terminal.WriteLine("Incorrect password. Try again.");
            AskForPassword();
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Incorrect input. Try again.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        string[] easyPasswords = { "trifle", "house", "crazy", "stunt", "phone" };
        string[] mediumPasswords = { "pancakes", "station", "producer", "recycle", "management" };
        string[] hardPasswords = { "satellite", "motorcycle", "mechanical", "repository", "whiteboard" };

        currentScreen = Screen.Password;
        System.Random rnd = new System.Random();
        int passSelect;

        Terminal.ClearScreen();


        switch (level)
        {
            case 1:
                passSelect = rnd.Next(easyPasswords.Length);
                currentPassword = easyPasswords[passSelect];
                break;
            case 2:
                passSelect = rnd.Next(mediumPasswords.Length);
                currentPassword = mediumPasswords[passSelect];
                break;
            case 3:
                passSelect = rnd.Next(hardPasswords.Length);
                currentPassword = hardPasswords[passSelect];
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }

        Terminal.WriteLine("Enter the password. Hint: " + currentPassword.Anagram());
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Access granted.");

        switch (level)
        {
            case 1:
                Terminal.WriteLine("Grades changed successfully.");
                break;
            case 2:
                Terminal.WriteLine("All funds have been transferred.");
                break;
            case 3:
                Terminal.WriteLine("Time travel data now accessible.");
                break;
            default:
                Debug.LogError("Invalid level.");
                break;
        }
        Terminal.WriteLine(menuHint);
    }

}




