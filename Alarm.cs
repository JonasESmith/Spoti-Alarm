﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//     <summary>
//        LibAlarm
//     </summary>

namespace SpotiAlarm
{
  class Alarm
  {
    string name;
    string time;
    int    hour;
    int    minute;
    int    second;
    int    days;
    

    public Alarm()
    {
      name   = "";
      hour   = 0;
      days   = 0; 
      minute = 0;
      second = 0;
    }

    public Alarm(string Name, int Hour, int Minute, int Second, int Days)
    {

      name   = Name;
      hour   = Hour;
      days   = Days;
      second = Second;
      minute = Minute;

    }

    public string Time
    {
      get
      {
        return (this.hour + ":" + this.minute);
      }
    }

    public int Hour
    {
      get
      {
        return hour;
      }
      set
      {
        hour = value;
      }
    }

    public int Minute
    {
      get
      {
        return minute;
      }
      set
      {
        minute = value;
      }
    }

    public int Second
    {
      get
      {
        return second;
      }
      set
      {
        second = value;
      }
    }

    public int Days
    {
      get
      {
        return days;
      }
      set
      {
        days = value;
      }
    }

    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
      }
    }

  }
}
