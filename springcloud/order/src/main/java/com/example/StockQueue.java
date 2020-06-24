package com.example;

import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class StockQueue {
    @Autowired
    private AmqpTemplate amqpTemplate;

    public String send(String product) {
        amqpTemplate.convertAndSend("bookinfo", "stock", product);
        return product;
    }
}
