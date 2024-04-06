using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.ResetPasswordHadler;
public interface IPasswordResetHandler
{
    IPasswordResetHandler SetNext(IPasswordResetHandler handler);

    string Handle(ResetPasswordRequest resetPasswordRequest);
}
