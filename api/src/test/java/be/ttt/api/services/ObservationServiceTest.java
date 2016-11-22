package be.ttt.api.services;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.ttt.api.AppConfig;
import be.ttt.api.TestData;
import be.ttt.api.entities.Observation;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class ObservationServiceTest {
	
	@Autowired
	private ObservationService observationServiceImpl;

	private Observation observation;

	@Before
	public void before() {
		observation = TestData.ObservationData.Observation();
		observationServiceImpl.addObservation(observation);
	}

	@Test
	public void testAddObservationAndGetById() {
		Observation fromService = observationServiceImpl.getById(observation.getId());
		checkProperties(observation, fromService);
	}

	private void checkProperties(Observation test, Observation fromService) {
		assertEquals(test.getAirPressure(), fromService.getAirPressure(), 0);
		assertEquals(test.getHumidity(), fromService.getHumidity(), 0);
		assertEquals(test.getId(), fromService.getId());
		assertEquals(test.getRegionId(), fromService.getRegionId());
		assertEquals(test.getTemp(), fromService.getTemp(), 0);
	}
}