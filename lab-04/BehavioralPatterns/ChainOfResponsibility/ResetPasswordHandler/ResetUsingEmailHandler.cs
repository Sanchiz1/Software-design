namespace ChainOfResponsibility.ResetPasswordHandler;
public class ResetUsingEmailHandler : AbstractPasswordResetHandler
{
    public ResetUsingEmailHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (_passwordResetManager.TryResetUsingEmail(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
