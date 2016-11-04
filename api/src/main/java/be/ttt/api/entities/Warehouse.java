package be.ttt.api.entities;

import java.util.*;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@Table(name = "warehouses")
public class Warehouse {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private String name;
	
	@OneToMany(mappedBy="warehouseId")
	@JsonIgnore
	private List<Region> regions = new ArrayList<Region>();
	
	public int getId() {
		return id;
	}
	public String getName() {
		return name;
	}
	public List<Region> getRegions(){
		return regions;
	}
}