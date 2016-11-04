package be.ttt.api.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import be.ttt.api.entities.Observation;
import be.ttt.api.repositories.ObservationRepository;

public class ObservationServiceImpl implements ObservationService {

	@Autowired
	private ObservationRepository observationRepository;

	public List<Observation> getAll() {
		return (List<Observation>) observationRepository.findAll();
	}

	public Observation getById(int id) {
		return observationRepository.findOne(id);
	}

	public List<Observation> getByRegionId(int id) {
		return observationRepository.findAllByRegionId(id);
	}
	
	public Observation getLastByRegionId(int id) {
		return observationRepository.findTopByRegionIdOrderByIdDesc(id);
	}

	public Observation addObservation(Observation observation) {
		return observationRepository.save(observation);
	}

	public Observation updateObservation(Observation observation) {
		return observationRepository.save(observation);
	}

	public void deleteObservation(int id) {
		observationRepository.delete(id);
	}
}