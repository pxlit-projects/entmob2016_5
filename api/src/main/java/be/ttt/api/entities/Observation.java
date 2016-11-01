package be.ttt.api.entities;

import javax.persistence.*;

@Entity
@Table(name = "observations")
public class Observation{
	@Id
	@GeneratedValue( strategy=GenerationType.IDENTITY )
	private int id;
	private int regionId;
	
	private double temp;	
	private double humidity;
	private double airPressure;
	
	public Observation(int regionId, double temp, double humidity, double airPressure) {
		super();
		this.regionId = regionId;
		this.temp = temp;
		this.humidity = humidity;
		this.airPressure = airPressure;
	}
	public Observation(){}
	public int getId() {
		return id;
	}
	public double getTemp() {
		return temp;
	}
	public double getHumidity() {
		return humidity;
	}
	public double getAirPressure() {
		return airPressure;
	}
	public int getRegionId(){
		return regionId;
	}
}