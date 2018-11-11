using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Meal
/// </summary>
public class Meal
{
    public string name { get; set; }
    public int meal_time { get; set; }
    public DateTime meal_date { get; set; }
    public int num_calo { get; set; }
    public int protein { get; set; }
    public int fat { get; set; }
    public int carb { get; set; }

    public Meal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}