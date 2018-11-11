using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Program
/// </summary>
public class Program
{
    public string name { get; set; }
    public int price { get; set; }
    public int durationInWeeks { get; set; }
    public string focus { get; set; }
    public FitnessPlan fit_plan { get; set; }
    public DietPlan diet_plan { get; set; }

    public Program()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}