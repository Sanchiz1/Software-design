using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.ResetPasswordHadler;
public class ResetUsingBackupEmailHandler : AbstractPasswordResetHandler
{
    public ResetUsingBackupEmailHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (this._passwordResetManager.TryResetUsingBackupEmail(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
