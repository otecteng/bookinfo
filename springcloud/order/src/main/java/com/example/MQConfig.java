package com.example;

import org.springframework.amqp.core.*;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MQConfig {

    @Bean
    public TopicExchange orderExchange() {
        return new TopicExchange("order");
    }

    @Bean
    public DirectExchange shopExchange() {
        return new DirectExchange("bookinfo");
    }

}
