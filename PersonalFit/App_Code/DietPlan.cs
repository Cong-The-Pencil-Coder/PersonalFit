using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DietPlan
/// </summary>
public class DietPlan
{
    public int dietID { get; set; }
    public int dailyCalories { get; set; }
    public List<Meal> meals { get; set; }

    public DietPlan()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}