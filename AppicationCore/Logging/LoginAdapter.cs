using BizCover.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BizCover.ApplicationCore.Logging
{
    public class LoginAdapter<T> : IAppLogger<T>
    {
        public void LogInformation(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
