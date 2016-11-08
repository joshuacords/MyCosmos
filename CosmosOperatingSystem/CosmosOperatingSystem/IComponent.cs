using System;
using System.Collections.Generic;

public interface IComponent
{
    bool contains(string cmd);
    string executeIfContains(string cmd, string[] args);
    List<string> getCommands();
}
