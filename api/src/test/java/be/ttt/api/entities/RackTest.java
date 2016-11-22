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
import be.ttt.api.entities.Rack;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class RackTest {

	private Rack rack;

	@Before
	public void initializeRack() {
		rack = new Rack();
	}

	@Test
	public void testSetAndGetId() {
		rack.setId(TestData.RackData.ID);
		assertEquals(TestData.RackData.ID, rack.getId());
	}

	@Test
	public void testSetAndGetName() {
		rack.setName(TestData.RackData.NAME);
		assertEquals(TestData.RackData.NAME, rack.getName());
	}

	@Test
	public void testSetAndGetProducts() {
		rack.setProducts(Arrays.asList(TestData.RackData.PRODUCT_ARRAY));
		assertEquals(TestData.RackData.PRODUCT_ARRAY.length, rack.getProducts().size());
	}

	@Test
	public void testSetAndGetRegionId() {
		rack.setRegionId(TestData.RackData.REGION_ID);
		assertEquals(TestData.RackData.REGION_ID, rack.getRegionId());
	}
}