package be.ttt.api.repositories;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.ttt.api.entities.Region;

@Repository
public interface RegionRepository extends CrudRepository<Region,Integer>{
	public List<Region> findAllByWarehouseId(int id);
}