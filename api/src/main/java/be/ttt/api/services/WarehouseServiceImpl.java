package be.ttt.api.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.ttt.api.entities.Warehouse;
import be.ttt.api.repositories.WarehouseRepository;

@Service
public class WarehouseServiceImpl implements WarehouseService {

	@Autowired
	private WarehouseRepository warehouseRepository;

	public List<Warehouse> getAll() {
		return (List<Warehouse>) warehouseRepository.findAll();
	}

	public Warehouse getById(int id) {
		return warehouseRepository.findOne(id);
	}

	public Warehouse addWarehouse(Warehouse warehouse) {
		return warehouseRepository.save(warehouse);
	}

	public Warehouse updateWarehouse(Warehouse warehouse) {
		return warehouseRepository.save(warehouse);
	}

	public void deleteWarehouse(int id) {
		warehouseRepository.delete(id);
	}
}