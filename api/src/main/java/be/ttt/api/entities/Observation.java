package be.ttt.api.entities;

import javax.persistence.*;

@Entity
@Table(name = "observations")
public class Observation {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	private int regionId;
	private double temp;
	private double humidity;
	private double airPressure;
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public int getRegionId() {
		return regionId;
	}
	public void setRegionId(int regionId) {
		this.regionId = regionId;
	}
	public double getTemp() {
		return temp;
	}
	public void setTemp(double temp) {
		this.temp = temp;
	}
	public double getHumidity() {
		return humidity;
	}
	public void setHumidity(double humidity) {
		this.humidity = humidity;
	}
	public double getAirPressure() {
		return airPressure;
	}
	public void setAirPressure(double airPressure) {
		this.airPressure = airPressure;
	}
}