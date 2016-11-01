package be.ttt.api.controllers;

import be.ttt.api.entities.Rack;
import be.ttt.api.services.RackService;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class RackController implements ICrudController<Rack> {
	@Autowired
	private RackService rackServiceImpl;

	@RequestMapping(value = "/racks", method = RequestMethod.GET)
	public List<Rack> getAll() {
		return rackServiceImpl.getAll();
	}

	@RequestMapping(value = "/rack/{id}", method = RequestMethod.GET)
	public Rack getById(@PathVariable int id) {
		return rackServiceImpl.getById(id);
	}

	@RequestMapping(value = "/racks", method = RequestMethod.POST)
	public Rack add(@RequestBody Rack input) {
		return rackServiceImpl.addRack(input);
	}

	@RequestMapping(value = "/racks", method = RequestMethod.PUT)
	public Rack update(@RequestBody Rack input) {
		return rackServiceImpl.updateRack(input);
	}

	@RequestMapping(value = "/rack/{id}", method = RequestMethod.DELETE)
	public void delete(@PathVariable int id) {
		rackServiceImpl.deleteRack(id);
	}
}