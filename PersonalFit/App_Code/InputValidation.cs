using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>

public class InputValidation
{
    public InputValidation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool ValidatePassword(String p1, String p2)
    {
        bool pass = true;
        if(p1.Equals(p2) == false)
        {
            pass = false;
        }
        return pass;
    }

    public static bool ValidatePhoneNumber(String pnum)
    {
        bool pass = true;
        String tempNum = pnum;
        if (tempNum.Contains("(")) tempNum.Replace("(", "");
        if (tempNum.Contains(")")) tempNum.Replace("(", "");
        if (tempNum.Contains(".")) tempNum.Replace("(", "");
        if (tempNum.Contains(" ")) tempNum.Replace("(", "");

        if (tempNum.Length != 10)
            pass = false;
        // TODO: check for the String numbers
        return pass;
    }

    public static bool ValidateName(String input)
    {
        bool pass = true;
        var possitiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");

        if (possitiveIntRegex.IsMatch(input) == false)
            pass = false;
        if (input.Trim().Length < 1)
            pass = false;
        return pass;
    }

    public static bool ValidateUserInput(String input)
    {
        bool pass = true;

        var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");

        if (positiveIntRegex.IsMatch(input) == false)
            pass = false;

        if (input.Length < 7 || input.Length > 15)
            pass = false;

        return pass;
    }

    public static bool ValidateEmail(String email)
    {
        bool pass = true;

        int index1 = email.IndexOf("@");
        int index2 = email.LastIndexOf("@");

        int num = email.Split('@').Length - 1;

        if (num > 1)
            pass = false;

        if (index1 != index2)
            pass = false;

        if (email.Trim() == "")
            pass = false;

        return pass;
    }
}
