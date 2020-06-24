package com.example;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/order")
public class OrderController {
    @Autowired
    StockQueue queue;
    @Autowired
    OrderTopic topic;

    @PostMapping
    public String create(@RequestBody OrderCommand order) {
        queue.send(order.getProduct());
        topic.publish(order.getProduct());
        return "order posted";
    }
}
