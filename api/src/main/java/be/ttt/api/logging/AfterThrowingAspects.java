package be.ttt.api.logging;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.time.LocalDateTime;

import org.aspectj.lang.annotation.AfterThrowing;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class AfterThrowingAspects {
	@Autowired
	private ExceptionSender sender;
	
	@AfterThrowing(value="execution(* be.ttt.api.*.*.*(..))",throwing="ex")
	public void afterThrowing(Exception ex){
		StringWriter sw = new StringWriter();
		PrintWriter pw = new PrintWriter(sw);
		ex.printStackTrace(pw);
		String message = "[Exception] "+ LocalDateTime.now().toString() + " "+ sw.toString();
		sender.sendException(message);	
	}
	
	
}
