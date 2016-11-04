package be.ttt.api.entities;

import javax.persistence.*;

@Entity
@Table(name = "products")
public class Product{
	@Id
	@GeneratedValue( strategy=GenerationType.IDENTITY )
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
	public String getName() {
		return name;
	}
	public double getMinTemp() {
		return minTemp;
	}
	public double getMaxTemp() {
		return maxTemp;
	}
	public double getMinHumidity() {
		return minHumidity;
	}
	public double getMaxHumidity() {
		return maxHumidity;
	}
	public double getMinAirPressure() {
		return minAirPressure;
	}
	public double getMaxAirPressure() {
		return maxAirPressure;
	}
	public int getRackId(){
		return rackId;
	}
}