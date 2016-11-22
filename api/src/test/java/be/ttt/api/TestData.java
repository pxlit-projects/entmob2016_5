package be.ttt.api;

import java.util.Arrays;

import be.ttt.api.entities.*;

public class TestData {
	public static class WarehouseData{
		public final static int ID = 1;
		public final static String NAME = "testWarehouse";
		public final static Region[] REGION_ARRAY = { new Region(), new Region() };
		
		public static final Warehouse Warehouse(){
			Warehouse w = new Warehouse();
			w.setId(ID);
			w.setName(NAME);
			w.setRegions(Arrays.asList(REGION_ARRAY));
			return w;
		}
	}
	
	public static class RegionData{
		public final static int ID = 1;
		public final static String NAME = "testRegion";
		public final static Observation[] OBSERVATION_ARRAY = { new Observation(), new Observation() };
		public final static Rack[] RACK_ARRAY = { new Rack(), new Rack() };
		public final static int WAREHOUSE_ID = 1;
		
		public static final Region Region(){
			Region r = new Region();
			r.setId(ID);
			r.setName(NAME);
			r.setObservations(Arrays.asList(OBSERVATION_ARRAY));
			r.setRacks(Arrays.asList(RACK_ARRAY));
			r.setWarehouseId(WAREHOUSE_ID);
			return r;
		}
	}
	
	public static class RackData{
		public final static int ID = 1;
		public final static String NAME = "testRack";
		public final static Product[] PRODUCT_ARRAY = { new Product(), new Product() };
		public final static int REGION_ID = 1;
		
		public static final Rack Rack(){
			Rack r = new Rack();
			r.setId(ID);
			r.setName(NAME);
			r.setProducts(Arrays.asList(PRODUCT_ARRAY));
			r.setRegionId(REGION_ID);
			return r;
		}
	}
	
	public static class ProductData{
		public final static int ID = 1;
		public final static double MAX_AIR_PRESSURE = 1.2;
		public final static double MAX_HUMIDITY = 0.8;
		public final static double MAX_TEMP = 5;
		public final static double MIN_AIR_PRESSURE = 0.9;
		public final static double MIN_HUMIDITY = 0.6;
		public final static double MIN_TEMP = 2.2;
		public final static String NAME = "testProduct";
		public final static int RACK_ID = 1;
		
		public static final Product Product(){
			Product p = new Product();
			p.setId(ID);
			p.setMaxAirPressure(MAX_AIR_PRESSURE);
			p.setMaxHumidity(MAX_HUMIDITY);
			p.setMaxTemp(MAX_TEMP);
			p.setMinAirPressure(MIN_AIR_PRESSURE);
			p.setMinHumidity(MIN_HUMIDITY);
			p.setMinTemp(MIN_TEMP);
			p.setName(NAME);
			p.setRackId(RACK_ID);
			return p;
		}
	}
	
	public static class ObservationData{
		public final static double AIR_PRESSURE = 0.8;
		public final static double HUMIDITY = 0.75;
		public final static int ID = 1;
		public final static int REGION_ID = 1;
		public final static double TEMP = 4.2;
		
		public static final Observation Observation(){
			Observation o = new Observation();
			o.setAirPressure(AIR_PRESSURE);
			o.setHumidity(HUMIDITY);
			o.setId(ID);
			o.setRegionId(REGION_ID);
			o.setTemp(TEMP);
			return o;
		}
	}
}