using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility;
public interface IPasswordResetManager
{
    bool TryResetUsingEmail(ResetPasswordRequest request);
    bool TryResetUsingBackupEmail(ResetPasswordRequest request);

    bool TryResetUsingPhoneNumber(ResetPasswordRequest request);
    bool TryResetUsingSecretQuestion(ResetPasswordRequest request);
}
