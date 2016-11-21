package be.ttt.api.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.ttt.api.entities.Warehouse;

@Repository
public interface WarehouseRepository extends CrudRepository<Warehouse,Integer>{
	@Query("select w.id, w.name from Warehouse w")
	public List<Warehouse> getWarehouses();
}