using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using testfcm.Business.Command;

namespace testfcm.Business
{
    class CommandController
    { 
    List<ICommand> _authorisationCommands;

    public CommandController()
    {
        _authorisationCommands = new List<ICommand>();
    }

    public void SetCommand(int slot, ICommand command)
    {
        _authorisationCommands.Add(command);
    }

    public void LaunchCommand(int slot)
    {
        _authorisationCommands[slot].Execute();
    }

    public String toString()
    {
        string info = "";
        for (int i = 0; i < _authorisationCommands.Count; i++)
        {
            info += "slot:" + i + "Has command:" + _authorisationCommands[i].GetType();
        }
        return info;
    }
}
}