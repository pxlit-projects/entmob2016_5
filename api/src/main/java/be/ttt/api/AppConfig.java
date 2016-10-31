package be.ttt.api;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import be.ttt.api.services.*;

@Configuration
public class AppConfig {
	@Bean
	public WarehouseService getWarehouseService(){
		return new WarehouseServiceImpl();
	}
	@Bean
	public RegionService getRegionService(){
		return new RegionServiceImpl();
	}
	@Bean
	public RackService getRackService(){
		return new RackServiceImpl();
	}
	@Bean
	public ProductService getProductService(){
		return new ProductServiceImpl();
	}
	@Bean
	public ObservationService getObservationService(){
		return new ObservationServiceImpl();
	}
}