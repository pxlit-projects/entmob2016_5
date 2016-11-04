package be.ttt.api.services;

import be.ttt.api.entities.Observation;

import java.util.List;

public interface ObservationService {
	public List<Observation> getAll();
	public Observation getById(int id);
	public List<Observation> getByRegionId(int id);
	public Observation getLastByRegionId(int id);
	public Observation addObservation(Observation observation);
	public Observation updateObservation(Observation observation);
	public void deleteObservation(int id);
}