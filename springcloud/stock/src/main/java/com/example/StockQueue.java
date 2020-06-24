package com.example;

import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.amqp.rabbit.annotation.RabbitHandler;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
@RabbitListener(queues = "stock")
public class StockQueue {
    @RabbitHandler
    public void process(String message) {
        System.out.println("Stock receive from order  : " + message);
    }
}
