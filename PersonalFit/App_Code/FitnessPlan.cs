using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FitnessPlan
/// </summary>
public class FitnessPlan
{
    public int fitnessID { get; set; }
    public string strengthGoal { get; set; }
    public int weightGoal { get; set; }
    public List<Routine> routines { get; set; }

    public FitnessPlan()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}