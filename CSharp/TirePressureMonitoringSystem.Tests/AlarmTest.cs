using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void WhenPressureIsInRangeAlarmStaysOff()
        {
            // ARRANGE
            ISensor fakeSensor = new FakeSensor(18);
            Alarm alarm = new Alarm(fakeSensor);

            //ACT
            alarm.Check();

            //ASSERT
            Assert.False(alarm.AlarmOn);
        }
        
        [Fact]
        public void WhenPressureIsInUnderMinValueAlarmTurnsOn()
        {
            // ARRANGE
            ISensor fakeSensor = new FakeSensor(16);
            Alarm alarm = new Alarm(fakeSensor);

            //ACT
            alarm.Check();

            //ASSERT
            Assert.True(alarm.AlarmOn);
        }

    }

    public class FakeSensor : ISensor
    {
        private int pressure;

        public FakeSensor(int fixedPressure)
        {
            this.pressure = fixedPressure;
        }

        public double PopNextPressurePsiValue()
        {
            return this.pressure;
        }
    }
}