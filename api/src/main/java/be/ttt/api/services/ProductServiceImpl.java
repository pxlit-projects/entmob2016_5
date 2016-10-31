package be.ttt.api.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import be.ttt.api.entities.Observation;
import be.ttt.api.entities.Product;
import be.ttt.api.repositories.ProductRepository;

public class ProductServiceImpl implements ProductService {

	@Autowired
	private ProductRepository productRepository;

	public List<Product> getAll() {
		return (List<Product>) productRepository.findAll();
	}

	public Product getById(int id) {
		return productRepository.findOne(id);
	}

	public List<Product> getByRackId(int id) {
		return productRepository.findAllByRackId(id);
	}
	
	public List<Product> getInDanger(Observation o){
		return productRepository.findAllInDanger(o);
	}

	public Product addProduct(Product product) {
		return productRepository.save(product);
	}

	public Product updateProduct(Product product) {
		return productRepository.save(product);
	}

	public void deleteProduct(int id) {
		productRepository.delete(id);
	}
}