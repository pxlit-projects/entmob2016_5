package be.ttt.api.entities;

import static org.junit.Assert.assertEquals;

import java.util.Arrays;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.ttt.api.AppConfig;
import be.ttt.api.TestData;
import be.ttt.api.entities.Region;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class RegionTest {

	private Region region;

	@Before
	public void initializeRegion() {
		region = new Region();
	}

	@Test
	public void testSetAndGetId() {
		region.setId(TestData.RegionData.ID);
		assertEquals(TestData.RegionData.ID, region.getId());
	}

	@Test
	public void testSetAndGetName() {
		region.setName(TestData.RegionData.NAME);
		assertEquals(TestData.RegionData.NAME, region.getName());
	}

	@Test
	public void testSetAndGetObservations() {
		region.setObservations(Arrays.asList(TestData.RegionData.OBSERVATION_ARRAY));
		assertEquals(TestData.RegionData.OBSERVATION_ARRAY.length, region.getObservations().size());
	}

	@Test
	public void testSetAndGetRacks() {
		region.setRacks(Arrays.asList(TestData.RegionData.RACK_ARRAY));
		assertEquals(TestData.RegionData.RACK_ARRAY.length, region.getRacks().size());
	}

	@Test
	public void testSetAndGetWarehouseId() {
		region.setWarehouseId(TestData.RegionData.WAREHOUSE_ID);
		assertEquals(TestData.RegionData.WAREHOUSE_ID, region.getWarehouseId());
	}
}