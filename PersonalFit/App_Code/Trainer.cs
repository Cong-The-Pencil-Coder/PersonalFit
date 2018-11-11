using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Trainer
/// </summary>
public class Trainer : FrontEndUser
{
    public int phoneNum { get; set; }
    public string certification { get; set; }
    public int avg_rating { get; set; }
    public string profilePicturePath { get; set; }
    public List<Program> programs { get; set; }
    public List<string> language { get; set; }
    public char sex { get; set; }
    
    public Trainer(string uname, string upass, string name, int age) : base(uname, upass, name, age)
    {
        
    }
}