using System;

public class AlarmClock
{
    private DateTime _alarmTime;
    private Timer _timer;

    // 闹钟的Tick事件
    public event EventHandler Tick;

    // 闹钟的Alarm事件
    public event EventHandler Alarm;

    // 构造函数，设置闹钟的时间
    public AlarmClock(DateTime alarmTime)
    {
        _alarmTime = alarmTime;
    }

    // 开始闹钟的走时
    public void Start()
    {
        _timer = new Timer(TickCallback, null, 1000, 1000);
    }

    // 停止闹钟的走时
    public void Stop()
    {
        _timer?.Change(Timeout.Infinite, 0);
    }

    // Tick事件的回调方法
    private void TickCallback(object state)
    {
        DateTime now = DateTime.Now;
        if (now >= _alarmTime)
        {
            // 如果当前时间到达或超过了设定的闹钟时间，触发Alarm事件
            OnAlarm(EventArgs.Empty);
            Stop(); // 停止走时
        }
        else
        {
            // 否则，触发Tick事件
            OnTick(EventArgs.Empty);
        }
    }

    // 触发Tick事件的方法
    protected virtual void OnTick(EventArgs e)
    {
        Tick?.Invoke(this, e);
        Console.WriteLine("Tick: The time is now {0}", DateTime.Now.ToString("HH:mm:ss"));
    }

    // 触发Alarm事件的方法
    protected virtual void OnAlarm(EventArgs e)
    {
        Alarm?.Invoke(this, e);
        Console.WriteLine("Alarm: It's time to wake up!");
    }
}

public class Program
{
    public static void Main()
    {
        // 创建一个设定为明天中午12点的闹钟
        AlarmClock alarmClock = new AlarmClock(new DateTime(2024, 3, 27, 12, 0, 0));

        // 订阅Tick事件
        alarmClock.Tick += (sender, args) => Console.WriteLine("Tick event occurred.");

        // 订阅Alarm事件
        alarmClock.Alarm += (sender, args) => Console.WriteLine("Alarm event occurred.");

        // 启动闹钟
        alarmClock.Start();

        // 等待闹钟事件触发（为了演示，这里简单地等待一段时间）
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}