package be.ttt.api.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import be.ttt.api.entities.Observation;
import be.ttt.api.entities.Product;

public interface ProductRepository extends CrudRepository<Product, Integer> {
	public List<Product> findAllByRackId(int id);
	@Query("SELECT p FROM Product p WHERE "+
				":#{#observation.temp} < p.minTemp OR "+
				":#{#observation.temp} > p.maxTemp OR "+
				":#{#observation.humidity} < p.minHumidity OR "+
				":#{#observation.humidity} > p.maxHumidity OR "+
				":#{#observation.airPressure} < p.minAirPressure OR "+
				":#{#observation.airPressure} > p.maxAirPressure ")
	public List<Product> findAllInDanger(@Param("observation") Observation o);
}