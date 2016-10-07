SensorTag:
  - ID (int)
  - RegionID (int)

Warehouse:
  - ID (int)
  - Name (string)
  - Regions (lijst)
  
Regions:
  - ID (int)
  - Name (string)
  - WarehouseID (int)
  - Racks (lijst)
  - Observations (lijst)
  
Rack:
  - ID (int)
  - RegionID (int)
  - Products (lijst)
  
Product:
  - ID (int)
  - Name (string)
  - MinimumTemperature (double)
  - MaximumTemperature (double)
  - MinimumHumidity (double)
  - MaximumHumidity (double)
  - MinimumAirPressure (double)
  - MaximumAirPressure (double)
  - RackID (int)
  
Observation:
  - ID (int)
  - SensorTagID (int)
  - Timestamp (timestamp)
  - Temperature (double)
  - Humidity (double)
  - AirPressure (double)
