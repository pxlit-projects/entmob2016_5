package be.ttt.api.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.ttt.api.entities.Rack;
import be.ttt.api.repositories.RackRepository;

@Service
public class RackServiceImpl implements RackService {

	@Autowired
	private RackRepository rackRepository;

	public List<Rack> getAll() {
		return (List<Rack>) rackRepository.findAll();
	}

	public Rack getById(int id) {
		return rackRepository.findOne(id);
	}

	public List<Rack> getByRegionId(int id) {
		return rackRepository.findAllByRegionId(id);
	}

	public Rack addRack(Rack rack) {
		return rackRepository.save(rack);
	}

	public Rack updateRack(Rack rack) {
		return rackRepository.save(rack);
	}

	public void deleteRack(int id) {
		rackRepository.delete(id);
	}
}