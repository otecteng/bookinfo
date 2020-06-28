### application topo
    productpage -   |-> review  -> rating  
                    |-> detail  

    order   -> mysql  
            -> rabbitmq  -  |->     stock   
                            |->     delivery   
### build
build projects  
```
gradlew build
```
artifacts is under project build/libs  

build images    
```
docker-compose build
```
### run
```
docker-compose up
```

### start eureka
```
java -jar eureka.jar &
```

### start application  
```
java -jar app/rating.jar &
java -jar app/review.jar &
java -jar app/detail.jar &
java -jar app/productpage.jar &
java -jar app/order.jar &
java -jar app/stock.jar &
java -jar app/delivery.jar &
```
check eureka service status,open http://localhost:8080  


### testing  
```
curl -H "Accept: application/json" -H "Content-type: application/json" -X GET http://localhost:8000/api/v1/products/1
curl http://localhost:4567/api/v1/products/1/review
curl POST http://localhost:4567/api/v1/order
curl -H "Accept: application/json" -H "Content-type: application/json" -X POST http://localhost:8080/api/order -d '{"product":"book","count":1}'
```

### stop application
```
pkill -f "java -jar" 
```

### for developers
* Java version: 1.8  
* Springboot:2.2.7