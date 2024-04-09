namespace ChainOfResponsibility.ResetPasswordHandler;
public class ResetUsingSecretQuestionHandler : AbstractPasswordResetHandler
{
    public ResetUsingSecretQuestionHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (_passwordResetManager.TryResetUsingSecretQuestion(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
