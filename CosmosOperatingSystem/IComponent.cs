using System;

public interface IComponent
{
    public string executeIfContains(string cmd, List<string> args);
    public Boolean contains(string cmd);
}
