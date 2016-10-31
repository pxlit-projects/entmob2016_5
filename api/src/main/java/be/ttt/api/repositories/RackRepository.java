package be.ttt.api.repositories;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import be.ttt.api.entities.Rack;

public interface RackRepository extends CrudRepository<Rack, Integer> {
	public List<Rack> findAllByRegionId(int id);

}