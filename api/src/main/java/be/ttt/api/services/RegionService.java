package be.ttt.api.services;

import be.ttt.api.entities.Region;

import java.util.List;

public interface RegionService{
	public List<Region>getAll();
	public Region getById(int id);
	public List<Region>getByWarehouseId(int id);
	public Region addRegion(Region region);
	public Region updateRegion(Region region);
	public void deleteRegion(int id);
}