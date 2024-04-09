namespace ChainOfResponsibility.ResetPasswordHandler;
public class ResetUsingPhoneNumberHandler : AbstractPasswordResetHandler
{
    public ResetUsingPhoneNumberHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (_passwordResetManager.TryResetUsingPhoneNumber(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
