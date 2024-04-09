namespace ChainOfResponsibility;
public interface IPasswordResetManager
{
    bool TryResetUsingEmail(ResetPasswordRequest request);
    bool TryResetUsingBackupEmail(ResetPasswordRequest request);

    bool TryResetUsingPhoneNumber(ResetPasswordRequest request);
    bool TryResetUsingSecretQuestion(ResetPasswordRequest request);
}
