public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int _month;
    private int _year;
    
    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int startDay = schedule switch
        {
            Schedule.Teenth => 13,
            Schedule.First => 1,
            Schedule.Second => 8,
            Schedule.Third => 15,
            Schedule.Fourth => 22,
            Schedule.Last => DateTime.DaysInMonth(_year, _month),
            _ => throw new ArgumentOutOfRangeException(nameof(schedule), schedule, null)
        };
        DateTime current = new DateTime(_year, _month, startDay);
        if (schedule != Schedule.Last)
        {
            while (dayOfWeek != current.DayOfWeek)
            {
                current = current.AddDays(1);
            }            
        }
        else
        {
            while (dayOfWeek != current.DayOfWeek)
            {
                current = current.Subtract(TimeSpan.FromDays(1));
            }  
        }
        
        return current;
    }
}