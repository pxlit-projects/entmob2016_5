package be.ttt.api.services;

import be.ttt.api.entities.Rack;
import java.util.List;

public interface RackService {
	public List<Rack>getAll();
	public Rack getById(int id);
	public List<Rack> getByRegionId(int id);
	public Rack addRack(Rack rack);
	public Rack updateRack(Rack rack);
	public void deleteRack(int id);
}