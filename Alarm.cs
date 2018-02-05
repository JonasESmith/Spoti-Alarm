using System;
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
    string   name;
    int      hour;
    int      minute;
    int      second;
    string   days;
    TimeSpan alarmTime;
    

    public Alarm()
    {
      name   = "0";
      hour   = 0;
      days   = "0"; 
      minute = 0;
      second = 0;
    }

    public Alarm(string Name, int Hour, int Minute, int Second, string Days)
    {

      name      = Name;
      hour      = Hour;
      days      = Days;
      second    = Second;
      minute    = Minute;
      alarmTime = new TimeSpan(Hour, Minute,0);
    }

    public TimeSpan AlarmTime
    {
      get
      {
        return (alarmTime);
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

    public string Days
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
