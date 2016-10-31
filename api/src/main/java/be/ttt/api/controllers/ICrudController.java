package be.ttt.api.controllers;

import java.util.List;

import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;

public interface ICrudController<T> {
	//@RequestMapping(value="/<T>s", method=RequestMethod.GET)
	public List<T> getAll();
	//@RequestMapping(value="/<T>/{id}", method=RequestMethod.GET)
	public T getById(@PathVariable int id);
	//@RequestMapping(value="/<T>s", method=RequestMethod.POST)
	public T add(@RequestBody T input);
	//@RequestMapping(value="/<T>s", method=RequestMethod.PUT)
	public T update(@RequestBody T input);
	//@RequestMapping(value="/<T>/{id}", method=RequestMethod.DELETE)
	public void delete(@PathVariable int id);
}