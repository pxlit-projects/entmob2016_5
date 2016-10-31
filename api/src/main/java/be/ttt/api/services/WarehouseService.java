package be.ttt.api.services;

import be.ttt.api.entities.Warehouse;
import java.util.List;

public interface WarehouseService {
	public List<Warehouse>getAll();
	public Warehouse getById(int id);
	public Warehouse addWarehouse(Warehouse warehouse);
	public Warehouse updateWarehouse(Warehouse warehouse);
	public void deleteWarehouse(int id);
}