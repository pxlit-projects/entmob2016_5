package be.ttt.api.entities;

import javax.persistence.*;

@Entity
@Table(name = "products")
public class Product {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private String name;
	private int rackId;
	private double minTemp;
	private double maxTemp;
	private double minHumidity;
	private double maxHumidity;
	private double minAirPressure;
	private double maxAirPressure;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getRackId() {
		return rackId;
	}

	public void setRackId(int rackId) {
		this.rackId = rackId;
	}

	public double getMinTemp() {
		return minTemp;
	}

	public void setMinTemp(double minTemp) {
		this.minTemp = minTemp;
	}

	public double getMaxTemp() {
		return maxTemp;
	}

	public void setMaxTemp(double maxTemp) {
		this.maxTemp = maxTemp;
	}

	public double getMinHumidity() {
		return minHumidity;
	}

	public void setMinHumidity(double minHumidity) {
		this.minHumidity = minHumidity;
	}

	public double getMaxHumidity() {
		return maxHumidity;
	}

	public void setMaxHumidity(double maxHumidity) {
		this.maxHumidity = maxHumidity;
	}

	public double getMinAirPressure() {
		return minAirPressure;
	}

	public void setMinAirPressure(double minAirPressure) {
		this.minAirPressure = minAirPressure;
	}

	public double getMaxAirPressure() {
		return maxAirPressure;
	}

	public void setMaxAirPressure(double maxAirPressure) {
		this.maxAirPressure = maxAirPressure;
	}
}