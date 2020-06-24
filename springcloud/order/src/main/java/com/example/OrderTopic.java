package com.example;

import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class OrderTopic {
    @Autowired
    private AmqpTemplate amqpTemplate;

    public String publish(String product) {
        amqpTemplate.convertAndSend("order", "delivery.*", product);
        return product;
    }
}
