class Program
{
    private static void Main(string[] args)
    {
        string[,] users = {
            {"admin","alpha_beta48"},
            {"personal","charlie08delta*"},
            {"guest","echo-foxtrot"}

        };

        Boolean endLoop = false;

        int remainingAttempts = 3;

        Console.WriteLine("System Login");

        while (!endLoop)
        {
            Console.WriteLine("Please enter a username and password to access the system.\n");

            Console.WriteLine("Enter username:");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("\nEnter password:");
            string inputPassword = Console.ReadLine();

            Boolean systemLocked = false;
            Boolean loginSuccessful = false;

            for (int i = 0; i < users.GetLength(0); i++)
            {
                try
                {
                    if (inputUsername.Equals(users[i, 0]) && inputPassword.Equals(users[i, 1]))
                    {
                        loginSuccessful = true;

                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    // Caught exception prints message describing error
                    Console.WriteLine($"\nError: {e.Message} \n{e.StackTrace}");
                }
            }

            if (loginSuccessful)
            {
                Console.WriteLine("""

                    Access granted.
                    Welcome to the system.

                    """);
            }
            else
            {
                remainingAttempts--;

                if (remainingAttempts > 0)
                {
                    Console.WriteLine($"""

                        Access Denied. Username or password is incorrect.
                        Remaining attempts: {remainingAttempts}

                        """);
                }
                else
                {
                    Console.WriteLine("""

                    System Locked.
                    Maximum attempts have been reached, the application will now close.
                    """);
                    systemLocked = true;
                }
            }

            if (systemLocked || loginSuccessful)
            {
                endLoop = true;
            }
        }
    }
}