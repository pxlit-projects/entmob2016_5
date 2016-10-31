package be.ttt.api.entities;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@Table(name = "regions")
public class Region {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private String name;
	private int warehouseId;

	@OneToMany(mappedBy="regionId")
	@JsonIgnore
	private List<Rack> racks = new ArrayList<Rack>();
	
	@OneToMany(mappedBy="regionId")
	@JsonIgnore
	private List<Observation> observations = new ArrayList<Observation>();
	
	public int getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public int getWarehouseId() {
		return warehouseId;
	}
	public List<Rack> getRacks(){
		return racks;
	}
}