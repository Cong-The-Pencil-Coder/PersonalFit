using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Routine
/// </summary>
public class Routine
{
    public int daysOfWeek { get; set; }
    public int workTime { get; set; }
    public string muscleGroup { get; set; }
    public List<Exercise> exercise { get; set; }

    public Routine()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}