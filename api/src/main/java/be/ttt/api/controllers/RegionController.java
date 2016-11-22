package be.ttt.api.controllers;

import be.ttt.api.entities.Region;
import be.ttt.api.services.RegionService;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class RegionController {
	@Autowired
	private RegionService regionServiceImpl;

	@RequestMapping(value = "/regions", method = RequestMethod.GET)
	public List<Region> getAll() {
		return regionServiceImpl.getAll();
	}

	@RequestMapping(value = "/region/{id}", method = RequestMethod.GET)
	public Region getById(@PathVariable int id) {
		return regionServiceImpl.getById(id);
	}

	@RequestMapping(value = "/regions", method = RequestMethod.POST)
	public Region add(@RequestBody Region input) {
		return regionServiceImpl.addRegion(input);
	}

	@RequestMapping(value = "/regions", method = RequestMethod.PUT)
	public Region update(@RequestBody Region input) {
		return regionServiceImpl.updateRegion(input);
	}

	@RequestMapping(value = "/region/{id}", method = RequestMethod.DELETE)
	public void delete(@PathVariable int id) {
		regionServiceImpl.deleteRegion(id);
	}
}