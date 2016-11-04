package be.ttt.api.entities;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

import com.fasterxml.jackson.annotation.JsonIgnore;

@Entity
@Table(name = "racks")
public class Rack {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private String name;
	private int regionId;

	@OneToMany(mappedBy="rackId")
	@JsonIgnore
	private List<Product> products = new ArrayList<Product>();
	
	public int getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public int getRegionId() {
		return regionId;
	}
	public List<Product> getProducts(){
		return products;
	}
}