using ChainOfResponsibility.ResetPasswordHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.ResetPasswordHadler;
public class ResetUsingEmailHandler : AbstractPasswordResetHandler
{
    public ResetUsingEmailHandler(IPasswordResetManager passwordResetManager) : base(passwordResetManager)
    {
    }

    public override string Handle(ResetPasswordRequest request)
    {
        if (this._passwordResetManager.TryResetUsingEmail(request))
        {
            return "Your password has been reset.";
        }

        return base.Handle(request);
    }
}
