package com.example.productpage;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.openfeign.EnableFeignClients;

@EnableFeignClients
@SpringBootApplication
public class ProductpageApplication {

	public static void main(String[] args) {
		SpringApplication.run(ProductpageApplication.class, args);
	}

}
