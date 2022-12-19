package com.tau.taueureka;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@EnableEurekaServer
@SpringBootApplication
public class TaueurekaApplication {

	public static void main(String[] args) {
		SpringApplication.run(TaueurekaApplication.class, args);
	}

}
