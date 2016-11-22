package be.ttt.api.controllers;

import be.ttt.api.entities.Observation;
import be.ttt.api.services.ObservationService;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ObservationController {
	@Autowired
	private ObservationService observationServiceImpl;

	@RequestMapping(value = "/observations", method = RequestMethod.GET)
	public List<Observation> getAll() throws Exception {
		return observationServiceImpl.getAll();
	}

	@RequestMapping(value = "/observation/{id}", method = RequestMethod.GET)
	public Observation getById(@PathVariable int id) {
		return observationServiceImpl.getById(id);
	}

	@RequestMapping(value = "/observations", method = RequestMethod.POST)
	public Observation add(@RequestBody Observation input) {
		return observationServiceImpl.addObservation(input);
	}

	@RequestMapping(value = "/observations", method = RequestMethod.PUT)
	public Observation update(@RequestBody Observation input) {
		return observationServiceImpl.updateObservation(input);
	}

	@RequestMapping(value = "/observation/{id}", method = RequestMethod.DELETE)
	public void delete(@PathVariable int id) {
		observationServiceImpl.deleteObservation(id);
	}
}