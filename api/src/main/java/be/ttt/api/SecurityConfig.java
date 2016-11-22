package be.ttt.api;

import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;

@Configuration
public class SecurityConfig extends WebSecurityConfigurerAdapter {
	
	@Override
	  protected void configure(HttpSecurity http) throws Exception {
	    http.csrf().disable();
	    http.httpBasic();
	    http.authorizeRequests()
	    	.antMatchers(HttpMethod.POST, "/*").hasRole("ADMIN")
	    	.antMatchers(HttpMethod.PUT, "/*").hasRole("ADMIN")
	    	.antMatchers(HttpMethod.DELETE, "/*/*").hasRole("ADMIN");
	  }
}
