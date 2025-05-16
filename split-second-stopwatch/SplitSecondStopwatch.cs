using System.Collections.ObjectModel;

public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
    public StopwatchState State { get; private set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap
    {
        get
        {
            if (State == StopwatchState.Running)
            {
                return _elapsed + time.GetElapsedTime(_start); 
            }

            return _elapsed;

        }
    }

    public TimeSpan Total => CurrentLap + PreviousLaps.Aggregate(TimeSpan.Zero, (x, y) => x + y);
    public IReadOnlyCollection<TimeSpan> PreviousLaps => new ReadOnlyCollection<TimeSpan>(_previousLaps);
    private long _start = time.GetTimestamp();
    private TimeSpan _elapsed = TimeSpan.Zero;
    private List<TimeSpan> _previousLaps = [];

    public void Start()
    {
        if (State == StopwatchState.Running)
        {
            throw new InvalidOperationException("Can't start when running");
        }

        State = StopwatchState.Running;
        _start = time.GetTimestamp();
    }

    public void Stop()
    {
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Can only stop when running");
        }
        State = StopwatchState.Stopped;
        _elapsed += time.GetElapsedTime(_start);
        _start = time.GetTimestamp();
    }

    public void Reset()
    {
        if (State != StopwatchState.Stopped)
        {
            throw new InvalidOperationException("Can only reset when stopped");
        }

        State = StopwatchState.Ready;
        _previousLaps = [];
        _start = time.GetTimestamp();
        _elapsed = TimeSpan.Zero;
    }

    public void Lap()
    {
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Can only lap when running");
        }

        _previousLaps.Add(CurrentLap);
        _elapsed = TimeSpan.Zero;
        _start = time.GetTimestamp();

    }
}
