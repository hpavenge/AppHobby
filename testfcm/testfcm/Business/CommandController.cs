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
    List<ICommand> authorisationCommands;

    public CommandController()
    {
        authorisationCommands = new List<ICommand>();
    }

    public void setCommand(int slot, ICommand command)
    {
        authorisationCommands.Add(command);
    }

    public void launchCommand(int slot)
    {
        authorisationCommands[slot].execute();
    }

    public String toString()
    {
        string info = "";
        for (int i = 0; i < authorisationCommands.Count; i++)
        {
            info += "slot:" + i + "Has command:" + authorisationCommands[i].GetType();
        }
        return info;
    }
}
}