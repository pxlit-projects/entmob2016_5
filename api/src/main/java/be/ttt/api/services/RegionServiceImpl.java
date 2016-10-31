package be.ttt.api.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import be.ttt.api.entities.Region;
import be.ttt.api.repositories.RegionRepository;

public class RegionServiceImpl implements RegionService {
	
	@Autowired
	private RegionRepository regionRepository;

	public List<Region> getAll() {
		return (List<Region>) regionRepository.findAll();
	}

	public Region getById(int id) {
		return regionRepository.findOne(id);
	}

	public List<Region> getByWarehouseId(int id) {
		return regionRepository.findAllByWarehouseId(id);
	}

	public Region addRegion(Region region) {
		return regionRepository.save(region);
	}

	public Region updateRegion(Region region) {
		return regionRepository.save(region);
	}

	public void deleteRegion(int id) {
		regionRepository.delete(id);
	}
}