package be.ttt.api;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.test.context.ContextConfiguration;

@SpringBootApplication
@EnableAspectJAutoProxy
@EnableGlobalMethodSecurity(securedEnabled = true)
@ContextConfiguration(classes = SecurityConfig.class)
public class App {
	public static void main(String[] args) {
		SpringApplication.run(App.class, args);
	}
}
