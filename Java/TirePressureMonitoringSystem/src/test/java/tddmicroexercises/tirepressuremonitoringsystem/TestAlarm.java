package tddmicroexercises.tirepressuremonitoringsystem;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

public class TestAlarm
{

    @Test
    public void alarme_est_off_quand_la_pression_est_correct()
    {
        Sensor stub = Mockito.mock(Sensor.class);
        Mockito.when(stub.popNextPressurePsiValue()).thenReturn(18.0);
        Alarm alarm = new Alarm(stub);
        alarm.check();
        assertFalse(alarm.isAlarmOn());
    }

    @Test
    public void alarme_est_on_quand_la_pression_est_trop_haute()
    {
        Sensor stub = Mockito.mock(Sensor.class);
        Mockito.when(stub.popNextPressurePsiValue()).thenReturn(21.01);
        Alarm alarm = new Alarm(stub);
        alarm.check();
        assertTrue(alarm.isAlarmOn());
    }

    @Test
    public void alarme_est_on_quand_la_pression_est_trop_basse()
    {
        Sensor stub = Mockito.mock(Sensor.class);
        Mockito.when(stub.popNextPressurePsiValue()).thenReturn(16.99);
        Alarm alarm = new Alarm(stub);
        alarm.check();
        assertTrue(alarm.isAlarmOn());
    }
}
