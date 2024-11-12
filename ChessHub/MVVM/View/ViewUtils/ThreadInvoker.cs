using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient.MVVM.View
{
    public static class ThreadInvoker
    {
        public static void InvokeOnThread(this Form form, Action action)
        {
            if (form.InvokeRequired)
                form.Invoke(action);
        }
    }
}
