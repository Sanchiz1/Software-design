namespace ChainOfResponsibility;
public class PasswordResetManager : IPasswordResetManager
{
    public bool TryResetUsingEmail(ResetPasswordRequest request)
    {
        Console.WriteLine("Reset password using email");
        while (true)
        {
            Console.WriteLine("1 - Enter email\n2 - Don`t have an email");

            var choice = Console.ReadLine() ?? string.Empty;

            if(choice == "1")
            {
                Console.WriteLine("Enter email (type 0 to cancel): ");

                var email = Console.ReadLine() ?? string.Empty;

                email = email.Trim();

                if (email == "0")
                {
                    continue;
                }

                if(email == string.Empty)
                {
                    Console.WriteLine("Incorrect email");
                    continue;
                }

                Console.WriteLine("Email with code ha been sent");
                Console.WriteLine("Enter code (type 0 to cancel): ");
                var code = Console.ReadLine() ?? string.Empty;

                code = code.Trim();

                if (code == "0")
                {
                    continue;
                }
                if (code == string.Empty)
                {
                    Console.WriteLine("Incorrect code");
                    continue;
                }

                //UpdatePassword(request.NewPassword, request.Username);

                return true;
            }

            if (choice == "2") 
                return false;

            Console.WriteLine("Incorrect command");
            continue;
        }
    }

    public bool TryResetUsingBackupEmail(ResetPasswordRequest request)
    {
        Console.WriteLine("Reset password using backup email");
        while (true)
        {
            Console.WriteLine("1 - Enter backup email\n2 - Don`t have the backup email");

            var choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                Console.WriteLine("Enter backup email (type 0 to cancel): ");

                var email = Console.ReadLine() ?? string.Empty;

                email = email.Trim();

                if (email == "0")
                {
                    continue;
                }

                if (email == string.Empty)
                {
                    Console.WriteLine("Incorrect backup email");
                    continue;
                }

                Console.WriteLine("Email with code ha been sent");
                Console.WriteLine("Enter code (type 0 to cancel): ");
                var code = Console.ReadLine() ?? string.Empty;

                code = code.Trim();

                if (code == "0")
                {
                    continue;
                }

                if (code == string.Empty)
                {
                    Console.WriteLine("Incorrect code");
                    continue;
                }

                //UpdatePassword(request.NewPassword, request.Username);

                return true;
            }

            if (choice == "2")
                return false;

            Console.WriteLine("Incorrect command");
            continue;
        }
    }

    public bool TryResetUsingPhoneNumber(ResetPasswordRequest request)
    {
        Console.WriteLine("Reset password using phone number");
        while (true)
        {
            Console.WriteLine("1 - Enter phone number\n2 - Don`t have a phone number");

            var choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                Console.WriteLine("Enter phone number (type 0 to cancel): ");

                var phoneNumber = Console.ReadLine() ?? string.Empty;

                phoneNumber = phoneNumber.Trim();

                if (phoneNumber == "0")
                {
                    continue;
                }

                if (phoneNumber == string.Empty)
                {
                    Console.WriteLine("Incorrect phone number");
                    continue;
                }

                Console.WriteLine("SMS with code ha been sent");
                Console.WriteLine("Enter code (type 0 to cancel): ");
                var code = Console.ReadLine() ?? string.Empty;

                code = code.Trim();

                if (code == "0")
                {
                    continue;
                }

                if (code == string.Empty)
                {
                    Console.WriteLine("Incorrect code");
                    continue;
                }

                //UpdatePassword(request.NewPassword, request.Username);

                return true;
            }

            if (choice == "2")
                return false;

            Console.WriteLine("Incorrect command");
            continue;
        }
    }

    public bool TryResetUsingSecretQuestion(ResetPasswordRequest request)
    {
        Console.WriteLine("Reset password using secret question");
        while (true)
        {
            Console.WriteLine("1 - Answer secret question\n2 - Don`t have an answer to secret question");

            var choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                Console.WriteLine("Enter name of your first childhood pet(type 0 to cancel): ");

                var petName = Console.ReadLine() ?? string.Empty;

                petName = petName.Trim();

                if (petName == "0")
                {
                    continue;
                }

                if (petName == string.Empty)
                {
                    Console.WriteLine("Incorrect name");
                    continue;
                }

                //UpdatePassword(request.NewPassword, request.Username);

                return true;
            }

            if (choice == "2")
                return false;

            Console.WriteLine("Incorrect command");
            continue;
        }
    }
}
