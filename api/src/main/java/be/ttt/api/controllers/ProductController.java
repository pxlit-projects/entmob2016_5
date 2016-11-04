package be.ttt.api.controllers;

import be.ttt.api.entities.Observation;
import be.ttt.api.entities.Product;
import be.ttt.api.entities.Region;
import be.ttt.api.services.ObservationService;
import be.ttt.api.services.ProductService;
import be.ttt.api.services.RegionService;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ProductController implements ICrudController<Product> {
	@Autowired
	private ProductService productServiceImpl;
	@Autowired
	private RegionService regionServiceImpl;
	@Autowired
	private ObservationService observationServiceImpl;
	
	@RequestMapping(value="/products", method=RequestMethod.GET)
	public List<Product> getAll() {
		return productServiceImpl.getAll();
	}

	@RequestMapping(value="/product/{id}", method=RequestMethod.GET)
	public Product getById(@PathVariable int id) {
		return productServiceImpl.getById(id);
	}
	
	@RequestMapping(value="/products/danger", method=RequestMethod.GET)
	public List<Product> getAllInDanger() {
		List<Product> inDanger = new ArrayList<>();
		for(Region r : regionServiceImpl.getAll()){
			Observation lastByRegion = observationServiceImpl.getLastByRegionId(r.getId());
			if(lastByRegion != null)
				inDanger.addAll(productServiceImpl.getInDanger(lastByRegion));
		}
		return inDanger;
	}

	@RequestMapping(value="/products", method=RequestMethod.POST)
	public Product add(@RequestBody Product input) {
		return productServiceImpl.addProduct(input);
	}

	@RequestMapping(value="/products", method=RequestMethod.PUT)
	public Product update(@RequestBody Product input) {
		return productServiceImpl.updateProduct(input);
	}

	@RequestMapping(value="/product/{id}", method=RequestMethod.DELETE)
	public void delete(@PathVariable int id) {
		productServiceImpl.deleteProduct(id);
	}
}