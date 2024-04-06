using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.ResetPasswordHadler;
public class AbstractPasswordResetHandler : IPasswordResetHandler
{
    private IPasswordResetHandler _nextHandler;
    protected IPasswordResetManager _passwordResetManager;

    public AbstractPasswordResetHandler(IPasswordResetManager passwordResetManager)
    {
        this._passwordResetManager = passwordResetManager;
    }

    public IPasswordResetHandler SetNext(IPasswordResetHandler handler)
    {
        _nextHandler = handler;

        return handler;
    }

    public virtual string Handle(ResetPasswordRequest request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        else
        {
            return "Cannot reset your password.";
        }
    }
}
