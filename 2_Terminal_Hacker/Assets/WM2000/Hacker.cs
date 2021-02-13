using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1passwords = { "coins", "score", "sword", "click", "craft" };
    string[] level2passwords = { "hollywood", "animation", "producer", "director", "parental" };
    string[] level3passwords = { "certification", "elegibility", "varification", "contamination", "extraterrestrial" };
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win}
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("_,.+*'``'*+.,__,.+*'``'*+.,__,.+*'``'*+" +
            "\nWELCOME TO THE WORDMASTER 2000" +
            "\nHACKER TERMINAL" +
            "\n_,.+*'``'*+.,__,.+*'``'*+.,__,.+*'``'*+" +
            "\n\tPress 1 - A gamer's laptop" +
            "\n\tPress 2 - NETFLIX" +
            "\n\tPress 3 - NSA" +
            "\nPick which server above to hack into:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            level = 0;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordChecker(input);
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
            Terminal.WriteLine("Please choose a valid level number");
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Type \"menu\" to go the Main Menu" +
            "\nif necessary" +
            "\nPlease enter the password." +
            "\nheres a hint:" + password.Anagram());
    }
    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
    void PasswordChecker(string input)
    {
        if (input != password)
        {
            AskForPassword();
        }
        else
        {
            DisplayWinScreen();
        }
    }
    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }
    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("EXCELSIOR!!!!!");
                Terminal.WriteLine(@"
           A
          {E}______________________
 /++\     |E|\\\\\\\\\\\\\\\\\\\\\\\
|HHHH|MWMW(O)►►►►►►►►►►►►►►►►►►►►►►►►
 \++/     |E|///////////////////////
          {E}
           V  type menu to go back.
");
                break;
            case 2:
                Terminal.WriteLine(@"
███      ████████████████      █████
            ██████████            ██
             ████████              █
             ████████              █
             you won!!             █
       type menu to go back        █
█         █████    █████          ██
███     ████████  ████████      ████
█████   ████  ██████  ████    ██████
███     ███ ██ ████ ██ ███      ████
███     ███ █  ████  █ ███      ████
███     ████          ████      ████
");
                break;
            case 3:
                Terminal.WriteLine(@"
  type      ______      L
          .dMMMMMMb.   RO
  menu   .dIIIIIIIIb. NT
         NNNNNNNNNNNNCO
   to    DDDDDDDDDDDD
           |   O  |
   go      ( ~~~~ )
            \____/
  back       | |
           you won!!
");
                break;
        }
    }
}