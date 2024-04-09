namespace ChainOfResponsibility.ResetPasswordHandler;
public class ResetUsingBackupEmailHandler : AbstractPasswordResetHandler
{
    public ResetUsingBackupEmailHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (_passwordResetManager.TryResetUsingBackupEmail(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
