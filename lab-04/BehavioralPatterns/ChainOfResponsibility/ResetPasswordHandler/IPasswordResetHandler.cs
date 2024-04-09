namespace ChainOfResponsibility.ResetPasswordHandler;
public interface IPasswordResetHandler
{
    IPasswordResetHandler SetNext(IPasswordResetHandler handler);

    string Handle(ResetPasswordRequest resetPasswordRequest);
}
