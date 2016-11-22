package be.ttt.api.entities;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.ttt.api.AppConfig;
import be.ttt.api.TestData;
import be.ttt.api.entities.Product;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = AppConfig.class)
public class ProductTest {

	private Product product;

	@Before
	public void initializeProduct() {
		product = new Product();
	}

	@Test
	public void testSetAndGetId() {
		product.setId(TestData.ProductData.ID);
		assertEquals(TestData.ProductData.ID, product.getId());
	}

	@Test
	public void testSetAndGetMaxAirPressure() {
		product.setMaxAirPressure(TestData.ProductData.MAX_AIR_PRESSURE);
		assertEquals(TestData.ProductData.MAX_AIR_PRESSURE, product.getMaxAirPressure(), 0);
	}

	@Test
	public void testSetAndGetMaxHumidity() {
		product.setMaxHumidity(TestData.ProductData.MAX_HUMIDITY);
		assertEquals(TestData.ProductData.MAX_HUMIDITY, product.getMaxHumidity(), 0);
	}

	@Test
	public void testSetAndGetMaxTemp() {
		product.setMaxTemp(TestData.ProductData.MAX_TEMP);
		assertEquals(TestData.ProductData.MAX_TEMP, product.getMaxTemp(), 0);
	}

	@Test
	public void testSetAndGetMinAirPressure() {
		product.setMinAirPressure(TestData.ProductData.MIN_AIR_PRESSURE);
		assertEquals(TestData.ProductData.MIN_AIR_PRESSURE, product.getMinAirPressure(), 0);
	}

	@Test
	public void testSetAndGetMinHumidity() {
		product.setMinHumidity(TestData.ProductData.MIN_HUMIDITY);
		assertEquals(TestData.ProductData.MIN_HUMIDITY, product.getMinHumidity(), 0);
	}

	@Test
	public void testSetAndGetMinTemp() {
		product.setMinTemp(TestData.ProductData.MIN_TEMP);
		assertEquals(TestData.ProductData.MIN_TEMP, product.getMinTemp(), 0);
	}

	@Test
	public void testSetAndGetName() {
		product.setName(TestData.ProductData.NAME);
		assertEquals(TestData.ProductData.NAME, product.getName());
	}

	@Test
	public void testSetAndGetRackId() {
		product.setRackId(TestData.ProductData.RACK_ID);
		assertEquals(TestData.ProductData.RACK_ID, product.getRackId());
	}
}