package be.ttt.api;

import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;

public class App {
	public static void main(String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(AppConfig.class, args);
	}
}
