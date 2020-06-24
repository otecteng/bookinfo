package com.example;

import org.springframework.amqp.rabbit.annotation.RabbitHandler;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Component;

@Component
@RabbitListener(queues = "delivery")
public class OrderTopic {
    @RabbitHandler
    public void process(String message) {
        System.out.println("Delivery receive from order : " + message);
    }
}
