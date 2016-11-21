package be.ttt.api.repositories;

import java.util.List;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.ttt.api.entities.Observation;

@Repository
public interface ObservationRepository extends CrudRepository<Observation, Integer> {
	public List<Observation> findAllByRegionId(int id);
	public Observation findTopByRegionIdOrderByIdDesc(int regionId);
}