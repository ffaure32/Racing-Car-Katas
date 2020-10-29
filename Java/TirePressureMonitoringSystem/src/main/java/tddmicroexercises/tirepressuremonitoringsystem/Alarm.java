package tddmicroexercises.tirepressuremonitoringsystem;

public class Alarm
{
    private final double LowPressureThreshold  = 17;
    private final double HighPressureThreshold = 21;

    Sensor               sensor                = new Sensor();

    boolean              alarmOn               = false;

    public Alarm()
    {

    }

    public Alarm(Sensor sensor)
    {
        this.sensor = sensor;
    }

    public void check()
    {
        double psiPressureValue = sensor.popNextPressurePsiValue();

        if (psiPressureValue < LowPressureThreshold || psiPressureValue > HighPressureThreshold)
        {
            alarmOn = true;
        }
    }

    public boolean isAlarmOn()
    {
        return alarmOn;
    }
}
