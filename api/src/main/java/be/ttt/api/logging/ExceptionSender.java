package be.ttt.api.logging;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

@Component
public class ExceptionSender {
	@Autowired
	private JmsTemplate jmsTemplate;
	
	public void sendException(String message){
		jmsTemplate.send("ExceptionQueue",s->s.createTextMessage(message));
	}
}