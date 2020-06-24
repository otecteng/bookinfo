package com.example;

import org.springframework.amqp.core.*;
import org.springframework.amqp.rabbit.connection.ConnectionFactory;
import org.springframework.amqp.rabbit.listener.SimpleMessageListenerContainer;
import org.springframework.amqp.rabbit.listener.adapter.MessageListenerAdapter;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MQConfig {
    @Bean
    Queue queue() {
        return new Queue("stock", true);
    }

    @Bean
    public DirectExchange shopExchange() {
        return new DirectExchange("bookinfo");
    }

    @Bean
    Binding binding() {
        return BindingBuilder.bind(queue()).to(shopExchange()).with("stock");
    }
}
