package be.ttt.api.entities;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.ttt.api.AppConfig;
import be.ttt.api.TestData;
import be.ttt.api.entities.Observation;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class ObservationTest {

	private Observation observation;

	@Before
	public void initializeObservation() {
		observation = new Observation();
	}

	@Test
	public void testSetAndGetAirPressure() {
		observation.setAirPressure(TestData.ObservationData.AIR_PRESSURE);
		assertEquals(TestData.ObservationData.AIR_PRESSURE, observation.getAirPressure(), 0);
	}

	@Test
	public void testSetAndGetHumidity() {
		observation.setHumidity(TestData.ObservationData.HUMIDITY);
		assertEquals(TestData.ObservationData.HUMIDITY, observation.getHumidity(), 0);
	}

	@Test
	public void testSetAndGetId() {
		observation.setId(TestData.ObservationData.ID);
		assertEquals(TestData.ObservationData.ID, observation.getId());
	}

	@Test
	public void testSetAndGetRegionId() {
		observation.setRegionId(TestData.ObservationData.REGION_ID);
		assertEquals(TestData.ObservationData.REGION_ID, observation.getRegionId());
	}

	@Test
	public void testSetAndGetTemp() {
		observation.setTemp(TestData.ObservationData.TEMP);
		assertEquals(TestData.ObservationData.TEMP, observation.getTemp(), 0);
	}
}