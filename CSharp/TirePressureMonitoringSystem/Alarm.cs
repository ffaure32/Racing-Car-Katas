namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm() : this(new SensorWrapper())
        {
            
        }
        
        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }

    public class SensorWrapper : ISensor
    {
        private Sensor _sensor = new Sensor();
        public double PopNextPressurePsiValue()
        {
            return _sensor.PopNextPressurePsiValue();
        }
    }

    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}
