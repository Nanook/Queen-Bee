using System;
using System.Collections.Generic;
using System.Text;

namespace Nanook.QueenBee
{
    internal class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs(string title, string message)
        {
            Title = title;
            Message = message;
            Exception = null;
        }

        public ErrorEventArgs(string title, Exception ex)
        {
            Title = title;
            Message = string.Empty;
            Exception = ex;
        }

        public readonly string Title;
        public readonly string Message;
        public readonly Exception Exception;
    }
}
