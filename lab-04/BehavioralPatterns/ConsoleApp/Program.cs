using ChainOfResponsibility;
using ChainOfResponsibility.ResetPasswordHadler;

internal class Program
{
    private static void Main(string[] args)
    {
        DemostrateChainOfResponsibility();
    }

    private static void DemostrateChainOfResponsibility()
    {
        IPasswordResetManager passwordResetManager = new PasswordResetManager();

        ResetUsingEmailHandler resetUsingEmailHandler = new ResetUsingEmailHandler(passwordResetManager); 
        ResetUsingBackupEmailHandler resetUsingBackupEmailHandler = new ResetUsingBackupEmailHandler(passwordResetManager);
        ResetUsingPhoneNumberHandler resetUsingPhoneNumberHandler = new ResetUsingPhoneNumberHandler(passwordResetManager);
        ResetUsingSecretQuestionHandler resetUsingSecretQuestionHandler = new ResetUsingSecretQuestionHandler(passwordResetManager);
        
        resetUsingEmailHandler.SetNext(resetUsingBackupEmailHandler)
            .SetNext(resetUsingPhoneNumberHandler)
            .SetNext(resetUsingSecretQuestionHandler);


        Console.WriteLine("Enter username: ");
        var username = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter new password: ");
        var newPassword = Console.ReadLine() ?? string.Empty;

        var request = new ResetPasswordRequest(username, newPassword);

        Console.WriteLine("Trying reset user password: Username - {0}, New password - {1}", request.Username, request.NewPassword);

        var res = resetUsingEmailHandler.Handle(request);

        Console.WriteLine(res);
    }
}