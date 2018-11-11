using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer: FrontEndUser
{
    public double height { get; set; }
    public double weight { get; set; }
    public char sex { get; set; }
    public Customer(string uname, string upass, string name, int age, double h, double w, char s):base(uname, upass, name, age)
    {
        this.height = h;
        this.weight = w;
        this.sex = s;
    }
}