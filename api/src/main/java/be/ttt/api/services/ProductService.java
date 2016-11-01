package be.ttt.api.services;

import be.ttt.api.entities.Observation;
import be.ttt.api.entities.Product;

import java.util.List;

public interface ProductService {
	public List<Product> getAll();
	public Product getById(int id);
	public List<Product> getByRackId(int id);
	public List<Product> getInDanger(Observation o);
	public Product addProduct(Product product);
	public Product updateProduct(Product product);
	public void deleteProduct(int id);
}