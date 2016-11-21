package be.ttt.api.controllers;

import be.ttt.api.entities.Warehouse;
import be.ttt.api.services.WarehouseService;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@Secured({"ROLE_USER"})
public class WarehouseController {
	@Autowired
	private WarehouseService warehouseServiceImpl;

	@RequestMapping(value = "/warehouses", method = RequestMethod.GET)
	public List<Warehouse> getAll(){
		return warehouseServiceImpl.getAll();
	}

	@RequestMapping(value = "/warehouse/{id}", method = RequestMethod.GET)
	public Warehouse getById(@PathVariable int id) {
		return warehouseServiceImpl.getById(id);
	}

	@RequestMapping(value = "/warehouses", method = RequestMethod.POST)
	public Warehouse add(@RequestBody Warehouse input) {
		return warehouseServiceImpl.addWarehouse(input);
	}

	@RequestMapping(value = "/warehouses", method = RequestMethod.PUT)
	public Warehouse update(@RequestBody Warehouse input) {
		return warehouseServiceImpl.updateWarehouse(input);
	}

	@RequestMapping(value = "/warehouse/{id}", method = RequestMethod.DELETE)
	public void delete(@PathVariable int id) {
		warehouseServiceImpl.deleteWarehouse(id);
	}
}