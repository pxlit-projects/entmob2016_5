package be.ttt.api.aspects;

import org.aspectj.lang.annotation.AfterThrowing;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class AfterThrowingAspects {
	@AfterThrowing(value="execution(* be.ttt.api.services.*.*(..))",throwing="ex")
	public void afterThrowing(Exception ex){
		System.out.println("Exception: "+ex.getMessage());	
	}
}
