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
import be.ttt.api.entities.Warehouse;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class WarehouseTest {

	private Warehouse warehouse;

	@Before
	public void initializeWarehouse() {
		warehouse = new Warehouse();
	}

	@Test
	public void testSetAndGetId() {
		warehouse.setId(TestData.WarehouseData.ID);
		assertEquals(TestData.WarehouseData.ID, warehouse.getId());
	}

	@Test
	public void testSetAndGetName() {
		warehouse.setName(TestData.WarehouseData.NAME);
		assertEquals(TestData.WarehouseData.NAME, warehouse.getName());
	}

	@Test
	public void testSetAndGetRegions() {
		warehouse.setRegions(Arrays.asList(TestData.WarehouseData.REGION_ARRAY));
		assertEquals(TestData.WarehouseData.REGION_ARRAY.length, warehouse.getRegions().size());
	}
}