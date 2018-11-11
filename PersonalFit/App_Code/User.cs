using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{
    public string username { get; set; }
    public string password { get; set; }
    public int userID { get; set; }
    public User(string uname, string upass)
    {
        this.username = uname;
        this.password = upass;
        userID = Util.userID++;
    }
}
