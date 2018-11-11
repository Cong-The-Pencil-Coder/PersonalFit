using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FrontEndUser
/// </summary>
public class FrontEndUser : User
{
    public string name { get; set; }
    public int age { get; set; }
    public FrontEndUser(string uname, string upass, string name, int age): base(uname, upass)
    {
        this.name = name;
        this.age = age;
    }
}