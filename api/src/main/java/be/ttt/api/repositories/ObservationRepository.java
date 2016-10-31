package be.ttt.api.repositories;

import java.util.List;
import org.springframework.data.repository.CrudRepository;

import be.ttt.api.entities.Observation;

public interface ObservationRepository extends CrudRepository<Observation, Integer> {
	public List<Observation> findAllByRegionId(int id);
	public Observation findTopByRegionIdOrderByIdDesc(int regionId);
}